while True:

    # Importing pi
    from math import pi

    # Taking the radius input from the user
    while True:
        try:
            radius = float(input("\nPlease input the radius of the circle: "))
            break
        except:
            print("Invalid radius! Please try again. ")

    # Calculating the area of the circle
    area = pi * radius ** 2
    print(
        "\nThe area of the circle with the radius %.1f is equal to %.1f."
        % (radius, area)
    )

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
