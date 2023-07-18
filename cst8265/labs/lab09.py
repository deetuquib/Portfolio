def caesar_cipher():
    """
    Asks the user to input the key and the message to be encrypted.
    Keys should only be 0-25 integers.
    Application keeps prompting for key until user inputs integers from 0 to 25 only.
    """
    while True:
        try:
            # Prompt the user for the shift key
            key = int(input("Enter a shift key for Caesar Cipher (0-25): "))
            if key < 0 or key > 25:
                print("Your key should be between 0 and 25. Please try again.")
                continue

            # Prompt the user for the message to encrypt/decrypt
            message = input("Enter your message: ")

            # Encrypt the message using the Caesar Cipher algorithm
            # Convert each letter to upper case
            encrypted_message = encrypt_message(message.upper(), key)
            print("The encrypted message is:", encrypted_message)

            # Decrypt the encrypted message
            decrypted_message = decrypt_message(encrypted_message, key)
            print("The decrypted message is:", decrypted_message)

        except ValueError:
            # Prompt the user to enter a valid shift key
            print("Invalid input. Please enter a valid shift key.")
            continue


def encrypt_message(message, key):
    """
    Encrypts the given message using the Caesar Cipher algorithm.
    Each alphabetic character is shifted by the specified key.
    """
    encrypted = ""
    # For loop for each character in the message
    for character in message:
        if character.isalpha():
            encrypted += chr((ord(character) - ord('A') + key) % 26 + ord('A'))
        else:
            encrypted += character
    return encrypted


def decrypt_message(encrypted_message, key):
    """
    Decrypts the given encrypted message using the Caesar Cipher algorithm.
    Each alphabetic character is shifted back by the specified key.
    """
    decrypted = ""
    # For loop for each character in the message
    for character in encrypted_message:
        if character.isalpha():
            decrypted += chr((ord(character) - ord('A') - key) % 26 + ord('A'))
        else:
            decrypted += character
    return decrypted


# Start the Caesar Cipher program
caesar_cipher()
