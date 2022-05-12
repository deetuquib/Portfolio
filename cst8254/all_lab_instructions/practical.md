## Practical Mid Term CST 8254 Winter 2022

**Your Name:**

```
Diana Jean Tuquib
```



**1. What command did you use?**

```
scp C:\Users\deetu\dianatuquib.txt pi@10.77.53.156:Documents
```



**2. What command do you use to see a directory listing that includes the permissions of the files?**

```
ls- la
```

**3. What command did you use?**

```
ls- la > pr1.txt
```

**4. What are the permissions of the file you just created?**

```
-rw-r--r-- (owner: read and write; groups and others: read only)
```

**5. What command do you use to display the folder you are currently working from?**

```
pwd
```



**6. What command did you use?**

```
assuming we want the owner and others to have the same default permissions, we can do the command below to add execute to the group's permission:

chmod 654 pr1.txt

```



**7. What command did you use?**

```
mkdir midtermExam
```

**8. What are the permissions of this folder `midtermExam` ?**

```
drwxr-xr-x
 (owner: read write execute; group and others: read and execute)
```

**9. What command do you use to list the ports your raspberry pi is listening to? Try it using the `-at` flag.**

```
netstat -at
```



**10. What command did you use?**

```
netstat -at > pr2.txt
```



**11. What command did you use to connect?**

```
sftp pi@10.77.53.156
```



**12. What command did you use?**

```
put C:\Users\deetu\midtermPi.txt midtermExam
```

**13. What does the command do?**

```
it created a text file named mt.txt containing the details of the present working directory.
it also created a text file named pr.txt and then added the directory listing of directories and files.
```



**14. What command did you use?**

```
sudo useradd dianatuquib
```



**15. What commands did you use?**

```
sudo mkhomedir_helper dianatuquib

```



**16. What commands did you use?**

```
sudo apt-get update
sudo apt-get install filezilla
```


