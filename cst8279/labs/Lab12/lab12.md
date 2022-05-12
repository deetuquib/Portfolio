The purpose of this lab is to interact with a mySql database via a python program.

1. In mysql, create a database called lab12.

2. Download the file lab12.sql and use it to populate the database lab 12. From the folder where you downloaded the file, start mysql then:
   `use lab 12;`
   `source lab12.sql;`

3. Using Pycharm, create a new Python project called lab12.

4. Install the mysql connector in the virtual environment. Look at the lecture from last week if you do not know how to do that.

5. Create a function `insertGrade` that receives 4 parameters, a `lastName`, a `firstName`, a `province` and a `grade`. The function then connects to the database lab12 and inserts the record.

6. Create a function `deleteGrade` that receives 4 parameters, a `lastName`, a `firstName`, a `province` and a `grade`. The function then connects to the database lab12 and deletes that record.

7. Create a function `displayGrade`  that receives 3 parameters, a `lastName`, a `firstName`, a `province`.Make sure your query uses the sql LIKE function. The function then connects to the database lab12 and returns a list of grades.

8. The 3 functions should make use of the function `readDbConfig` from week 11 sample program.

9. Write a python program that proposes the following options:

   	- Enter a grade
   	- Display a grade
   	- Delete a grade
   	- Exit

   For the display grade option, display the list of results as a html table, ie: generate the html code.

10. Upload your py file to brightspace.
