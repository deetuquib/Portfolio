# Importing pi
from math import pi

# Taking the radius input from the user
radius = float(input("\n\nPlease input the radius of the circle: "))

# Calculating the area of the circle
area = pi * radius ** 2

print(
    "\nThe area of the circle with the radius %.1f is equal to %.1f." % (radius, area)
)

# Yay success! :-)
