import christmas


# Option 1
"""This option tests the rollAdice function"""


def testRollADice():
    while True:
        try:
            # Prompting user for the number of faces
            numberOfFaces = int(
                input("\nPlease enter your desired number of faces: [1 - 23]: ")
            )
            assert 0 < numberOfFaces <= 23
            roll = christmas.rollAdice(numberOfFaces)
            print(f"\nYou chose: {numberOfFaces}")
            print(f"You rolled: {roll}")
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "ERROR: The value you entered is out of range! Please pick a number from 1 to 23."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "ERROR: The value you entered is invalid! Please pick a number from 1 to 23."
            )


# Option 2
"""This option tests the printOneLine function"""


def testPrintOneLine():
    # numOfSpaces must be a positive number.
    numOfSpaces = abs(int(input("Number of spaces: ")))
    # charToPrint must be 1 character only.
    charToPrint = input("Character to print: ")
    if len(charToPrint) == 1:
        christmas.printOneLine(numOfSpaces, charToPrint)
    else:
        print("ERROR: Please input 1 character only.\n")
        testPrintOneLine()


# Option 3
"""This option tests the isOdd function"""


def testIsOdd():
    # Making sure the user inputs an integer
    while True:
        try:
            number = int(input("Enter a number: "))
            print(f"{number} is {'odd' if christmas.isOdd(number) else 'even'}")
            break
        except ValueError:
            print("ERROR: Please input a number.\n")


# Option 4
"""This option tests the xMasTree function"""


def testXMasTree():
    # Making sure the user inputs an odd number
    while True:
        try:
            # Making sure the user inputs only odd numbers
            finalCharCount = int(
                input("Enter the total number of characters at the base: ")
            )
            if finalCharCount % 2 != 0:
                # Making sure the user inputs only 1 character
                charToPrint = input("Enter your preferred character: ")
                if len(charToPrint) == 1:
                    christmas.xMasTree(finalCharCount, charToPrint)
                    print("Merry Christmas!\n")
                    break
                else:
                    print("ERROR: Please input 1 character only. Try again. \n")
                    testXMasTree()
                    break
            else:
                print("ERROR: Please input an odd number. Try again.\n")
                testXMasTree()
                break
        except ValueError:
            print("ERROR: Please input an odd number\n")


# Option 5
"""This option exits the application"""


if __name__ == "__main__":
    helper = """
Please choose an option:

   1 - test the `rollAdice` function
   2 - test the `printOneLine` function
   3 - test the `isOdd` function
   4 - test the `xMasTree` function
   5 - exit application

"""

    print("Welcome!")
    while True:
        try:
            choice = int(input(helper))

            if choice == 1:
                testRollADice()
            elif choice == 2:
                testPrintOneLine()
            elif choice == 3:
                testIsOdd()
            elif choice == 4:
                testXMasTree()
            elif choice == 5:
                exit()
            else:
                raise ValueError
        except ValueError:
            print("Please choose from 1-5.")
            print(helper)


# Diana Jean
