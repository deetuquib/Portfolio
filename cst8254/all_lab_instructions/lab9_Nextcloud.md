## Nextcloud

### Objectives

- In this lab you will configure a Raspberry Pi NextCloud Server, this can act as your own personal “cloud” storage system.
- This lab is adapted from **`https://pimylifeup.com/raspberry-pi-nextcloud-server/`**

### Task 1 - Installing Nextcloud

- Installing Nextcloud to the Raspberry Pi is quite simple, it mainly involves downloading the script from their website, extracting the zip and then going to your Raspberry Pi’s IP address.

  1. To get started let’s first move to our html directory with the following command:

     ```
     cd /var/www/html
     ```

  2. Now we can run the following **`curl`** command so we can download and extract the latest version of Nextcloud in one go.

     ```
     curl https://download.nextcloud.com/server/releases/nextcloud-21.0.0.tar.bz2 | sudo tar -jxv
     ```

  3. Now for the next few steps we need to change directory into our newly unzipped folder, to do this run the following command.

     ```
     cd /var/www/html/nextcloud
     ```

  4. We now need to create a data directory for Nextcloud to operate in, for the initial setup of Nextcloud we must make this folder in our html/nextcloud directory. Do that with the following command:

     ```
     sudo mkdir -p /var/www/html/nextcloud/data
     ```

  5. Now let’s give the correct user and group control over the data folder by running the following command.

     ```
     sudo chown www-data:www-data /var/www/html/nextcloud/data
     ```

  6. Finally we need to give it the right permissions, again run the following command:

     ```
     sudo chmod 750 /var/www/html/nextcloud/data
     ```

  7. We are not quite done dealing with permissions, there is one final thing we must do and that is give the www-data group control over the config and apps folder. Run the following command to do this:

     ```
     sudo chown www-data:www-data config apps
     ```

  8. Make sure you can connect to mysql using the root account

     ```
     mysql -uroot -p 
     ```

     If you get an access denied error, change the root password:

     ```
     sudo mysql 
     MariaDB [(none)]> ALTER USER 'root'@'localhost' IDENTIFIED BY 'NEW_ROOT_PASSWORD';
     ```

     

  9. Now that we have finished with that we can now finally go to Nextcloud itself and begin its installation process. To begin go to your Raspberry Pi’s IP address plus /nextcloud. Do not forget to replace 192.168.1.105 with the IP address of your Pi.

     ```
     https://192.168.1.105/nextcloud
     ```

  10. You will be greeted with the intro screen, here you will need to type in the Username and Password that you intend to use for your admin account. Once you are happy with this, press the “Finish Setup” button, please note this can take some time to complete as it finalises your setup.

  11. After this you should now be greeted with the following welcome screen, this just lays out the various programs you can use to connect with your Nextcloud installation. Just press the X button in the top right corner to continue.

  12. Now you can finally see the interface of the Raspberry Pi Nextcloud, take some time to familiarize yourself with all the functionality of Nextcloud’s interface and the features of Nextcloud.

  13. Click on the picture icon, then **take a screenshot of the screen.**

### Task 2 - Moving Nextcloud’s data folder

- With Nextcloud now safely installed we can now tweak the setup to both be more secure and a bit more useable, one of the first things we should do is move the data directory so it does not sit in our web accessible directory.

  1. To get started let’s make our new directory for where we will store our data files, to make it easy we will make a new folder at /var/nextcloud and move our data folder into there. Create the folder by running the following command:

     ```
     sudo mkdir -p /var/nextcloud
     ```

  2. With our new folder we created we will now move our data directory into it, this is easy to do thanks to the mv command. Please note that your Nextcloud system will be out of action while we move the file then adjust the configuration file. To begin the move type in the following command:

     ```
     sudo mv -v /var/www/html/nextcloud/data /var/nextcloud/data
     ```

  3. Now with the files moved over we can now modify the datadirectory configuration to point to our new directory. First, let’s change to the config directory for Nextcloud with the following command.

     ```
     cd /var/www/html/nextcloud/config
     ```

  4. We can now copy the config file to make a backup of the file, we can do this with the following command:

     ```
     sudo cp -p config.php config.php.bk
     ```

  5. Finally let’s open up the **`config.php`** file for editing using nano.

     ```
     sudo nano config.php
     ```

  6. Within this file we need to change the following line:

     ```
     'datadirectory' => '/var/www/html/nextcloud/data',
     to
     'datadirectory' => '/var/nextcloud/data',
     ```

  7. Now we can save and quit out of the file by pressing **`Ctrl+X`** then **`Y`** and then **`Enter`**. You should be able to now refresh your web browser and all your files should be showing exactly as they were previously.

### Submit the lab

On your pi issue the command `ls -als /var/www/html/nextcloud >file1.txt` .Upload the file `file1.txt` to brightspace.

On your pi issue the command `ls -als /var/nextcloud > file2.txt`.Upload the file `file2.txt` to brightspace.

Upload the nextcloud screenshot (task 1-13) to brightspace.