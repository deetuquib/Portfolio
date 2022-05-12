import random

while True:

    while True:
        try:
            facesOfDice = int(
                input("Please enter your desired number of faces: [1 - 23]: ")
            )
            assert 0 < facesOfDice <= 23
            break
        except AssertionError:
            print(
                "The value you entered is out of range. Please pick a number from 1 to 23."
            )

    # Importing random integers
    import random

    # Rolling the dice
    print("You rolled: ", random.randrange(1, facesOfDice + 1))

    # Prompting user to continue or end
    startOver = input(
        "If you would like to start over, please type 'yes'. Otherwise, press any key to exit. "
    )
    if startOver == "yes":
        continue
    else:
        break


# class CustomError(Exception):
#    pass
#
# while True:
#     try:
#        number1 = int(raw_input('Pick a number from 1-23: '))
#        if number1 not in range(1,23):
#          raise CustomError
#     except ValueError:
#             print("Numbers only!")
#         except CustomError:
#             print("Enter a number between 1-10!)
