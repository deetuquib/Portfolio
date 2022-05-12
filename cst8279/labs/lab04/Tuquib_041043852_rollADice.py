while True:

    # Prompting user for the number of faces
    while True:
        try:
            face = int(input("\nPlease enter your desired number of faces: [1 - 23]: "))
            assert 0 < face <= 23
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "The value you entered is out of range! Please pick a number from 1 to 23."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "The value you entered is invalid! Please pick a number from 1 to 23."
            )

    # Importing random integers
    import random

    # Rolling the dice
    print("\nYou chose: ", face)
    print("You rolled: ", random.randint(1, face))

    # Prompting user to continue or end
    resume = input(
        "\nIf you would like to start over, please type 'yes'. Otherwise, press any key to exit. "
    )
    if resume == "yes":
        continue
    else:
        break

print("\nThe end. Bye now!")

# Yay success! :-)
# Diana Jean

# Code source/s:
# Stack overflow: https://stackoverflow.com/questions/41832613/python-input-validation-how-to-limit-user-input-to-a-specific-range-of-integers
