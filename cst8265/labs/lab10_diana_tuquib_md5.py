import os
import hashlib

def calculate_md5(file_name):
    """
    Calculate the MD5 hash of a given file.

    Parameters:
        file_name (str): The name of the file (without path) for which the MD5 hash should be calculated.

    Returns:
        str: The MD5 hash of the file in hexadecimal format.
    """
    # Get the current working directory where the Python app is located
    current_directory = os.getcwd()

    # Construct the full file path by joining the current directory and the file name
    file_path = os.path.join(current_directory, file_name)

    # Create an MD5 hash object
    md5_hash = hashlib.md5()

    # Open the file in binary read mode and process it in chunks
    with open(file_path, "rb") as file:
        while chunk := file.read(8192):
            # Update the MD5 hash with each chunk of data
            md5_hash.update(chunk)

    # Obtain the final MD5 hash as a hexadecimal string
    return md5_hash.hexdigest()

# Ask the user for the file name
file_name = input("Enter the file name: ")

try:
    # Calculate the MD5 hash of the specified file
    md5_hash = calculate_md5(file_name)
    print(f"The MD5 hash of {file_name} is: {md5_hash}")
except FileNotFoundError:
    print(f"Error: File '{file_name}' not found.")
except PermissionError:
    print(f"Error: Permission denied. Unable to read '{file_name}'.")
except Exception as e:
    print(f"An error occurred: {e}")
