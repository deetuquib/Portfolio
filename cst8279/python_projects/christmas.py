from random import randint


def rollAdice(numOfFaces):
    """rollAdice returns the rolled value. Assume numOfFaces is a positive integer."""
    return randint(1, numOfFaces)


def printOneLine(numOfSpaces, charToPrint):
    """printOneLine prints a single line."""
    padding = numOfSpaces * " "
    print(f"{padding}{charToPrint}{padding}")


def isOdd(number):
    """isOdd receives an integer value `number` that returns true if the value is odd, false otherwise."""
    return number % 2 != 0


def xMasTree(finalCharCount, charToPrint):
    """xMasTree prints a pyramid of `charToPrint` values, with `finalCharCount` as the base."""
    for charToPrintCount in range(1, finalCharCount + 1, 2):
        padding = (finalCharCount - charToPrintCount) // 2
        printOneLine(padding, charToPrint * charToPrintCount)


if __name__ == "__main__":
    xMasTree(7, "x")
