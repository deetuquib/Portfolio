"""This application asks for the weight and the scores of the assignments, midterms, and finals.
    Then, it calculates the final grade and gives its letter grade equivalent. """

# Prompt the user for the weight of assignments.
# Note that this function will include call(s) to the input function.
# Keep prompting until the number is a float >= 0 and <= 1.
# Return the weight of assignments.
def get_weight_of_assignments():
    """This method asks for the weight of assignments."""

    return _get_input_float("Please enter the weight of assignments", 0, 1, 0.4)


# Prompt the user for the weight of midterms.
# Note that this function will include call(s) to the input function.
# Keep prompting until the number is a float >= 0 and <= 1.
# Return the weight of midterms.
def get_weight_of_midterms():
    """This method asks for the weight of midterms."""

    return _get_input_float("Please enter the weight of midterms", 0, 1, 0.35)


# Prompt the user for the weight of the finals.
# Note that this function will include call(s) to the input function.
# Keep prompting until the number is a float >= 0 and <= 1.
# Return the weight of finals.
def get_weight_of_finals():
    """This method asks for the weight of finals."""

    return _get_input_float("Please enter the weight of finals", 0, 1, 0.25)


# Return True if the sum of the 3 arguments is 1, otherwise return False.
# Assign the default values 0.4, 0.35, and 0.25 to weight_assignments, weight_midterms, and weight_finals, respectively.
def check_weights(weight_assignments=0.4, weight_midterms=0.35, weight_finals=0.25):
    """This function sums the the weight of the assignments, midterm, and finals.
    The total weight should be equal to 1. """

    return weight_assignments + weight_midterms + weight_finals == 1


def get_weights():
    """This function displays an error message if the sum of the assignments, midterm, and final is not equal to 1."""

    while True:
        weight_assignments = get_weight_of_assignments()
        weight_midterms = get_weight_of_midterms()
        weight_finals = get_weight_of_finals()

        if check_weights(weight_assignments, weight_midterms, weight_finals):
            return weight_assignments, weight_midterms, weight_finals

        print("Sum of your weights is not equal to 1.")


def get_average_assignments():
    """This function gets the average of assignments."""

    return _get_input_float("Please enter the average of your assignments", 0, 100)


def get_average_midterms():
    """This function gets the average of midterms."""

    total_tests = get_number_of_tests()
    sum_of_tests = 0
    for test_number in range(0, total_tests):
        sum_of_tests += get_test_grade(test_number + 1)

    return sum_of_tests / total_tests


# Prompt the user for the number of tests.
# Note that this function will include call(s) to the input function.
# Keep prompting until the number is an integer.
# The number of tests will have a maximum number of 5.
# Return the number of tests.
def get_number_of_tests():
    """This function asks for the total number of tests."""

    return _get_input_integer("Please enter the number of tests", 1, 5)


# Prompt the user for the number of tests.
# Note that this function will include call(s) to the input function.
# Keep prompting until the number is an integer.
# The number of tests will have a maximum number of 5.
# Return the number of tests.
def get_test_grade(test_number):
    """This function asks for the test grade."""

    return _get_input_float(f"Please enter the grade for test #{test_number} ", 0, 100)


def get_average_finals():
    """This function asks for the final grade."""

    return _get_input_float("Please enter the average of your finals", 0, 100)


# Calculate the numeric grade as specified in the course outline.
def calculate_numeric_grade(
    average_assignments,
    average_midterms,
    average_finals,
    weight_assignments,
    weight_midterms,
    weight_finals,
):
    """This function calculates the numeric grade."""

    return (
        (weight_assignments * average_assignments)
        + (weight_midterms * average_midterms)
        + (weight_finals * average_finals)
    )


# Convert the numeric grade to a letter according to the conversion table in the course outline.
def calculate_alpha_grade(grade_numeric):
    """This function takes the numeric grade and returns its equivalent letter grade."""

    if grade_numeric >= 90:
        return "A+"
    elif 85 <= grade_numeric < 89:
        return "A"
    elif 80 <= grade_numeric < 84:
        return "A-"
    elif 77 <= grade_numeric < 79:
        return "B+"
    elif 73 <= grade_numeric < 76:
        return "B"
    elif 70 <= grade_numeric < 72:
        return "B-"
    elif 67 <= grade_numeric < 69:
        return "C+"
    elif 63 <= grade_numeric < 66:
        return "C"
    elif 60 <= grade_numeric < 62:
        return "C-"
    else:
        return "F"


def _get_input_integer(
    initial_message, minimum_value=0, maximum_value=100, default_value=None
):
    """TODO: Add docstring."""

    while True:
        try:
            message = f"\n{initial_message}: [{minimum_value} - {maximum_value}]: "
            value = input(message)
            if value.strip() == "" and default_value is not None:
                value = default_value

            value = int(value)
            assert minimum_value <= value <= maximum_value

            return value
        except AssertionError:
            print("\nERROR: The value you entered is out of range!")
        except:
            print("\nERROR: The value you entered is invalid!")


def _get_input_float(
    initial_message, minimum_value=0, maximum_value=1, default_value=None
):
    """TODO: Add docstring."""

    while True:
        try:
            message = f"\n{initial_message}: [{minimum_value} - {maximum_value}]: "
            value = input(message)
            if value.strip() == "" and default_value is not None:
                value = default_value

            value = float(value)
            assert minimum_value <= value <= maximum_value

            return value
        except AssertionError:
            print("\nERROR: The value you entered is out of range!")
        except:
            print("\nERROR: The value you entered is invalid!")


# Main function.
def main():
    """TODO: Add docstring."""

    # Get the weight value of the assignments (call the appropriate function).
    # Get the weight value of tests (call the appropriate function).
    # Get the weight value of the final (call the appropriate function).
    # Check the sum of weight values is 1 (call the appropriate function).
    # Repeat the last four lines if not equal to 1.
    weight_assignments, weight_midterms, weight_finals = get_weights()
    print(
        f"\nWeights: assignments={weight_assignments}, midterms={weight_midterms}, and finals={weight_finals}"
    )

    # TODO: Get the average grade obtained on the assignments.
    # TODO: Validate the input as a float between 0 and 100.
    average_assignments = get_average_assignments()

    # TODO: Get the number of tests (call the appropriate function).
    # TODO: Prompt the user for each test grades and accumulate the value.
    # TODO: Validate the input as a float between 0 and 100.
    # TODO: Calculate the average test grade.
    average_midterms = get_average_midterms()

    # TODO: Prompt and get the final grade.
    # TODO: Validate the input as a float between 0 and 100.
    average_finals = get_average_finals()

    # TODO: Calculate and display the final numeric grade (call the appropriate function).
    # TODO: Calculate and display the final alphabetical grade (call the appropriate function).
    grade_numeric = calculate_numeric_grade(
        average_assignments,
        average_midterms,
        average_finals,
        weight_assignments,
        weight_midterms,
        weight_finals,
    )
    grade_alpha = calculate_alpha_grade(grade_numeric)

    print(
        f"Your numeric grade is {grade_numeric} and your alpha grade is {grade_alpha}."
    )


if __name__ == "__main__":
    main()
