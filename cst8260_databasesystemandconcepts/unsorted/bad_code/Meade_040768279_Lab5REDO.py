import random


def rollAdice(s):
    result = random.randint(1, s)
    return result


def printOneLine(s, c):
    spaces = s * " "
    print(spaces + c + spaces)


def isOdd(number):
    if number % 2 == 0:
        return False
    else:
        return True


def xMasTree(w, c):
    spaces = (w - 1) / 2
    spaces = int(spaces)
    prnt = c
    i = 0
    while i <= (w - 1) / 2:
        printOneLine(spaces, c)
        spaces -= 1
        i += 1
        c = prnt + (prnt * (i * 2))


##################################


def driver():
    print("Hello! Please select one of the following functions to run.")
    print("[1] to test rollAdice")
    print("[2] to test printOneLine")
    print("[3] to test isOdd")
    print("[4] to test xMasTree")
    print("[5] to exit")
    while True:
        try:
            option = int(input("Select a program to run. "))
            if 1 <= option <= 5:
                if option == 1:
                    sides = int(
                        input(
                            "Enter the number of sides on the die you would like to roll: "
                        )
                    )
                    print(rollAdice(sides))

                elif option == 2:
                    spaces = int(
                        input(
                            "Enter the number of spaces you would like to print on either side: "
                        )
                    )
                    char = input(
                        "Enter the character you would like to print between the spaces: "
                    )
                    printOneLine(spaces, char)

                elif option == 3:
                    number = int(input("Enter a number to check if it is odd: "))
                    print(isOdd(number))

                elif option == 4:
                    width = int(input("Enter the width of your christmas tree base: "))
                    isOdd(width)
                    while not isOdd(width):
                        print("Invalid input!!!")
                        width = int(
                            input("Enter the width of your christmas tree base: ")
                        )
                        isOdd(width)

                    ornament = input(
                        "Enter the character you would like use for your christmas tree: "
                    )
                    xMasTree(width, ornament)

                elif option == 5:
                    print("C U L8R")
                    break
        except:
            print("Invalid input!!!")


driver()
