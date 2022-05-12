### UFW

This is very short and sweet lab around configuring a basic Linux firewall using the Uncomplicated Firewall manager (UFW). We will be allowing SSH in our firewall . You must do this first otherwise if you are remotely connected to the system via SSH, it will terminate your connection, this may not matter on the virtual machine because you are physically connected to it, however if you are using the pi via SSH, this can be a concern. If you fail to follow this advice, then you will have to physically interface your pi via HDMI to a display and a keyboard and allow SSH through this means, only then will you be able to connect to the Raspberry pi remotely 

#### Configuring UFW

First install the UFW program which does not come stock with Raspbian, 

`sudo apt install ufw -y`

**To enables  SSH ports to be open, that way when we enable UFW, we are not disconnected, issue the command.**

`sudo ufw allow ssh`

To enable the firewall, issue the following command 

`sudo ufw enable`

**This step assumes that your Pi is set up as a web server. If it is not, start by installing Apache2. **

**From your laptop access the default web site of your pi and take a screenshot (`part1.jpg`).** 

Issue the following command enables port 80 to be allowed through.

`sudo ufw allow http`

**From your laptop access the default web site of your pi and take a screenshot (`part2.jpg`)**

Issue the following command enables port 440 to be allowed through.

`sudo ufw allow https`

**This step assumes that your Pi is set up as a web server that supports https. The process to do this can be found in the http lab.**

**From your laptop access the default web site of your pi using https and take a screenshot (`part3.jpg`)**

Get the ip of your laptopn then on the pi issue the command (**replace 192.168.2.101 with your laptop ip**)

`sudo ufw deny from 192.168.2.101 to any port 80`

**From your laptop access the default web site of your pi and take a screenshot (`part4.jpg`)**

Upload the 4 jpg files to Brightspace.



### Watch the following videos on YouTube.

Firewalls as fast as possible (5~ mins) (https://www.youtube.com/watch?v=N2sOPGhva1M)
What is a firewall? (https://www.youtube.com/watch?v=x1YLj06c3hM) 
What is a DMZ (Extra Info) (https://www.youtube.com/watch?v=dqlzQXo1wqo)