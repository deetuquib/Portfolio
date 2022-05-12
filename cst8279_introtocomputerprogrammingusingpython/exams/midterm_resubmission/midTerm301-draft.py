# 1
# Prompts the user for the number of Tests
# Note that this function will include call(s) to the input function
# Keep prompting until the number is an integer. Each grade is in between 0 and 100..
# Returns the number of Tests
def getNumberOfTests():
    """This function prompts the user for an integer and returns the number of tests."""
    while True:
        try:
            # Prompting user for the number of tests
            numberOfTests = int(input("\nPlease enter the number of tests: [1 - 5]: "))
            assert 1 <= numberOfTests <= 5
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "ERROR: The value you entered is out of range! Please pick a number from 0 to 5."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "ERROR: The value you entered is invalid! Please pick a number from 0 to 5."
            )
    return numberOfTests


# 2
# Prompts the user for the weigth of Assignments
# Note that this function will include call(s) to the input function
# Keep prompting until the number is a float >= 0 and <= 1
# Returns the weight of assignments
def getWeightOfAssignments():
    """This function prompts the user for and returns the weight of the Assignments."""
    while True:
        try:
            # Prompting user for the weight of Assignments
            wOfAssign = float(
                input("\nPlease enter the weight of the Assignments: [0 - 1]: ") or 0.4
            )
            assert 0 <= wOfAssign <= 1
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "ERROR: The value you entered is out of range! Please pick a number from 0 to 1."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "ERROR: The value you entered is invalid! Please pick a number from 0 to 1."
            )
    return wOfAssign


# 3
# Prompts the user for the weigth of Midterms
# Note that this function will include call(s) to the input function
# Keep prompting until the number is a float >= 0 and <= 1
# Returns the weight of midterms
def getWeightOfMidTerms():
    """This function prompts the user for and returns the weight of the Midterms."""
    while True:
        try:
            # Prompting user for the weight of Midterms
            wOfMidTerms = float(
                input("\nPlease enter the weight of Midterms: [0 - 1]: ") or 0.35
            )
            assert 0 <= wOfMidTerms <= 1
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "ERROR: The value you entered is out of range! Please pick a number from 0 to 1."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "ERROR: The value you entered is invalid! Please pick a number from 0 to 1."
            )
    return wOfMidTerms


# 4
# Prompts the user for the weigth of the final
# Note that this function will include call(s) to the input function
# Keep prompting until the number is a float >= 0 and <= 1
# Returns the weight of final
def getWeightOfFinal():
    """This function prompts the user for and returns the weight of the Finals."""
    while True:
        try:
            # Prompting user for the weight of Finals
            wOfFinal = float(
                input("\nPlease enter the weight of Finals: [0 - 1]: ") or 0.25
            )
            assert 0 <= wOfFinal <= 1
            break
        # If the value is NOT within range
        except AssertionError:
            print(
                "ERROR: The value you entered is out of range! Please pick a number from 0 to 1."
            )
        # If the value is NOT a number
        except ValueError:
            print(
                "ERROR: The value you entered is invalid! Please pick a number from 1 to 1."
            )
    return wOfFinal


# 5
# returns True if the sum of the 3 arguments is 1, False otherwise
# Assign the default values 0.4 0.35 0.25 to wOfAssign, wOfMidtern and wOfFinal respectively
def checkWeights(wOfAssign, wOfMidTerm, wOfFinal):
    """checkWeights receives wAssign, wMidterm, and wOfFinal that returns true if the sum is 1, false otherwise"""
    return wOfAssign + wOfMidTerm + wOfFinal == 1


# 6
# calculate the numeric grade as specified in the course outline
def calculateNumericGrade(
    AvgAssignments, AvgTests, final, wOfAssign, wOfMidTerms, wOfFinal
):
    numericGrade = (
        (avgAssignments * wOfAssign) + (avgTests * wOfMidTerms) + (final * wOfFinal)
    )
    print(f"Your numeric grade is ", numericGrade)
    return numericGrade


# 7
# convert the numeric grade to a letter according to the conversion table
# in the course outline
def calculateAlphaGrade(numericGrade):
    if numericGrade >= 90:
        print("Your alphabetical grade is A+. ")
    elif 89 > numericGrade >= 85:
        print("Your alphabetical grade is A. ")
    elif 84 > numericGrade >= 80:
        print("Your alphabetical grade is A-. ")
    elif 79 > numericGrade >= 77:
        print("Your alphabetical grade is B+. ")
    elif 76 > numericGrade >= 73:
        print("Your alphabetical grade is B. ")
    elif 72 > numericGrade >= 70:
        print("Your alphabetical grade is B-. ")
    elif 69 > numericGrade >= 67:
        print("Your alphabetical grade is C+. ")
    elif 66 > numericGrade >= 63:
        print("Your alphabetical grade is C. ")
    elif 62 > numericGrade >= 60:
        print("Your alphabetical grade is C-. ")
    else:
        print("Your alphabetical grade is F. ")
    return


# 8
# Get the weight value of the assignments (call the appropriate function)
getWeightOfAssignments()
# Get the weight value of tests (call the appropriate function)
getWeightOfMidTerms()
# Get the weight value of the final (call the appropriate function)
getWeightOfFinal()
# Check the sum of weight values is 1 (call the appropriate function)
checkWeights(wOfAssign, wOfMidTerm, wOfFinal)

# 9
# Repeat the last four lines if not equal to 1


# 10
# Get the average grade obtained on the assignments
# Validate the input as a float between 0 and 100
"""This prompts the user for the average grade on the Assignments. """
while True:
    try:
        # Prompting user for the weight of Assignments
        avgAssignments = float(
            input("\nPlease enter the average grade of your Assignments: [0 - 100]: ")
        )
        assert 0 <= avgAssignments <= 100
        break
    # If the value is NOT within range
    except AssertionError:
        print(
            "ERROR: The value you entered is out of range! Please pick a number from 0 to 100."
        )
    # If the value is NOT a number
    except ValueError:
        print(
            "ERROR: The value you entered is invalid! Please pick a number from 0 to 100."
        )


# 11
# Get the number of tests (call the appropriate function)
getNumberOfTests()
# Prompt the user for each test grades and accumulate the value
# Validate the input as a float between 0 and 100
# Calculate the average test grade.


# 12
# Prompt and get the final grade
# Validate the input as a float between 0 and 100
"""This prompts the user for the average grade on the Finals. """
while True:
    try:
        # Prompting user for the weight of Assignments
        final = float(
            input("\nPlease enter the average grade of your Finals: [0 - 100]: ")
        )
        assert 0 <= final <= 100
        break
    # If the value is NOT within range
    except AssertionError:
        print(
            "ERROR: The value you entered is out of range! Please pick a number from 0 to 100."
        )
    # If the value is NOT a number
    except ValueError:
        print(
            "ERROR: The value you entered is invalid! Please pick a number from 0 to 100."
        )


# 13
# Calculate and display the final numeric grade (call the appropriate function)
def calculateNumericGrade(
    avgAssignments, avgTests, final, wOfAssign, wOfMidTerms, wOfFinal
):
    numericGrade = (
        (avgAssignments * wOfAssign) + (avgTests * wOfMidTerms) + (final * wOfFinal)
    )
    print("Your numeric grade is ", numericGrade)
    return numericGrade


# 14
# Calculate and display the final alphabetical grade (call the appropriate function)
calculateAlphaGrade(numericGrade)
