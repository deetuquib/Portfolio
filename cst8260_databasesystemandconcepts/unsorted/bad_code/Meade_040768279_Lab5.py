import random


def printOneLine():
    spaces = int(
        input("Enter the number of spaces you would like to print on either side:")
    )
    char = input("Enter the character you would like to print between the spaces:")
    i = 0

    while i < spaces:
        print(" ", end="")
        i += 1

    print(char, end="")

    while i < (spaces * 2):
        print(" ", end="")
        i += 1
    print("")


def isOdd():
    number = int(input("Enter an integer to see if it is an odd number: "))

    if number % 2 == 0:
        print("False")
    else:
        print("True")


def rollAdice():
    sides = int(input("Enter the number of sides on the dice: "))
    print("You rolled a ", random.randint(1, sides))


def xMasTree():
    wide = int(
        input(
            "How wide would you like the base of the tree to be? Please enter an odd integer: "
        )
    )
    i = 0
    numberOfCharacters = 1
    line = 0
    writeChar = 0

    while wide % 2 == 0:
        print("Odd integers only.")
        wide = int(input("Please enter an odd integer: "))

    character = input("What character would you like to use for your tree? ")

    while numberOfCharacters <= wide:
        while i < ((wide - 1) / 2) - line:
            print(" ", end="")
            i += 1

        while writeChar < numberOfCharacters:
            print(character, end="")
            writeChar += 1

        while i < (wide - 1) - line:
            print(" ", end="")
            i += 1
        numberOfCharacters += 2
        line += 1
        i = 0
        writeChar = 0
        print("")


def functionIndex():
    print(
        "Hello! Welcome to The Flourish of Fantastical Functions. Please select one of the following functions to run."
    )
    print("[1] to test rollAdice")
    print("[2] to test printOneLine")
    print("[3] to test isOdd")
    print("[4] to test xMasTree")
    print("[5] to exit")

    while True:
        try:
            option = int(input("Which function would you like to run? "))
            if 1 <= option <= 5:
                break
            else:
                print("Invalid input.")
                continue
        except:
            print("Invalid input.")

    while option == 1:
        rollAdice()
        while True:
            try:
                option = int(input("Which function would you like to run? "))
                if 1 <= option <= 5:
                    break
                else:
                    print("Invalid input.")
                    continue
            except:
                print("Invalid input.")

    while option == 2:
        printOneLine()
        while True:
            try:
                option = int(input("Which function would you like to run? "))
                if 1 <= option <= 5:
                    break
                else:
                    print("Invalid input.")
                    continue
            except:
                print("Invalid input.")

    while option == 3:
        isOdd()
        while True:
            try:
                option = int(input("Which function would you like to run? "))
                if 1 <= option <= 5:
                    break
                else:
                    print("Invalid input.")
                    continue
            except:
                print("Invalid input.")

    while option == 4:
        xMasTree()
        while True:
            try:
                option = int(input("Which function would you like to run? "))
                if 1 <= option <= 5:
                    break
                else:
                    print("Invalid input.")
                    continue
            except:
                print("Invalid input.")

    while option == 5:
        print(
            "Thank you for using The Flourish of Fantastical Functions! See you next time!"
        )
        break


functionIndex()
