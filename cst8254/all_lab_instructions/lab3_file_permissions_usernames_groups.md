## Lab3: File and Folder Permissions, creating users

### **Objectives**

To manage permission rights for users on files and folders. To use python to create administrative scripts.

**Tasks to be completed**

- The creation of various files and folders.
- Setting permissions for users on files and folders (via Terminal window).
- Logging in as a user to test the file and folder permissions.
- Use python to create typical admin scripts.

### Task 1: The creation of various files and folders

This lab is to be done on the raspberry pi.

1. Using `mkdir`, in the home folder `/home/pi/` create a folder then in the folder `/home/pi/lab3` then in the folder `/home/pi/lab3`, create a folder `folder1`
2. Using `nano`, create `file1-1.txt` in the home folder `/home/pi/lab3`. File content is `"This is file1-1"`
3. Repeat step 2 to create a file `file1-2.txt`. File content is `"This is file 1-2"` then move that file to `folder1`
4. Repeat step 2 to create a file `file1-3.txt`. File content is `"This is file 1-3"` then move that file to `folder1`
5. Using `mkdir`, in the folder `/home/pi/lab3`, create a folder `folder2` then create `file2-1.txt`, `file2-2.txt` and `file2-3.txt` in `folder2`.

### Task 2: Setting permissions for users on files and folders

- use `cd ~`to move back to the home folder.

- To view the permissions of the directories and files in your home folder, type in `ls -l`

- To change to the `lab3/folder1` directory, type in `cd lab3/folder1`

- Return one folder up by typing in `cd ..`

- To change the Owner, Group and Other permissions of `file1-1.txt` to `-w-` `rwx` `r--` , type in three separate commands (one for the Owner (u), one for the Group (g), and one for Other (o):

  ```
  chmod u=w file1-1.txt
  chmod g=rwx file1-1.txt
  chmod o=r file1-1.txt
  ```

- Keeping in mind that the binary equivalent value for the permissions is as follows:

  ```
  r=4
  w=2
  x=1
  ```

- Then the equivalent command, in numerical format, would be `chmod 274 file1-1.txt`

  


### Task 3: Checking permissions

- use `cd ~`to move back to the home folder.

- On your pi and using `useradd` and `groupadd`, create 4 users and 3 groups according to the following group membership.

- On your pi and using `groupadd`, create a group `cst8254`.

  **Which command did you use?**

- Check the users are created in the `passwd` file.

  **Where is the file located?**

- Check the groups are created in the `group` file.

  **Where is the file located?**

- Change the passwords of all the users created to `password`.

  **For iawd1, which command did you use?**
  
- To change the File owner and Group owner of `file1-1.txt`, type in `chown mizonj:group1 file1-1.txt` (the File owner will be `mizonj` and the Group owner will be `group1`)

| **User** | **Group Member**                |
| -------- | ------------------------------- |
| `iawd1`  | `group1 group3 sudo root iawd1` |
| `iawd2`  | `group2 group3 root iawd2`      |
| `iawd3`  | `group3 group1 root iawd3`      |
| `mizonj` | `mizonj root`                   |

​	**What are the commands you used for `iawd3`**

- Using `sudo` create the following folders: `home/iawd1`, `home/iawd2`,`home/iawd3`,`home/mizonj`

  **What are the default permissions, owner and group memberhip of `iawd1`?**

- Using `sudo` have the 4 folders `home/iawd1`, `home/iawd2`, `home/iawd3`, `home/mizonj` owned by `iawd1`, `iawd2`, `iawd3` and `mizonj` respectively.

  **What command did you use for `iawd1`?**

- Using the table below, adjust the Owner, Group Owner and Permissions of the files you created in Task 1, use the octal values.

| **FileName**                        | **File owner** | **Group owner** | **Owner Permission** | **Group Permission** | **Other Permission** |
| :---------------------------------- | -------------- | --------------- | -------------------- | -------------------- | -------------------- |
| `/home/pi/lab3/file1-1.txt`         | `Pi`           | `pi`            | `RW`                 | `R`                  | `R`                  |
| `/home/pi/lab3/folder1/file1-2.txt` | `iawd1`        | `group2`        | `RWX`                | `RW`                 | `X`                  |
| `/home/pi/lab3/folder1/file1-3.txt` | `iawd3`        | `group3`        | `R`                  | `W`                  | `RW`                 |
| `/home/pi/lab3/folder2/file2-1.txt` | `iawd2`        | `group1`        | `W`                  | `RWX`                | `R`                  |
| `/home/pi/lab3/folder2/file2-2.txt` | `iawd3`        | `group2`        | `RX`                 | `RW`                 | `RWX`                |
| `/home/pi/lab3/folder2/file2-3.txt` | `iawd3`        | `group3`        | `X`                  | `W`                  | `R`                  |

**What are the commands you used for the file file2-1.txt?**



### Task 4: Checking Files and Folders permissions

1. issue the following commands:

   `cd ~`

   `cd lab3`

   `sudo chmod 774 folder1`

   `sudo chmod 774 folder2`

   `sudo chown pi:group1 folder1`

   `sudo chown pi:group3 folder2`

2. Logout

3. Log on your Pi as `iawd1` using `ssh`

4. Go to `home/pi/lab3`

   **Can you edit /home/pi/lab3/file1-1.txt using nano?**

   **Can you modify it and save it?**

   **Explain why.**

5. Go to `home/pi/lab3/folder1`

   **Can you edit /home/pi/lab3/desktop1/file1-3.txt using nano?**

   **Explain why.**

6. Verify the permissions using various examples

7. Repeat steps 4 to 5 with users `iawd2` and `iawd3`

### Task 5

Use the python script `genlist.py` to generate a file `usernames.txt` of 20 usernames. You will need to change the value of a variable in the code.

### Task 6

Write a python function **`createUser(username)`**:

- This function receives a username, a string of characters.
- The funtion first creates an encrypted password using the function **`crypt`** from module **`crypt`**.
- Using the **`os.system`** function, the function then adds the user `username` by calling the function **`useradd`**
  - the `useradd` function has some options, the one to use:
    - -s to forcr the use of the **`/bin/bash`** shell for the created user
    - -d to create the home folder **`/home/username`**
  - Example of **`useradd`** command:
    - **`sudo useradd -p 22ChHEI62UiCA -s /bin/bash -d /home/txcn2147 -m -c "txcn2147" txcn2147`**
    - The **`-m`** flag is used to create the home folder
    - The **`-c`** field creates the GECO field (Google it :)

### Task 7

Write a python program `lab3.py` that:

- Open the file`usernames.txt`  in **`read`** mode
- Create a user account for each line of the file by calling the `createUser` function
- Change ownership of the **`/home/username`** folder to **`username:username`**
- Execute the **`chown`** function using the **`os.system`** function
- Execute the **`usermod`** function using the **`os.system`** function to add the username to the group **`cst8254`**



### Task 8: Submitting your Lab

1. Log on your Pi as `pi` using `SSH`

2. Issue the following commands

   ```
   tree lab3>lab3-1.txt
   cat /etc/passwd>lab3-2.txt
   cat /etc/group>lab3-3.txt
   ls -als /home>lab3-4.txt
   ls -als lab3/folder2>>lab3-4.txt
   ls -als lab3/folder1>>lab3-4.txt
   ```

3. Upload this file with your typed answers, the four text files created in step 2 and the program `lab3.py` to Brightspace