## HTTP, virtual hosts and HTTPS

### Objectives

In this lab, you setup virtual hosts as well as https on your Raspberry Pi.

### Task 1 - Setting Up http on the Raspberry Pi

- Virtual hosts allow more than one domain to be served off of a single IP address on the same http port.

  1. First make sure **`http`** is properly configured on your raspberry pi.

  2. Create a new folder to host your second web site (the **`-p`** creates the folder if they do not exist):

     ```
     sudo mkdir -p /var/www/html/yourFirstName.iawd.ca
     ```

  3. Grant ownership of the directory to the user, instead of just keeping it on the root system.

     ```
     sudo chown -R $USER:$USER /var/www/html/yourFirstName.iawd.ca
     ```

  4. Additionally, it is important to make sure that everyone will be able to read our new files.

     ```
     sudo chmod -R 755 /var/www
     ```

  5. Create a default **`index.html`** page in the folder created that displays basic information about the web site **`yourFirstName.iawd.ca`**

  6. The next step is to set up the apache configuration. You going to work off a duplicate of the default file. So first make a copy of it:

     ```
     sudo cp /etc/apache2/sites-available/000-default.conf /etc/apache2/sites-available/yourfirstname.iawd.ca.conf
     ```

  7. Open up the new config file:

     ```
     sudo nano /etc/apache2/sites-available/yourfirstname.iawd.ca.conf
     ```

  8. Edit the following lines under the VirtualHost tag, note that you must replace the * in *:80 with the ip address of your Pi. You should also do the same in the file `000-default.conf`

     ```
     <VirtualHost *:80>  
     ServerName yourFirstName.iawd.ca
     DocumentRoot /var/www/html/yourFirstName.iawd.ca
     ```

  9. Save the file then exit then activate the new host

     ```
     sudo a2ensite yourFirstName.iawd.ca
     ```

  10. Restart Apache2.

      ```
      sudo service apache2 restart
      ```

### Task 2 - Setting Up the hosts file locally

- The **`hosts`** acts as a local **`dns`** server and associates friendly names and IP addresses.

- By default, it should contain a line that associates **`localhost`** to the IP **`127.0.0.1`**.

- On a windows machine it is stored in **`C:\Windows\System32\drivers\etc\hosts`**. If it does not exist, renaetme the file **`hosts.sam`** to **`hosts`**.

- On a Unix machine it located in the directory **`/etc`**.

- Use **`ifconfig`** to get your ip address then add the following line to your **`hosts`** file, **take a screenshot**

  ```
  yourIpAddress yourFirstName.iawd.ca
  ```

Which Web site do you access when you type in a browse, **take a screenshot**:

**`http://yourIpAddress`**

Which Web site do you access when you type in a browser, **take a screenshot**:

**`http://yourFirstName.iawd.ca`**

### Task 3 - Setup https and a local certificate

- This section is adapted from **`https://wiki.debian.org/Self-Signed_Certificate`**

  1. Install **`openssl`** on your raspberry pi

     ```
     sudo apt-get update
     sudo apt-get install openssl
     ```

  2. The second step is to start creating the Certificate File. For that you can use the **`openssl`** command that will assist you in the process.

     ```
     sudo mkdir -p /etc/ssl/localcerts
     sudo openssl req -new -x509 -days 365 -nodes -out /etc/ssl/localcerts/apache.pem -keyout /etc/ssl/localcerts/apache.key
     ```

  3. The request ask you a few questions. Below is an example of my responses (between the *).

     ```
     Country Name (2 letter code) [AU]:*CA*
     State or Province Name (full name) [Some-State]:*Ontario*
     Locality Name (eg, city) []:*Ottawa*
     Organization Name (eg, company) [Internet Widgits Pty Ltd]:*Algonquin*
     Organizational Unit Name (eg, section) []:*IAWD*
     Common Name (e.g. server FQDN or YOUR name) []:*mizon*
     Email Address []:*mizonj@algonquincollege.com*
     ```

  4. Adjust the permissions on the certificate files.

     ```
     sudo chmod 600 /etc/ssl/localcerts/apache*
     ```

  5. Ensure the **`ssl`** module is enabled in **`apache`**

     ```
     sudo a2enmod ssl
     ```

  6. Using **`nano`**, open and modify the file **`/etc/apache2/sites-available/default-ssl.conf`**

     ```
     <IfModule mod_ssl.c>
          <VirtualHost _default_:443>
                  ServerAdmin webmaster@localhost
                  ServerName 192.168.0.23         <=== Replace with the IP address of your Pi
                  DocumentRoot /var/www/html
                  SSLCertificateFile /etc/ssl/localcerts/apache.pem    <=== Update
                  SSLCertificateKeyFile /etc/ssl/localcerts/apache.key <=== Update
     ```

  7. Save the file as **`192.168.0.23.conf`** replacing **`192.168.0.23`** with the IP of your pi.

  8. Time to enable the site (replace **`192.168.0.23`** with the IP of your pi)

     ```
     sudo a2ensite 192.168.0.23
     ```

  9. Using **`nano`** open the file **`/etc/apache2/ports.conf/`** and verify the server is listening to port 80 and 443

     ```
     Listen 80
     Listen 443
     ```

  10. Exit **`nano`** and restart **`apache`**

      ```
      sudo service apache2 restart
      ```

Which Web site do you access when you type in a browser, **take a screenshot**:

**`https://yourIpAddress`**