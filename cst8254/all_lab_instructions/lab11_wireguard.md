

# VPN Services

### Objectives

In this lab you:

- set up your Pi as a VPN server.
- install pivpn on your rapsberry pi
- configure your router for port forwarding.
- use your phone to connect to your VPN server.
- This lab is adapted from https://pimylifeup.com/raspberry-pi-wireguard/ the majority of the screenshots come from that site.

**1.** The first thing we need to do is ensure our Raspberry Pi is using the latest available packages.

We can do that by running the following two commands.

```
sudo apt update
sudo apt full-upgrade
```

**2.** We need to install the only package that we require to run the install scripts we need.

While this package should be available on most distributions of the Raspbian operating system, we will make sure by running the command below.

```
sudo apt install curl -y
```

### Installing WireGuard on the Raspberry Pi

Within this section, we are going to make use of the PiVPN script to install WireGuard.

PiVPN makes the process of installing WireGuard on our Raspberry Pi a straightforward process. The script sets up the best defaults for our device.

### Starting the PiVPN Install Script

**1.** Let us start the installation process by running the following command.

```
curl -L https://install.pivpn.io | bash
```

This command will use `curl` to download the PiVPN setup script from their website and then pipe it straight to bash.

You can verify this script’s contents by going directly to the [install PiVPN domain](https://install.pivpn.io/) in your web browser.

### Installing WireGuard to your Raspberry Pi

**1.** The first screen you will be greeted with will let you know what this script is about to do.

To start the WireGuard installation process, press the ENTER key.
![PiVPN Welcome Install Screen](https://pi.lbbcdn.com/wp-content/uploads/2020/07/1-PiVPN-Welcome-Install-Screen.png)

**2.** The first thing that we will be configuring through this script is a static IP address.

This screen explains why your Raspberry Pi should have a [static IP address](https://pimylifeup.com/raspberry-pi-static-ip-address/) when operating as a WireGuard VPN server.

To proceed, press the ENTER key to proceed.

![PiVPN Message about Static IP Address](https://pi.lbbcdn.com/wp-content/uploads/2020/07/2-PiVPN-Message-about-Static-IP-Address.png)

**3.** You will be asked if you are  using DHCP reservation.

Using DHCP reservation allows you to make your router assign an IP address to your Raspberry Pi.lf.

Select the `<Yes>` option and press the ENTER key to continue.



**4.** This screen will tell you that you need to specify a local user to store the WireGuard configuration files.

Continue to the next screen by pressing the ENTER key.

![Message about Local users](https://pi.lbbcdn.com/wp-content/uploads/2020/07/6-PiVPN-Message-about-Local-users.png)

**5.** You can now select from a list of available users.

Use the ARROW keys to highlight the user then the SPACEBAR to select it.

Once you are happy with the user you have selected, press the ENTER key.

![Select Raspberry Pi user for WireGuard Config](https://pi.lbbcdn.com/wp-content/uploads/2020/07/7-PiVPN-Select-from-user-list.png)

**6.** Finally, we can select the VPN software we want to install.

As we want to install WireGuard to our Raspberry Pi, you can press the ENTER key to continue.

The reason for this is that default by the PiVPN script selects WireGuard.

![Select WireGuard as VPN for Raspberry Pi](https://pi.lbbcdn.com/wp-content/uploads/2020/07/8-Select-WireGuard-as-VPN-for-Raspberry-Pi.png)

**7.** This screen will allow you to change the port the WireGuard uses on your Raspberry Pi.

It is recommended to keep this the same unless you have a particular reason to change the port.

Press the ENTER key to confirm the specified port.

![Choose Wireguard Port for Raspberry Pi VPN](https://pi.lbbcdn.com/wp-content/uploads/2020/07/9-Choose-Wireguard-Port-for-Raspberry-Pi-VPN.png)

**8.** This screen just confirms the port that you set your Raspberry Pi WireGuard VPN to use.

Please note to be able to access your WireGuard VPN from outside of your home network, you will need to port forward the port mentioned here. The type of this port is `UDP`.

Confirm that the port is still correct, then press the ENTER key to proceed.

![Confirm WireGuard VPN Port](https://pi.lbbcdn.com/wp-content/uploads/2020/07/10-Confirm-WireGuard-VPN-Port.png)

**9.** We can now specify the DNS provider that we want to use for our VPN clients.

For our tutorial, we chose to use the Google DNS.

Use the ARROW keys to navigate through this menu. Once you have found the DNS provider you want to use, press the SPACEBAR key.

If you are happy with your selection, press the ENTER key to confirm it.



**10.** You can specify two different ways you want to access your WireGuard VPN.

Using your public IP address is the easiest option. However, this should only be used if you have a static IP address.

The other option is to use a domain name. You can set up this option if you are using dynamic DNS.

For this guide, we will be sticking with using our public IP address. Note that this IP is likely to change once in a while so you will need to update the configuration file accordingly.

Once you have the option you want to be selected, press the ENTER key to proceed.

![Choose WireGuard access paths](https://pi.lbbcdn.com/wp-content/uploads/2020/07/12-Choose-WireGuard-access-paths.png)

**11.** The PiVPN script will now generate the server key that WireGuard requires.

All you need to do here is press the ENTER key again.

![Raspberry Pi WireGuard Generating Server keys](https://pi.lbbcdn.com/wp-content/uploads/2020/07/13-WireGuard-Generating-Server-keys.png)

**12.** This screen will give you a quick rundown about unattended-upgrades and why you should enable them.

Go to the next step by pressing the ENTER key.

![PiVPN Warning about enabling Unattended Upgrades](https://pi.lbbcdn.com/wp-content/uploads/2020/07/14-PiVPN-Warning-about-enabling-Unattended-Upgrades.png)

**13.** You can now enable the unattended-upgrades by selecting the `<Yes>` option.

We highly recommend that you enable these to ensure your Raspberry Pi will download security fixes regulary.

Not enabling this will potentially leave your WireGuard VPN vulnerable to attack.

Once you have the option you want to be selected, press the ENTER key to confirm it.

![Enabling Unattended Upgrades on Pi](https://pi.lbbcdn.com/wp-content/uploads/2020/07/15-PiVPN-Enabling-Unattended-Upgrades-on-Pi.png)

**14.** You have now successfully installed the WireGuard VPN software to your Raspberry Pi.

This screen will let you know that you still need to create profiles for the users, which we will cover in the next section.

Press the ENTER key to continue to the last two steps.

![Raspberry Pi WireGuard Installation Completed](https://pi.lbbcdn.com/wp-content/uploads/2020/07/16-Raspberry-Pi-WireGuard-Installation-Completed.png)

**15.** You will be asked whether you want to restart your Raspberry Pi before continuing.

We recommend that you choose the `<Yes>` option.

Once you have selected to reboot, press the ENTER key twice to restart.

![Reboot Raspberry Pi after WireGuard Installation](https://pi.lbbcdn.com/wp-content/uploads/2020/07/17-Reboot-Pi-after-WireGuard-Installation.png)

**16.** use `ssh` to connect yo your pi then enter supervisor mode using `sudo su`

Note that your are now connected as root. Change to the `/etc/wireguard` folder and edit the file `wg0.conf` using nano.

In the `[interface]`section cut and paste the following line. You need to replace `192.168.x.x` with the ip of your router, and if needed replace `wlan0`with the name of your interface.

`DNS=192.168.x.x`

`PostUp = iptables -A FORWARD -i %i -j ACCEPT; iptables -A FORWARD -o %i -j ACCEPT; iptables -t nat -A POSTROUTING -o wlan0 -j MASQUERADE`

`PostDown = iptables -D FORWARD -i %i -j ACCEPT; iptables -D FORWARD -o %i -j ACCEPT; iptables -t nat -D POSTROUTING -o wlan0 -j MASQUERADE`

Save the file and exit.

**17.** This section needs access to the web configuration app of your router. Check with your ISP documentation to see how you access it. 

You need to examble `port forwarding` to allow internet clients to connect to your pi. I am using Virgin and here is a screenshot of what I had to do myself.

**Enable udp port forwarding using the port you specified at pivpn install time and add the local ip of your pi**

![](/Users/jeromemizon/Documents/8254/22W/Screen Shot 2021-02-14 at 3.47.38 PM.png)

**Add my pi to the `DMZ`**

![Screen Shot 2021-02-14 at 3.48.13 PM](/Users/jeromemizon/Documents/8254/22W/Screen Shot 2021-02-14 at 3.48.13 PM.png)



DNS=10.77.53.1
PostUp = iptables -A FORWARD -i %i -j ACCEPT; iptables -A FORWARD -o %i -j ACCEPT; iptables -t nat -A POSTROUTING -o eth0 -j MASQUERADE
PostDown = iptables -D FORWARD -i %i -j ACCEPT; iptables -D FORWARD -o %i -j ACCEPT; iptables -t nat -D POSTROUTING -o eth0 -j MASQUERADE

### Creating your First WireGuard Profile on your Raspberry Pi

Now that we have successfully installed the WireGuard software to our Raspberry Pi, we can create a profile for it.

To be able to create this profile, we will be making use of the PiVPN script again.

**1.** To begin creating a new profile for WireGuard, we need to run the following command.

```
sudo pivpn add
```

**2.** All you need to do is type in a name for the profile that you are creating.

For example, we will be calling our profile “cst8254“.

![Creating a WireGuard Profile on Raspberry Pi](https://pi.lbbcdn.com/wp-content/uploads/2020/07/19-Creating-a-WireGuard-Profile-on-Raspberry-Pi.png)

Once you have created a profile, it will be stored within the directory specified in the output.

If you followed the previous steps and used the `pi` user, you will be able to find the config file within the `/home/pi/configs` directory.

You can use the config file within here to set up your WireGuard clients. However, there is another method which we will go into in the next section.

### Generating a QR Code for your WireGuard Profile

In this section, we will show you how to generate a QR code for the WireGuard profile we generated on our Raspberry Pi.

You will be able to scan this QR code using your device. This saves you from having to copy the config file from your device.

Luckily for us, the PiVPN software comes with a QR code generator that we can use.

**1.** To generate a QR code for your profile, you will need to start by running the following command.

Make sure you replace “`PROFILENAME`” with the name you set in the previous section. In our case, this will be “cst8254“.

```
pivpn -qr PROFILENAME
```

![QR Code Generatted for WireGuard connection](https://pi.lbbcdn.com/wp-content/uploads/2020/07/20-QR-Code-Generatted-for-WireGuard-connection.png)

**2.** You can then scan this QR code using your iOS or Android devices.

You can find the WireGuard app on both the [Google Play Store](https://play.google.com/store/apps/details?id=com.wireguard.android) and the [Apple App Store](https://apps.apple.com/us/app/wireguard/id1441195209).

When scanning the QR code, you will be asked to enter a name for the profile. 

Turn wifi off so that you are not on your local network and enable the connection. You will now be connected to your Pi. You can use `pivpn -c`on your pi to check the active clients. On your phone, you can also check that its IP address is now the public IP of your router. Use whatismyipaddress.com to check.

![Screen Shot 2021-02-14 at 3.50.20 PM](/Users/jeromemizon/Documents/8254/22W/Screen Shot 2021-02-14 at 3.50.20 PM.png)



Below are screenshots of my phone connected.

![IMG_5441](/Users/jeromemizon/Documents/8254/22W/IMG_5441.PNG)

![IMG_5442](/Users/jeromemizon/Documents/8254/22W/IMG_5442.PNG)x`