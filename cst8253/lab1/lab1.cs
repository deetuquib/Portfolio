using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Lab1
    {
        static void Main(string[] args)
        {
            // Create a string variable for use later
            string name;

            // Display a prompt to the user
            Console.Write("What is your name?");

            // Capture the user's response
            name = Console.ReadLine();

            // Display a string literal combined with the value of the string variable
            Console.Write("Hello " + name + "\n");

            // Waits for the user to press a key
            Console.Write("Thank you for running my first lab! Press any key to end the application.");
            // Allows us to read what was displayed
            Console.Read();
        }
    }
}
