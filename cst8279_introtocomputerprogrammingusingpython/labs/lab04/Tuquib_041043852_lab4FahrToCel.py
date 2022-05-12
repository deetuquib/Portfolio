while True:

    # Taking the Fahrenheit input from the user
    while True:
        try:
            tempInFahr = float(input("\nPlease input the temperature in Fahrenheit: "))
            break
        except:
            print("Invalid temperature! Please try again. ")

    # Converting the temperature from Fahrenheit to Celsius
    tempInCel = (tempInFahr - 32) * 5 / 9
    print("\n%0.1f Fahrenheit is %0.1f degrees Celsius." % (tempInFahr, tempInCel))

    # Prompting user to continue or end
    startOver = input(
        "\nIf you would like to start over, please type 'yes'. Otherwise, type any key to exit. "
    )
    if startOver == "yes":
        continue
    else:
        break

print("\nThe end. Bye now!")

# Yay success! :-)
# Diana Jean
