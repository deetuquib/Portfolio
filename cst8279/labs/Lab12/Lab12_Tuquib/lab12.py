from mysql.connector import MySQLConnection, Error
from mySqlDbConfig import readDbConfig


def queryFetchone(firstName):
    try:
        dbconfig = readDbConfig()
        conn = MySQLConnection(**dbconfig)
        cursor = conn.cursor()
        cursor.execute("""SELECT * FROM grades WHERE FName LIKE '%s%%'""" % firstName)
        row = cursor.fetchone()

        while row is not None:
            print(row)
            row = cursor.fetchone()

    except Error as e:
        print(e)

    finally:
        cursor.close()
        conn.close()


def insertGrade(firstName, lastName, province, grade):
    try:
        dbconfig = readDbConfig()
        conn = MySQLConnection(**dbconfig)
        cursor = conn.cursor()
        cursor.execute("""INSERT INTO grades(FName, LName, Province, Grade) VALUES (%s, %s, %s, %s)""",
                       (firstName, lastName, province, grade))

        row = cursor.fetchone()
        conn.commit()

        print(f"Added: {firstName} {lastName} from {province} with a grade of {grade}.\n")

        while row is not None:
            print(row)
            row = cursor.fetchone()

    except Error as e:
        print(e)

    finally:
        cursor.close()
        conn.close()


def deleteGrade(firstName, lastName, province, grade):
    try:
        dbconfig = readDbConfig()
        conn = MySQLConnection(**dbconfig)
        cursor = conn.cursor()
        cursor.execute(
            """DELETE FROM grades WHERE FName LIKE (%s) and LName LIKE (%s) and Province LIKE (%s) and Grade LIKE (%s)""",
            (firstName, lastName, province, grade))

        row = cursor.fetchone()
        conn.commit()

        print(f"Deleted: {firstName} {lastName} from {province} with a grade of {grade}.\n")

        while row is not None:
            print(row)
            row = cursor.fetchone()

    except Error as e:
        print(e)

    finally:
        cursor.close()
        conn.close()


def displayGrade(firstName, lastName, province):
    try:
        dbconfig = readDbConfig()
        conn = MySQLConnection(**dbconfig)
        cursor = conn.cursor()
        cursor.execute("""SELECT * FROM grades WHERE FName LIKE '%s%%'""" % firstName)
        row = cursor.fetchone()
        print("\n<table border='1'>"
              "<tr><td>First Name</td><td>Last Name</td><td>Province</td><td>Grade</td></tr>")
        while row is not None:
            print("<tr><td>{}</td><td>{}</td><td>{}</td><td>{}</td></tr>".format(row[0], row[1], row[2], row[3]))
            row = cursor.fetchone()
        print("</table>")

    except Error as e:
        print(e)

    finally:
        cursor.close()
        conn.close()


if __name__ == '__main__':
    helper = """
Please choose an option:

    1 - Enter a grade
    2 - Delete a grade
    3 - Display a grade
    4 - Exit.

    """

    print("Welcome!")
    while True:
        try:
            choice = int(input(helper))

            if choice == 1:
                firstName = input("Please enter the student's First Name: ")
                lastName = input("Please enter the student's Last Name: ")
                province = input("Please enter the student's Province: ")
                grade = input("Please enter the student's grade: ")
                insertGrade(firstName, lastName, province, grade)
                queryFetchone(firstName)

            elif choice == 2:
                firstName = input("Please enter the student's First Name: ")
                lastName = input("Please enter the student's Last Name: ")
                province = input("Please enter the student's Province: ")
                grade = input("Please enter the student's grade: ")
                deleteGrade(firstName, lastName, province, grade)
                queryFetchone(firstName)

            elif choice == 3:
                firstName = input("Please enter the student's First Name: ")
                lastName = input("Please enter the student's Last Name: ")
                province = input("Please enter the student's Province: ")
                displayGrade(firstName, lastName, province)

            elif choice == 4:
                exit()

            else:
                raise ValueError

        except ValueError:
            print("Please choose from 1-4.")
            print(helper)

