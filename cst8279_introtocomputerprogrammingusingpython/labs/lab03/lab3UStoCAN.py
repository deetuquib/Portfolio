# Taking the exchange rate input from the user
exchangeRate = float(
    input("\n\nPlease enter the current exchange rate from USD to CAD: ")
)

# Taking the amount input from the user
usDollars = float(input("\nPlease input the amount you want to convert (in USD): "))

# Calculating US Dollars to CA Dollars
caDollars = usDollars * exchangeRate

print("\n%0.2f US$ is equal to %0.2f CA$" % (usDollars, caDollars))

# Yay success! :-)
