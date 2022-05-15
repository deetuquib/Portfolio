using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class Lab2
    {
        static void Main(string[] args)
        {

            /*******************************************************************/
            /**                                                               **/
            /**                                                               **/
            /**    Student Name                :  Diana Jean C Tuquib         **/
            /**    EMail Address               :  tuqu0002@algonquinlive.com  **/
            /**    Student Number              :  041043852                   **/
            /**    Course Number               :  CST8253                     **/
            /**    Lab Section Number          :  301                         **/
            /**    Professor Name              :  Wei Gong                    **/
            /**    Assignment Name/Number/Date :  Lab 2 - Jan 17              **/
            /**    Optional Comments           :                              **/
            /**                                                               **/
            /**                                                               **/
            /*******************************************************************/

            string startOver = "y";

            // 1.  Loop for starting over
            while (startOver == "y")
            {
                // Create variables for use later
                string inputValue;
                int value = 0;

                int counter = 0;
                int maxValue = 0;
                int minValue = 0;
                double totalSum = 0;
                double totalAvg = 0;

                int oddCounter = 0;
                double oddSum = 0;
                double oddAvg = 0;

                int evenCounter = 0;
                double evenSum = 0;
                double evenAvg = 0;


                // 1.1.  Loop for inputing numbers
                while (true) {

                    // 1.1.1.  Prompt for user input
                    Console.Write("Please enter a number: ");
                    inputValue = Console.ReadLine();

                    // 1.1.2.  Loop for input checking (if blank)
                    if (inputValue == "")
                    {
                        if (counter == 0)
                        {
                            // 1.1.2.1 If input is blank for the first time
                            Console.Write("\n ERROR! Please input at least one number. \n");
                            break;
                        }
                        else
                        {
                            // 1.1.2.1.1  Display values

                            // 1.1.2.1.1.1  All values
                            Console.Write("\n TOTAL COUNT: " + counter);
                            Console.Write("\n      Sum: " + totalSum);
                            Console.Write("\n      Average: " + totalAvg);
                            Console.Write("\n      Max value: " + maxValue);
                            Console.Write("\n      Min value: " + minValue);

                            // 1.1.2.1.1.2  Odd values
                            Console.Write("\n\n ODD COUNT: " + oddCounter);
                            Console.Write("\n      Sum of odd values: " + oddSum);
                            Console.Write("\n      Average of odd values: " + oddAvg);

                            // 1.1.2.1.1.3  Even values
                            Console.Write("\n\n EVEN COUNT: " + evenCounter);
                            Console.Write("\n      Sum of even values: " + evenSum);
                            Console.Write("\n      Average of even values: " + evenAvg + "\n");

                            break;
                        };
                    } // End of loop 1.1.2
                    else
                    // 1.1.3.  If not blank
                    {
                        value = int.Parse(inputValue);

                        // 1.1.3.1  Count numbers
                        counter += 1;

                        // 1.1.3.2  Minimum and maximum numbers
                        if (counter == 1)
                        {
                            maxValue = value;
                            minValue = value;
                        }
                        else
                        {
                            // 1.1.3.2.1  Maximum value
                            if (maxValue < value)
                            {
                                maxValue = value;
                            }
                            // 1.1.3.2.1  Minimum value
                            else if (minValue > value)
                            {
                                minValue = value;
                            }
                        }

                        // 1.1.3.3  Odd and even numbers
                        if (value % 2 != 0)
                        // 1.1.3.3.1  If odd
                        {
                            oddCounter += 1;
                            oddSum += value;
                            oddAvg = oddSum / oddCounter;
                        }
                        else
                        // 1.1.3.3.2  If even
                        {
                            evenCounter += 1;
                            evenSum += value;
                            evenAvg = evenSum / evenCounter;
                        }

                        // 1.1.3.4 Total sum and average
                        totalSum += value;
                        totalAvg = totalSum / counter;

                    }

                }

                // 1.2.  Prompt for user input
                Console.Write("\n\n Would you like to continue? [y/n]: ");
                startOver = Console.ReadLine();

            }
        }
    }
}
