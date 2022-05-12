# Taking the Fahrenheit input from the user
tempInFahr = float(input("\n\nPlease input the temperature in Fahrenheit: "))

# Converting the temperature from Fahrenheit to Celsius
tempInCel = (tempInFahr - 32) * 5 / 9

print("\n%0.1f in Fahrenheit is %0.1f degrees Celsius." % (tempInFahr, tempInCel))

# Yay success! :-)
