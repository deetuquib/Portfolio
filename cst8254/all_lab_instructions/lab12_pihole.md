

# Pi-Hole

### Objectives

In this lab you:

- Install and configure Pi-hole on your raspberry pi.
- This lab is adapted from https://www.digitalocean.com/community/tutorials/how-to-block-advertisements-at-the-dns-level-using-pi-hole-and-openvpn-on-ubuntu-16-04 .

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

### Installing Pi-hole on the Raspberry Pi

Starting the Pi-hole Install Script

**1.** Let us start the installation process by running the following command.

```
curl -sSL https://install.pi-hole.net | bash
```

The next screen is a message from the **Pi-hole automated installer** informing you that you are installing a network-wide ad blocker.

Press `ENTER` to proceed.

![](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih1.png)

Next, the installation wizard tells you that Pi-hole is **Free and open source** and lets you know how you can donate to the Pi-hole project.

Press `Ok` to continue the installation.

![Step 3: Pi-hole Installation Script](https://assets.digitalocean.com/articles/block-ads-using-pi-hole/step-3.png)

The installation script will then inform you that a **Static IP Address** is required for the service to function properly.

press `Yes` to continue.

![](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih3.jpg)

The next screen asks you to **Choose An Interface** for Pi-hole to listen on. Because you need Pi-hole to monitor the network interface, use the arrow keys on your keyboard to highlight **wlan0** and then press `SPACE` to make the selection. Next, press `TAB` to jump to the options at the bottom of screen. With **<Ok>** highlighted, press `ENTER` to save the settings and continue.

![](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih4.jpg)

The wizard now asks you to confirm the use or not of a static IP. Select the last option then click Ok

![pih4-1](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih4-1.jpg)

The wizard now asks you to specify the **Upstream DNS Provider**. This is the service Pi-hole will use to [resolve domain names](https://www.digitalocean.com/community/tutorials/an-introduction-to-dns-terminology-components-and-concepts#how-dns-works). For simplicity’s sake, you can leave this set to the default value, **Google**.

Press `TAB` to jump to the bottom of the screen, then press `ENTER` when **<Ok>** is highlighted.

![Step 6: Pi-hole Installation Script](https://assets.digitalocean.com/articles/block-ads-using-pi-hole/step-6.png)

On the following screen, Pi-hole prompts you to select which third party to use to block ads. Click Ok.

![pih4-2](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih4-2.jpg)

In addition to a command-line interface, you can also manage Pi-hole through its **web admin interface**. One of the web interface’s main advantages is its ability to view live DNS queries and blocking statistics.

By default, the **web admin interface** is set to **On**. 

Use `TAB` to select **<Ok>** and then press `ENTER`.

![Step 12: Pi-hole Installation Script](https://assets.digitalocean.com/articles/block-ads-using-pi-hole/step-12.png)

Click Ok to install the web server and PHP modules.

![pih5](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih5.jpg)

In order to make use of the **web admin interface’s** ability to view live DNS queries and blocking statistics, you have to configure Pi-hole to **log queries**.

This is both the default and recommended setting, so use `TAB` to select **<Ok>** and then press `ENTER`.

![Step 13: Pi-hole Installation Script](https://assets.digitalocean.com/articles/block-ads-using-pi-hole/step-13.png)

Select the default privacy mode then click Ok.

![pih6](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih6.jpg)

At this point, Pi-hole will download and install the remaining dependencies along with the default data for the block- and blacklist. From there, Pi-hole will apply all of the network configuration settings you entered in the previous screens.Installing piHole to your Raspberry Pi.

Pi-Hole then confirms the installation and tells you how to connect to the admin web interface. Make sure you mark down the password to log on.

![pih7](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih7.jpg)



From your laptop connect to the pi-hole web interface.

![pih8](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih8.jpg)

![pih9](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih9.jpg)

**Take  a screenshot of the web interface. Name it pihole1.jpg.**

### Setting your client

You now need to set your client to use Pi-hole as your DNS server. 

On a Mac in the System Preferences, select Network, then click on the advanced Tab, then the DNS Tab and then replace the entries with the IP address of your Pi.

![pih10](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih10.jpg)

You then click `Ok` then `Apply`

On a windows machine, in the control panel, select Network then Internet Protocol Version 4 the Use the following DNS server addresses where you input the IP address of your Pi.

![pih11](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih11.webp)

![pih12](C:/Users/deetu/OneDrive/Documents/Network Operating Systems Github/lab12-301-deetuquib/pih12.png)

You then click `Ok` twice.

Once this is done, open a browser window on your laptop then navigate to a few sites like www.nytimes.com and www.cnn.com

Switch to the pi-Hole web interface and click on the Query Log tab. **Take a screenshot. Name it pihole2.jpg.**

Upload the two screenshots to GitHub classroom.

If you want to uninstall Pi-hole, you can do so by using `pihole uninstall` in a Terminal window of your Pi. Make sure you also update your DNS settings on your laptop.