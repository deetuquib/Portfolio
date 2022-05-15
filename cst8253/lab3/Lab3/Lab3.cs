using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*******************************************************************/
/**                                                               **/
/**                                                               **/
/**    Student Name                :  Diana Jean C Tuquib         **/
/**    EMail Address               :  tuqu0002@algonquinlive.com  **/
/**    Student Number              :  041043852                   **/
/**    Course Number               :  CST8253                     **/
/**    Lab Section Number          :  301                         **/
/**    Professor Name              :  Wei Gong                    **/
/**    Assignment Name/Number/Date :  Lab 3 - Jan 27              **/
/**    Optional Comments           :                              **/
/**                                                               **/
/**                                                               **/
/*******************************************************************/

namespace Lab3
{
    internal class Lab3
    {
        static int[] intArray = {17,  166,  288,  324,  531,  792,  946,  157,  276,  441, 533, 355, 228, 879, 100, 421, 23, 490, 259, 227,
                                 216, 317, 161, 4, 352, 463, 420, 513, 194, 299, 25, 32, 11, 943, 748, 336, 973, 483, 897, 396,
                                 10, 42, 334, 744, 945, 97, 47, 835, 269, 480, 651, 725, 953, 677, 112, 265, 28, 358, 119, 784,
                                 220, 62, 216, 364, 256, 117, 867, 968, 749, 586, 371, 221, 437, 374, 575, 669, 354, 678, 314, 450,
                                 808, 182, 138, 360, 585, 970, 787, 3, 889, 418, 191, 36, 193, 629, 295, 840, 339, 181, 230, 150 };


        static void Main(string[] args)
        {
            // Add your code here to complete the steps given in the section 4 of the lab document
            string searchAgain = "y";


            // 4a. On start, it outputs the elements of the original unsorted array intArray to the console window.
            Console.WriteLine("\nOriginal Array: ");
            PrintArray(intArray);

            // 4b. It then copies the elements in the array to a new array 
            int[] newIntArray = new int[intArray.Length];
            intArray.CopyTo(newIntArray, 0);

            // 4c. It calls the method BubbleSort to sort the new array.
            // 4d. It outputs the sorted array elements to the console window.
            Console.WriteLine("\n\nNumber of swaps: " + BubbleSort(newIntArray) + "\nSorted array: ");
            PrintArray(newIntArray);

            // 4e. It prompts the user to enter an integer.
            do
            {
                Console.WriteLine("\n\nEnter an integer to search: ");
                int intSearch = Convert.ToInt32(Console.ReadLine());

                // 4f. It calls the method LinearSearch to search the entered integer in the original unsorted array intArray.
                Console.WriteLine("\nLinear Search");
                int needleIndex = LinearSearch(intArray, intSearch, out int numOfLinearComparison);
                if (needleIndex == -1)
                {
                    Console.WriteLine("Linear searches made: " + numOfLinearComparison +
                        "\nLinear search result for " + intSearch + ": NOT found in unsorted array");
                }
                else
                {
                    Console.WriteLine("Linear searches made: " + numOfLinearComparison +
                        "\nLinear search result for " + intSearch + ": Found in unsorted array at index[" + needleIndex + "]");
                }

                // 4g. It calls the method BinarySearch to search the entered integer in the sorted array.
                Console.WriteLine("\nBinary Search");
                needleIndex = BinarySearch(newIntArray, intSearch, out int numOfBinaryComparison);
                if (needleIndex == -1)
                {
                    Console.WriteLine("Binary searches made: " + numOfBinaryComparison +
                        "\nBinary search result for " + intSearch + ": NOT found in sorted array");
                }
                else
                {
                    Console.WriteLine("Binary searches made: " + numOfBinaryComparison +
                        "\nBinary search result for " + intSearch + ": Found in sorted array at index [" + needleIndex + "]");
                }

                // 4h. It asks the user whether he/she wants to search another integer.
                Console.WriteLine("\n\nWould you like to search for another integer[y/n]? ");
                searchAgain = Console.ReadLine();

                // 4j. If the user answers N, the program terminates.
                if (searchAgain == "n")
                {
                    Environment.Exit(-1);
                }

                // 4i. If the user answers Y, it loops back to step e to repeat steps e to h again.
            } while (searchAgain == "y");
                        
            //Console.ReadKey();
        }

        // This method returns the index of a given needle (an int) in the haystack (an int array)
        // by using linear search. It also returns the value of the number of comparison used to 
        // find the given niddle through the reference parameter numOfComparison.
        static int LinearSearch(int[] haystack, int needle, out int numOfComparison)
        {
            numOfComparison = 0;
            int needleIndex = -1;

            // Add your code here searching for the niddle in the haystack.
            // int haystackLength = haystack.Length;
            for (int i = 0; i < haystack.Length; i++)
            {
                numOfComparison++;
                if (haystack[i] == needle)
                {
                    return i;
                }
            }
            return needleIndex;
        }


        static int BubbleSort(int[] arr)
        {
            int numOfSwaps = 0;

            // Add your code here to implement the bubble sort to sort the integer array arr.
            for (int i = 0; i < arr.Length - 2; i++)
            {
                for (int j = 0; j <= arr.Length - 2; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int x = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = x;
                        numOfSwaps++;

                    }
                }
            }


            return numOfSwaps;
        }

        // This method returns the index of a given needdle (an int) in the haystack (an int array)
        // by using binary search. It also returns the value of the number of comparison used to 
        // find the given needle through the reference parameter numOfComparison.

        static int BinarySearch(int[] haystack, int needle, out int numOfComparison)
        {
            numOfComparison = 0;
            int needleIndex = -1;

            // Add your code here to implement the binary search to find the needle in the haystack.
            int minInt = 0;
            int maxInt = haystack.Length - 1;
            while (minInt <= maxInt)
            {
                numOfComparison++;
                int mid = (minInt + maxInt) / 2;
                if (needle == haystack[mid])
                {
                    needleIndex = mid;
                    break;
                }
                else if (needle < haystack[mid])
                {
                    maxInt= mid - 1;
                }
                else
                {
                    minInt = mid + 1;
                }
            }

            return needleIndex;
        }

        // This method has been fully implemented. Just use it to print an integer array to the console.
        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    Console.Write("{0}, ", arr[i]);
                }
                else
                {
                    Console.Write("{0} ", arr[i]);
                }
            }
            Console.WriteLine();
        }

    }
}


/* Reference:
** https://www.geeksforgeeks.org/bubble-sort/
** https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1 */
