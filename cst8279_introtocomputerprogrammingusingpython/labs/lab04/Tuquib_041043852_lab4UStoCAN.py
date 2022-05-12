while True:

    # Taking the amount input from the user
    while True:
        try:
            usDollars = float(
                input("\nPlease input the amount you want to convert (in USD): ")
            )
            break
        except:
            print("Not a valid amount!")

    # Taking the exchange rate input from the user
    while True:
        try:
            # Setting the default exchangeRate value to 1.27
            exchangeRate = float(
                input("\nPlease enter the current exchange rate from USD to CAD: ")
                or 1.27
            )
            break
        except:
            print("Not a valid exchange rate!")

    # Calculating US Dollars to CA Dollars
    caDollars = usDollars * exchangeRate

    print("\n%0.2f US$ is equal to %0.2f CA$" % (usDollars, caDollars))

    # Prompting user to continue or end
    resume = input(
        "\nIf you would like to start over, please type 'yes'. Otherwise, type any key to exit. "
    )
    if resume == "yes":
        continue
    else:
        break

print("\nThe end. Bye now!")


# Yay success! :-)
# Diana Jean
