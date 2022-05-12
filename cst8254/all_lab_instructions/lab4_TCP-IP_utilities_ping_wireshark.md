## TCP/IP utilities

### Objectives

Use TCP/IP toubleshooting utilities on various Operating Systems

### Task 1

Log on your raspberry pi as `pi`

**1. What command do you use to check the value of your IP address?**

​	-

**2. What is the IP address of your raspberry pi ethernet connection, the ethernet connection being the active one, the one connected to the Internet?**

​	-

**3. What is the MAC address of your raspberry pi ethernet connection?**

​	-

On your laptop:

**4. What command do you use to check the value of your IP address?**

​	-

**5. What is the IP address of your laptop, the ethernet connection being the active one, the one connected to the Internet?**

​	-

**7. What is the MAC address of your laptop ethernet connection?**

​	-

### Task 2

Troubleshooting the network layer (layer 3).

On the raspberry pi

- Use the ping command to ping :
  - your laptop using its IP address
  - localhost
- For each ping command, save the ping command and one reply in a text file **`lab4.txt`**, for example:
  - **`ping 192.168.0.16`**`: 64 bytes from 192.168.0.16: icmp_seq=1 ttl=64 time=9.21 ms`
- Use the ping command to ping `www.algonquincollege.com`

**8. What is IP address returned?**

​	-

- In a web browser open the site `http://all-nettools.com/toolbox/smart-whois.php` and enter the previous IP in the Tectbox field .

**9. Who owns the IP address?**

​	-

**10. What class is this IP** (we'll cover that in class, but do a bit of research)

​	-

### Task 3

Troubleshooting the Transport layer (layer 4).

On the raspberry pi

- issue the command `netstat -at` This command shows all the ports your raspberry pi is listening to. You should see at least:
  - 80, http port
  - 23, ssh port
  - 3306, mysql port
  - 5900, vnc port
- issue the command `netstat -at > netstat.txt` to save the content to a text file.
- try the following `netstat` commands:
  - `netstat -a` List all ports
  - `netstat -at` List all tcp ports
  - `netstat -au` List all udp ports
  - `netstat -l` List only listening ports
  - `netstat -lt` List only listening tcp ports
  - `netstat -lu` List only listening tcp ports
  - `netstat -s` Show statistics
  - `netstat -r` Displays the routing table
- You may want to check if the `netstat` utility is available on your laptop.

### Task 4

Troubleshooting DNS (Application layer protocol, layer 7)

On the raspberry pi

- Install `nslookup` using the command `sudo apt-get install dnsutils`
- Open a `nslookup` session using the command `nslookup`
- Try the following `nslookup` command from the `nslookup` prompt:
  - `server` to display the DNS server currently used to resolve names to IP addresses,
  - `www.google.com` to display the IP address of the google web server.
  - `www.microsoft.com` to display the IP of the Microsoft web server.
  - `server 8.8.8.8` to change the current DNS server to the Google DNS server.
  - `www.microsoft.com` to display the IP of the Microsoft web server. You may find that the IP is not the same as the one reported by your ISP, this will be explained in class.
  - Type `exit` when you are done.

### Task 5

Install a packet sniffer

On your laptop

- Install `wireshark` from the wireshark website.

On the raspberry pi

- Install `wireshark` using the command `sudo apt-get install wireshark`



### Task 6: Submitting your Lab

Write the question and answer to the questions 1 to 10 in a markup file lab4.md.

Upload the files `lab4.md`, `lab4.txt,` `netstat.txt` to Brightspace. 