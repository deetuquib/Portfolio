# Lab 5 - FTP

### Introduction

This lab borrows heavily from `https://www.digitalocean.com/community/tutorials/how-to-set-up-vsftpd-for-a-user-s-directory-on-ubuntu-18-04`

It is updated for Rapsberry PI Os.

FTP, short for File Transfer Protocol, is a network protocol that was once widely used for moving files between a client and server. It has since been replaced by faster, more secure, and more convenient ways of delivering files. Many casual Internet users expect to download directly from their web browser with `https`, and command-line users are more likely to use secure protocols such as the `scp` or [SFTP](https://www.digitalocean.com/community/tutorials/how-to-use-sftp-to-securely-transfer-files-with-a-remote-server).

FTP is still used to support legacy applications and workflows with very specific needs. If you have a choice of what protocol to use, consider exploring the more modern options. When you do need FTP, however, vsftpd is an excellent choice. Optimized for security, performance, and stability, vsftpd offers strong protection against many security problems found in other FTP servers and is the default for many Linux distributions.

In this lab, you’ll configure vsftpd to allow a user to upload files to his or her home directory using FTP with login credentials secured by SSL/TLS.



## Step 1 — Installing vsftpd

Let’s start by updating our package list and installing the `vsftpd` daemon:

```bash
sudo apt update
sudo apt install vsftpd
```

When the installation is complete, let’s copy the configuration file so we can start with a blank configuration, saving the original as a backup:

```bash
sudo cp /etc/vsftpd.conf /etc/vsftpd.conf.orig
```

With a backup of the configuration in place, we’re ready to configure the firewall.

## Step 2 — installing and Opening the Firewall

Let’s start by installing the `ufw` firewall:

```bash
sudo apt install ufw
```

Let’s check the firewall status to see if it’s enabled (**it should not be**). Skip to step 3.

**If it is, we’ll ensure that FTP traffic is permitted so firewall rules don’t block our tests.**

To enables  SSH ports to be open, that way when we enable UFW, we are not disconnected, issue the command.

`sudo ufw allow ssh`

In this case, only SSH is allowed through:

```
OutputStatus: active

To                         Action      From
--                         ------      ----
OpenSSH                    ALLOW       Anywhere
OpenSSH (v6)               ALLOW       Anywhere (v6)
```

You may have other rules in place or no firewall rules at all. Since only SSH traffic is permitted in this case, we’ll need to add rules for FTP traffic.

**IF THE FIREWALL STATUS IS ACTIVE, DO THE FOLLOWING**

Let’s open ports `20` and `21` for FTP, port `990` for when we enable TLS, and ports `40000-50000` for the range of passive ports we plan to set in the configuration file:

```bash
sudo ufw allow 20/tcp
sudo ufw allow 21/tcp
sudo ufw allow 990/tcp
sudo ufw allow 40000:50000/tcp
sudo ufw status
```

Check the firewall status again:

```bash
sudo ufw status
```

Our firewall rules should now look like this:

```
OutputStatus: active

To                         Action      From
--                         ------      ----
OpenSSH                    ALLOW       Anywhere
990/tcp                    ALLOW       Anywhere
20/tcp                     ALLOW       Anywhere
21/tcp                     ALLOW       Anywhere
40000:50000/tcp            ALLOW       Anywhere
OpenSSH (v6)               ALLOW       Anywhere (v6)
20/tcp (v6)                ALLOW       Anywhere (v6)
21/tcp (v6)                ALLOW       Anywhere (v6)
990/tcp (v6)               ALLOW       Anywhere (v6)
40000:50000/tcp (v6)       ALLOW       Anywhere (v6)
```

With `vsftpd` installed and the necessary ports open, let’s move on to creating a dedicated FTP user.

## Step 3 — Preparing the User Directory

We will create a dedicated FTP user, but you may already have a user in need of FTP access. We’ll take care to preserve an existing user’s access to their data in the instructions that follow. Even so, we recommend that you start with a new user until you’ve configured and tested your setup.

First, add a test user:

```bash
sudo adduser sandra
```

Assign a password when prompted. Feel free to press `ENTER` through the other prompts.

FTP is generally more secure when users are restricted to a specific directory. `vsftpd` accomplishes this with [`chroot`](https://www.digitalocean.com/community/tutorials/how-to-configure-chroot-environments-for-testing-on-an-ubuntu-12-04-vps#what-is-a-chroot-environment) jails. When `chroot` is enabled for local users, they are restricted to their home directory by default. However, because of the way `vsftpd` secures the directory, it must not be writable by the user. This is fine for a new user who should only connect via FTP, but an existing user may need to write to their home folder if they also have shell access.

In this example, rather than removing write privileges from the home directory, let’s create an `ftp` directory to serve as the `chroot` and a writable `files` directory to hold the actual files.

Create the `ftp` folder:

```bash
sudo mkdir /home/sandra/ftp
```

Set its ownership:

```bash
sudo chown nobody:nogroup /home/sandra/ftp
```

Remove write permissions:

```bash
sudo chmod a-w /home/sandra/ftp
```

Verify the permissions:

```bash
sudo ls -la /home/sandra/ftp
```

Output:

```
total 8
4 dr-xr-xr-x  2 nobody nogroup 4096 Aug 24 21:29 .
4 drwxr-xr-x  3 sandra  sandra   4096 Aug 24 21:29 ..
```

Next, let’s create the directory for file uploads and assign ownership to the user:

```bash
sudo mkdir /home/sandra/ftp/files
sudo chown sandra:sandra /home/sandra/ftp/files
```

A permissions check on the `ftp` directory should return the following:

```bash
sudo ls -la /home/sandra/ftp:
```

```
total 12
dr-xr-xr-x 3 nobody nogroup 4096 Aug 26 14:01 .
drwxr-xr-x 3 sandra sandra   4096 Aug 26 13:59 ..
drwxr-xr-x 2 sandra  sandra   4096 Aug 26 14:01 files
```

Finally, let’s add a `test.txt` file to use when we test:

```bash
echo "vsftpd test file" | sudo tee /home/sandra/ftp/files/test.txt
```

Now that we’ve secured the `ftp` directory and allowed the user access to the `files` directory, let’s modify our configuration.

## Step 4 — Configuring FTP Access

We’re planning to allow a single user with a local shell account to connect with FTP. The two key settings for this are already set in `vsftpd.conf`. Start by opening the config file to verify that the settings in your configuration match those below:

```bash
sudo nano /etc/vsftpd.conf
```

/etc/vsftpd.conf

```
. . .
# Allow anonymous FTP? (Disabled by default).
anonymous_enable=NO
#
# Uncomment this to allow local users to log in.
local_enable=YES
. . .
```

Next, let’s enable the user to upload files by uncommenting the `write_enable` setting:

Use Ctrl-W to locate the settings `write_enable` and uncomment the line by removing the # sign

```
. . .
write_enable=YES
. . .
```

We’ll also uncomment the `chroot` to prevent the FTP-connected user from accessing any files or commands outside the directory tree:

Use Ctrl-W to locate the settings `chroot_local_user` and uncomment the line by removing the # sign

```
. . .
chroot_local_user=YES
. . .
```

Let’s also add a `user_sub_token` to insert the username in our `local_root directory` path so our configuration will work for this user and any additional future users. 

**Add these settings anywhere in the file:**

```
. . .
user_sub_token=$USER
local_root=/home/$USER/ftp
```

Let’s also limit the range of ports that can be used for passive FTP to make sure enough connections are available:

**Add these settings anywhere in the file:**

```
. . .
pasv_min_port=40000
pasv_max_port=50000
```

**Note:** In step 2, we opened the ports that we set here for the passive port range. If you change the values, be sure to update your firewall settings.

To allow FTP access on a case-by-case basis, let’s set the configuration so that users have access only when they are explicitly added to a list, rather than by default:

**Add these settings anywhere in the file:**

```
. . .
userlist_enable=YES
userlist_file=/etc/vsftpd.userlist
userlist_deny=NO
```

`userlist_deny` toggles the logic: When it is set to `YES`, users on the list are denied FTP access. When it is set to `NO`, only users on the list are allowed access.

When you’re done making the changes, save the file and exit the editor.

Finally, let’s add our user to `/etc/vsftpd.userlist`. Use the `-a` flag to append to the file:

```bash
echo "sandra" | sudo tee -a /etc/vsftpd.userlist
```

Check that it was added as you expected:

```bash
cat /etc/vsftpd.userlist
```

Output:

```
sandra
```

Restart the daemon to load the configuration changes:

```bash
sudo systemctl restart vsftpd
```

or

```
sudo service vsftpd restart
```

With the configuration in place, let’s move on to testing FTP access.

## Step 5 — Testing FTP Access

We’ve configured the server to allow only the user `sandra` to connect via FTP. Let’s make sure that this works as expected.

**Anonymous users should fail to connect**: We’ve disabled anonymous access. Let’s test that by trying to connect anonymously. If our configuration is set up properly, anonymous users should be denied permission. Open another terminal window and run the following command. Be sure to replace `192.168.4.82` with your server’s public IP address:

```bash
ftp -p 192.168.4.82
```

```
Connected to 192.168.4.82.
220 (vsFTPd 3.0.3)
Name (192.168.4.82:jeromemizon): anonymous
530 Permission denied.
ftp: Login failed.
ftp> 
```

Close the connection:

```bash
bye
```

**Users other than `sandra` should fail to connect**: Next, let’s try connecting as our sudo pi. They should also be denied access, and it should happen before they’re allowed to enter their password:

```bash
ftp -p 192.168.4.82
```

```
Connected to 192.168.4.82.
220 (vsFTPd 3.0.3)
Name (192.168.4.82:jeromemizon): pi
530 Permission denied.
ftp: Login failed.
ftp> 
```

Close the connection:

```bash
bye
```



**The user `sandra` should be able to connect, read, and write files**: Let’s make sure that our designated user can connect:

```bash
ftp -p 192.168.4.82
```

```
Connected to 192.168.4.82.
220 (vsFTPd 3.0.3)
Name (192.168.4.82:jeromemizon): sandra
331 Please specify the password.
Password: 
230 Login successful.
```

Let’s change into the `files` directory and use the `get` command to transfer the test file we created earlier to our local machine:

```bash
cd files
get test.txt
```

```
ftp> cd files
250 Directory successfully changed.
ftp> get test.txt
227 Entering Passive Mode (192,168,4,82,189,217).
150 Opening BINARY mode data connection for test.txt (17 bytes).
WARNING! 1 bare linefeeds received in ASCII mode
File may not have transferred correctly.
226 Transfer complete.
17 bytes received in 0.00253 seconds (6.57 kbytes/s)
ftp> 

```

Next, let’s upload the file with a new name to test write permissions:

```bash
put test.txt upload.txt
```

```
put test.txt upload.txt
227 Entering Passive Mode (192,168,4,82,176,249).
150 Ok to send data.
226 Transfer complete.
18 bytes sent in 0.000428 seconds (41.1 kbytes/s)
ftp> 
```

Close the connection:

```bash
bye
```

On your laptop, start wireshark.

Connect to your PI ftp server again as `sandra`

`ftp -p 192.168.4.82`

Stop the wireshark capture then apply the filter `ftp`.

**Verify that the username and password are sent as clear text.**

Make a screenshot of the wireshark capture and save it as `lab5-1.jpg`

Now that we’ve tested our configuration, let’s take steps to further secure our server.

## Step 6 — Securing Transactions

Since FTP does *not* encrypt any data in transit, including user credentials, we’ll enable TLS/SSL to provide that encryption. The first step is to create the SSL certificates for use with `vsftpd`.

Let’s use `openssl` to create a new certificate and use the `-days` flag to make it valid for one year. In the same command, we’ll add a private 2048-bit RSA key. By setting both the `-keyout` and `-out` flags to the same value, the private key and the certificate will be located in the same file:

```bash
sudo openssl req -x509 -nodes -days 365 -newkey rsa:2048 -keyout /etc/ssl/private/vsftpd.pem -out /etc/ssl/private/vsftpd.pem
```

You’ll be prompted to provide address information for your certificate. Substitute your own information for the highlighted values below (the ==> <== are added to show you the information to fill. your_server_ ip must be replaced with the IP address of your PI):

```
OutputGenerating a 2048 bit RSA private key
............................................................................+++
...........+++
writing new private key to '/etc/ssl/private/vsftpd.pem'
-----
You are about to be asked to enter information that will be incorporated
into your certificate request.
What you are about to enter is what is called a Distinguished Name or a DN.
There are quite a few fields but you can leave some blank
For some fields there will be a default value,
If you enter '.', the field will be left blank.
-----
==> Country Name (2 letter code) [AU]:CA<==
==> State or Province Name (full name) [Some-State]:ON<==
==> Locality Name (eg, city) []:Ottawa<==
==> Organization Name (eg, company) [Internet Widgits Pty Ltd]:Algonquin<==
Organizational Unit Name (eg, section) []:
==> Common Name (e.g. server FQDN or YOUR name) []: your_server_ ip <==
Email Address []:
```

For more detailed information about the certificate flags, see [OpenSSL Essentials: Working with SSL Certificates, Private Keys and CSRs](https://www.digitalocean.com/community/tutorials/openssl-essentials-working-with-ssl-certificates-private-keys-and-csrs)

Once you’ve created the certificates, open the `vsftpd` configuration file again:

```bash
sudo nano /etc/vsftpd.conf
```

Toward the bottom of the file, you will see two lines that begin with `rsa_`. Comment them out so they look like this:

```
. . .
# rsa_cert_file=/etc/ssl/certs/ssl-cert-snakeoil.pem
# rsa_private_key_file=/etc/ssl/private/ssl-cert-snakeoil.key
. . .
```

Below them, add the following lines that point to the certificate and private key we just created:

```
. . .
rsa_cert_file=/etc/ssl/private/vsftpd.pem
rsa_private_key_file=/etc/ssl/private/vsftpd.pem
. . .
```

After that, we will force the use of SSL, which will prevent clients that can’t deal with TLS from connecting. This is necessary to ensure that all traffic is encrypted, but it may force your FTP user to change clients. Change `ssl_enable` to `YES`:

```
. . .
ssl_enable=YES
. . .
```

After that, add the following lines to explicitly deny anonymous connections over SSL and to require SSL for both data transfer and logins:

```
. . .
allow_anon_ssl=NO
force_local_data_ssl=YES
force_local_logins_ssl=YES
. . .
```

After this, configure the server to use TLS, the preferred successor to SSL, by adding the following lines:



```
. . .
ssl_tlsv1=YES
ssl_sslv2=NO
ssl_sslv3=NO
. . .
```

Finally, we will add two more options. First, we will not require SSL reuse because it can break many FTP clients. We will require “high” encryption cipher suites, which currently means key lengths equal to or greater than 128 bits:

```
. . .
require_ssl_reuse=NO
ssl_ciphers=HIGH
. . .
```

The finished file section should look like this:

```
# This option specifies the location of the RSA certificate to use for SSL
# encrypted connections.
#rsa_cert_file=/etc/ssl/certs/ssl-cert-snakeoil.pem
#rsa_private_key_file=/etc/ssl/private/ssl-cert-snakeoil.key
rsa_cert_file=/etc/ssl/private/vsftpd.pem
rsa_private_key_file=/etc/ssl/private/vsftpd.pem
ssl_enable=YES
allow_anon_ssl=NO
force_local_data_ssl=YES
force_local_logins_ssl=YES
ssl_tlsv1=YES
ssl_sslv2=NO
ssl_sslv3=NO
require_ssl_reuse=NO
ssl_ciphers=HIGH
```

When you’re done, save and close the file.

Restart the server for the changes to take effect:

```bash
sudo service vsftpd restart
```

At this point, we will no longer be able to connect with an insecure command-line client. If we tried, we’d see something like (the ==> <== are added to show you the important part of the output):

```
ftp -p 192.168.4.82
Connected to 192.168.4.82.
220 (vsFTPd 3.0.3)
Name (192.168.4.82:jeromemizon): sandra
==> 530 Non-anonymous sessions must use encryption. <==
==> ftp: Login failed. <==
ftp> 

```

Next, let’s verify that we can connect using a client that supports TLS.

## Step 7 — Testing TLS with FileZilla

Most modern FTP clients can be configured to use TLS encryption. We will demonstrate how to connect with [FileZilla](https://filezilla-project.org/) because of its cross-platform support. Consult the documentation for other clients.

When you first open FileZilla, find the Site Manager icon just above the word **Host**, the left-most icon on the top row. Click it:

![Site Manager Screent Shot](https://assets.digitalocean.com/articles/vsftpd_18_04/vsftpd_images/filezilla_site_manager_vsftpd_18_04.png)

A new window will open. Click the **New Site** button in the bottom right corner:

![New Site Button](https://assets.digitalocean.com/articles/vsftp-user/new-site.png)Under **My Sites** a new icon with the words **New site** will appear. You can name it now or return later and use the **Rename** button.

Fill out the **Host** field with the name or IP address. Under the **Encryption** drop down menu, select **Require explicit FTP over TLS**.

For **Logon Type**, select **Ask for password**. Fill in your FTP user in the **User** field:

![Screen Shot 2022-02-03 at 5.50.41 PM](/Users/jeromemizon/Desktop/Screen Shot 2022-02-03 at 5.50.41 PM.jpg)

Click **Connect** at the bottom of the interface. You will be asked for the user’s password:

![Screen Shot 2022-02-03 at 5.50.51 PM](/Users/jeromemizon/Desktop/Screen Shot 2022-02-03 at 5.50.51 PM.jpg)

Click **OK** to connect. You should now be connected with your server with TLS/SSL encryption.

Upon success, you will be presented with a server certificate that looks like this:

**Make a screenshot of this certificate window. Call it `lab5-2.jpg`**

![Screen Shot 2022-02-03 at 5.51.04 PM](/Users/jeromemizon/Desktop/Screen Shot 2022-02-03 at 5.51.04 PM.jpg)



When you’ve accepted the certificate, double-click the `files` folder and drag `upload.txt` to a folder on your laptop to confirm that you’re able to download files:

![Screen Shot 2022-02-03 at 5.51.16 PM](/Users/jeromemizon/Desktop/Screen Shot 2022-02-03 at 5.51.16 PM.jpg)

When you’ve done that, right-click on the local copy, rename it to `upload-tls.txt` and drag it back to the server to confirm that you can upload files.

You may start a wireshark session and verify that the connection is now encrypted.

You’ve now confirmed that you can securely and successfully transfer files with SSL/TLS enabled.

## Step 8 — Disabling Shell Access (Optional)

If you’re unable to use TLS because of client requirements, you can gain some security by disabling the FTP user’s ability to log in any other way. One relatively straightforward way to prevent it is by creating a custom shell. This will not provide any encryption, but it will limit the access of a compromised account to files accessible by FTP.

First, open a file called `ftponly` in the `bin` directory:

```bash
sudo nano /bin/ftponly
```

Add a message telling the user why they are unable to log in:

```
#!/bin/sh
echo "This account is limited to FTP access only."
```

Save the file and exit your editor.

Change the permissions to make the file executable:

```bash
sudo chmod a+x /bin/ftponly
```

Open the list of valid shells:

```bash
sudo nano /etc/shells
```

At the bottom add:

```
. . .
/bin/ftponly
```

Save the file.

Update the user’s shell with the following command:

```bash
sudo usermod sandra -s /bin/ftponly
```

Now try logging into your server as `sammy`:

```bash
ssh sandra@your_server_ip
```

You should see something like (the ==> <== are added to show you the important part of the output):

```
ssh sandra@192.168.4.82
The authenticity of host '192.168.4.82 (192.168.4.82)' can't be established.
ED25519 key fingerprint is SHA256:Ug7HLNkbJLSf5EyHJUQAiLRx0ZOvLaH9IIP6QlzcJuY.
This host key is known by the following other names/addresses:
    ~/.ssh/known_hosts:4: raspberrypi.local
    ~/.ssh/known_hosts:7: mizonj.local
Are you sure you want to continue connecting (yes/no/[fingerprint])? yes
Warning: Permanently added '192.168.4.82' (ED25519) to the list of known hosts.
sandra@192.168.4.82's password: 
Linux mizonj 5.10.92-v7l+ #1514 SMP Mon Jan 17 17:38:03 GMT 2022 armv7l

The programs included with the Debian GNU/Linux system are free software;
the exact distribution terms for each program are described in the
individual files in /usr/share/doc/*/copyright.

Debian GNU/Linux comes with ABSOLUTELY NO WARRANTY, to the extent
permitted by applicable law.
==>This account is limited to FTP access only. <==
Connection to 192.168.4.82 closed.
```

This confirms that the user can no longer `ssh` to the server and is limited to FTP access only.



### Task 9: Submitting your Lab

1. Log on your Pi as `pi` using `SSH`

2. Issue the following commands

   ```
   cat /etc/passwd>lab5-1.txt
   sudo ls -als /home>lab5-2.txt
   sudo ls -la /home/sandra/ftp >lab5-3.txt
   ```

3. Upload **`lab5-1.txt, lab5-2.txt, lab5-3.txt, lab5-1.jpg, lab5-2.jpg, /etc/vsftpd.conf`** to Brightspace