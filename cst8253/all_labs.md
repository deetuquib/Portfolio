# **Lab 1 - Hello World**

```c#
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
```



# **Lab 2 - Odd & Even Count**

```c#
namespace lab2
{
    internal class Lab2
    {
        static void Main(string[] args)
        {
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
```



# **Lab 3 - Bubble Sort**

```c#
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
```



# **Lab 4 - Bank Account**

```c
namespace Lab4
{
    internal class Bank
    {

/* 1. You solution should have two C# files; Bank.cs and Account.cs.
 *      
 *        Bank.cs contains the Main( ) method which is the starting point of the
 *          application’s execution. You can rename the generated Program.cs to
 *          Bank.cs to start with.
 */
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();

            int numberOfBankAccounts = 0;


            // getting number of months
            Console.Write("Enter number of months: ");
            int numberOfMonths = Int32.Parse(Console.ReadLine());


            // getting account information
            while(true)
            {
                // owner name
                Console.Write("\nEnter customer name: ");
                string ownerName = Console.ReadLine();

                if(ownerName == "" && numberOfBankAccounts > 0)
                {
                    Console.WriteLine("");
                    break;
                }

                numberOfBankAccounts++;

                // initial deposit
                Console.Write($"Enter {ownerName}'s initial deposit (min. $1,000): ");
                double initialDeposit = Double.Parse(Console.ReadLine());

                // monthly deposit
                Console.Write($"Enter {ownerName}'s monthly deposit (min. $50): ");
                double monthlyDeposit = Double.Parse(Console.ReadLine());

                // adding information to class Account
                accounts.Add(new Account(ownerName, initialDeposit, monthlyDeposit));

            }

            // updating monthly amount
            for(int i = 0; i < numberOfMonths; i++)
            {
                accounts.ForEach(account =>
                {
                    account.MonthlyUpdate();
                });
            }

            // populating account information
            accounts.ForEach(account =>
            {
                Console.WriteLine($"After {numberOfMonths} months, {account.OwnerName}'s account (#{account.AccountNumber}) will have a balance of ${account.Balance:N2}");
            });

            Console.ReadKey();

        }
    }
}
```

```c#
namespace Lab4
{
    internal class Account
    {
        /* 2. The Account class should have at least the following properties:
         *        AccountNumber – An integer  
         *        OwnerName – the account owner’s name 
         *        Balance – current balance of the account.
         *        MonthlyDepositAmount – the amount that the customer will deposit into his/her account monthly.
         */

        // creating the class attributes
        private int accountNumber;
        private string ownerName;
        private double balance;
        private double monthlyDeposit;





        // creating static properties (public variables)
        static public double monthlyFee = 4.0;
        static public double monthlyInterestRate = 0.0025;
        static public double minimumInitialBalance = 1000;
        static public double minimumMonthlyDeposit = 50;



        /* 4. The Account should have at least one constructor which takes the owner’s name and initial
         *    deposit amount as parameter to initialize the properties of OwnerName and Balance.
         *        The constructor also initializes the AccountNumber to a randomly generated integer of 9xxxx.
         *      
         *      Constructors:
         *           ownerName
         *           accountBalance
         *           accountNumber
         */

        // creating the constructor
        public Account(string ownerName, double balance, double monthlyDeposit)
        {
            // generating account number 
            this.accountNumber = new Random().Next(10000, 99999);
            this.ownerName = ownerName;
            this.balance = balance;
            this.monthlyDeposit = monthlyDeposit;
        }

        // creating the properties
        public double getBalance()
        {
            return this.balance;
        }

        public double Balance
        {
            get => this.balance;
        }
        

        public int AccountNumber
        {
            get => this.accountNumber;
        }

        public string OwnerName
        {
            get => this.ownerName; set => this.ownerName = value;
        }

        public double MonthlyDepositAmount
        {
            get => this.monthlyDeposit;
        }



        /* 5.  The Account should have at least two methods:
         *         Deposit     – It takes a double as a parameter to increase the Balance.
         *         Withdraw    – It takes a double as a parameter to decrease the Balance. In this lab,
         *                          we will assume that the withdraw amount is always less than the current Balance amount.
         */

        // creating the methods
        public void Deposit(double depositAmount)
        {
           this.balance += depositAmount;
        }

        public void Withdraw(double withdrawAmount)
        {
            this.balance -= withdrawAmount;
        }



        /*  6. For each month, the Bank class’ Main method should update each account’s balance in following order:
         *             Deduct monthly fee (4.0)
         *             Add monthly interest (0.0025)
         *             Add monthly deposit (50)
         */

        // updating the monthly fee
        public void MonthlyUpdate()
        {
            this.balance -= Account.monthlyFee;
            this.balance += (this.balance * Account.monthlyInterestRate);
            this.balance += this.MonthlyDepositAmount;
        }

    }
}
```

# **Lab 4 - Bank Account - FINAL**

```c#
/* 1. You solution should have two C# files; Bank.cs and Account.cs.
 *      Bank.cs contains the Main( ) method which is the starting point of the
 *    application’s execution. You can rename the generated Program.cs to
 *    Bank.cs to start with.
 */

namespace Lab4Trial
{
    internal class Bank
    {
        static void Main(string[] args)
        {
            // declaring variables
            int numberOfAccounts = 0;
            string ownerName;

            // new class instance
            List<Account> accounts = new List<Account>();

            // enter number of months
            Console.Write("Enter number of months: ");
            int numberOfMonths = Convert.ToInt32(Console.ReadLine());
            

            // getting account information from user
            while (true)
            {
                // owner name
                Console.Write("\nEnter Account Name: ");
                ownerName = Console.ReadLine();

                if (ownerName == "")
                {
                    // if empty ownerName and no account info: error
                    if (numberOfAccounts == 0)
                    {
                        Console.WriteLine("ERROR: Please input at least one (1) Account.\n");
                        break;
                    }
                    // if empty ownerName but with previous account info
                    else
                    {
                        // calculating the total amount after x months
                        Console.WriteLine($"\nCalculating the total amount for {Account.accountCount} bank accounts...\n");
                        for(int i = 0; i < numberOfMonths; i++)
                        {
                            foreach (Account account in accounts)
                            {
                                account.UpdateBalance();
                            }
                        }

                        // populating account information
                        foreach (Account account in accounts)
                        {
                            Console.WriteLine($"After {numberOfMonths} months, {account.OwnerName}'s account ({account.AccountNumber}) will have a total balance of ${account.Balance:N2}");
                        }

                        break;
                    };
                }
                // if ownerName is not empty: proceed with getting initial and monthly deposit
                else
                {
                    numberOfAccounts++;

                    Console.Write("Enter Initial Deposit Amount (min $1,000.00): ");
                    double initialDepositAmount = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Enter Monthly Deposit Amount: (min $50.00): ");
                    double monthlyDepositAmount = Convert.ToDouble(Console.ReadLine());

                    // add info as new class instance
                    accounts.Add(new Account(ownerName, initialDepositAmount, monthlyDepositAmount));
                }
            } // end of loop


            Console.ReadKey();

        }
    }
}
```

```c#
/* 2. The Account class should have at least the following properties:
*        AccountNumber – An integer  
*        OwnerName – the account owner’s name 
*        Balance – current balance of the account.
*        MonthlyDepositAmount – the amount that the customer will deposit into his/her account monthly.
*/

/* 3. The Account class also should have at least the following static properties: 
*        MonthlyFee (initialize its value as 4.0)
*        MonthlyInterestRate (initialize its value as 0.0025)
*        MinimumInitialBalance (initialize its value as 1000)
*        MinimumMonthDeposit (initialize its value as 50)
*/

/* 4. The Account should have at least one constructor which takes the owner’s name and initial
 *    deposit amount as parameter to initialize the properties of OwnerName and Balance.
 *        The constructor also initializes the AccountNumber to a randomly generated integer of 9xxxx.
 *      
 *      Constructors:
 *           ownerName
 *           accountBalance
 *           accountNumber
 */

/* 5.  The Account should have at least two methods:
    *         Deposit     – It takes a double as a parameter to increase the Balance.
    *         Withdraw    – It takes a double as a parameter to decrease the Balance. In this lab,
    *                          we will assume that the withdraw amount is always less than the current Balance amount.
    */

/*  6. For each month, the Bank class’ Main method should update each account’s balance in following order:
 *             Deduct monthly fee (4.0)
 *             Add monthly interest (0.0025)
 *             Add monthly deposit (50)
 */

namespace Lab4Trial
{
    internal class Account
    {
        // 2. creating account class properties
        private string ownerName;
        private int accountNumber;
        private double balance;
        private double monthlyDepositAmount;

        // creating static attribute to count number of accounts
        public static int accountCount = 0;


        // 3. creating class static properties
        public static double monthlyFee = 4.0;
        public static double monthlyInterestRate = 0.0025;
        public static double minInitialBalance = 1000;
        public static double minMonthlyDeposit = 50;


        // 4. creating the class constructor
        public Account(string aOwnerName, double aAccountBalance, double aMonthlyDeposit)
        {
            // assigning the variables to the class attributes
            ownerName = aOwnerName;
            balance = aAccountBalance;
            monthlyDepositAmount = aMonthlyDeposit;
            accountNumber = new Random().Next(90000, 99999);

            // counting number of accounts
            accountCount++;
        }

        // making the class properties accessible
        public string OwnerName
        {
            get { return ownerName; }
        }

        public int AccountNumber
        {
            get { return accountNumber; }
        }

        public double Balance
        {
            get { return balance; }
        }

        public double MonthlyDepositAmount
        {
            get { return monthlyDepositAmount; }
        }


        // 5. creating the methods
        public void Deposit(double amount)
        {
            this.balance += amount;
        }

        public void Withdraw(double amount)
        {
            this.balance -= amount;
        }


        // 6. updating the monthly balance
        public void UpdateBalance()
        {
            this.balance -= monthlyFee;
            this.balance += (this.balance * monthlyInterestRate);
            this.balance += monthlyDepositAmount;
        }
        /* method for counting number of accounts
        public int getAccountCount()
        {
            return accountCount;
        }
        */
    }
}
```



# **Lab5 - Statistics Calculator**

```asp
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="Lab6Statistics.Statistics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

    <head runat="server">
        <title>Statistics Calculator</title>

        <%-- Use Bootstrap to style the page --%>
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
        <%-- Jquery required by Bootstrap  --%>
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
        <%-- Bootstrap's Javascript library --%>
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    </head>

    <body class="bg-secondary">
        <div class="container bg-light mt-5">
            <h1>Statistics Calculator</h1>
            <form id="form1" runat="server">

                    <!-- User input -->
                    <h4>Enter three numbers and click Submit to generate the statistics.</h4>

                    <h5><div class="row justify-content-start">

                        <!-- First number -->
                        <div class="col-3 text-right mt-2">
                                First Number:
                        </div> <div class="col-9 mt-2">
                                <asp:TextBox ID="firstNum" name="firstNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Second number -->
                        <div class="col-3 text-right mt-2">
                                Second Number:
                        </div> <div class="col-9 mt-2">
                            <asp:TextBox ID="secondNum" name="secondNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Third number -->
                        <div class="col-3 text-right mt-2">
                            Third Number:
                        </div> <div class="col-9 mt-2">
                            <asp:TextBox ID="thirdNum" name="thirdNum" runat="server"></asp:TextBox>
                        </div>

                        <!-- Submit -->
                        <div class="col-3 text-right mt-2">
                                <!-- Error message here -->
                            <asp:Button Text="Submit" class="btn btn-primary mt-2" runat="server" />
                        </div>
                        <div class="col-9 mt-2">
                            <asp:Label ID="errorMessage" runat="server" Visible="false" CssClass="text-danger"/>
                        </div>

                    </div></h5>

                    <!-- Results -->
                    <h4>Statistics Results</h4>

                    <h5><div class="row justify-content-start">
                        <div class="col-3 text-right mt-2">
                            Maximum:
                        </div> <div class="col-9 mt-2">
                                <asp:Label runat="server" ID="max" name="max"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Minimum:
                        </div> <div class="col-9 mt-2">
                            <asp:Label runat="server" ID="min" name="min"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Average:
                        </div> <div class="col-9 mt-2">
                            <asp:Label runat="server" ID="ave" name="ave"></asp:Label>
                        </div>
                        <div class="col-3 text-right mt-2">
                            Total:
                        </div> <div class="col-9 mt-2 mb-5">
                            <asp:Label runat="server" ID="total" name="total"></asp:Label>
                        </div>
                    </div></h5>

            </form>

        </div>

    </body>

</html>
```

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab6Statistics
{
    public partial class Statistics : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // error message initial visibility
            errorMessage.Visible = false;

            if (IsPostBack)
            {
                try
                {
                    // link variables to form textbox
                    int firstNumber = Int32.Parse(firstNum.Text);
                    int secondNumber = Int32.Parse(secondNum.Text);
                    int thirdNumber = Int32.Parse(thirdNum.Text);

                    // create array
                    int[] array = new int[3] { firstNumber, secondNumber, thirdNumber };

                    // get minimum number
                    int minimum = array.Min();

                    // get maximum number
                    int maximum = array.Max();

                    // get sum
                    int sum = array.Sum();

                    // get average
                    double average = array.Average();

                    // populate results
                    max.Text = maximum.ToString();
                    min.Text = minimum.ToString();
                    ave.Text = average.ToString();
                    total.Text = sum.ToString();

                }
                catch (Exception ex)
                {
                    errorMessage.Visible = true;
                    errorMessage.Text = "Error: " + ex.Message;
                    max.Text = "";
                    min.Text = "";
                    ave.Text = "";
                    total.Text = "";
                }
            }
        }
    }
}
```

# **Lab 6 - Course Registration**

#### Helper.cs

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Helper
/// </summary>
namespace Lab6Trial.Models
{
    public class Helper
    {
        public static List<Course> GetAvailableCourses()
        {
            List<Course> courses = new List<Course>();

            Course course = new Course("CST8282", "Introduction to Database Systems");
            course.WeeklyHours = 4;
            courses.Add(course);

            course = new Course("CST8253", "Web Programming II");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8256", "Web Programming Language I");
            course.WeeklyHours = 5;
            courses.Add(course);

            course = new Course("CST8255", "Web Imaging and Animations");
            course.WeeklyHours = 2;
            courses.Add(course);

            course = new Course("CST8254", "Network Operating System");
            course.WeeklyHours = 1;
            courses.Add(course);

            course = new Course("CST2200", "Data Warehouse Design");
            course.WeeklyHours = 3;
            courses.Add(course);

            course = new Course("CST2240", "Advance Database topics");
            course.WeeklyHours = 1;
            courses.Add(course);

            return courses;
        }

        public static Course GetCourseByCode(string code)
        {
            foreach (Course c in GetAvailableCourses())
            {
                if (c.Code == code)
                {
                    return c;
                }
            }
            return null;
        }
    }
}
```

#### Course.cs

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab6Trial.Models
{
    public class Course
    {
        // Course properties
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours { get; set; }

        // Course constructors
        public Course(string code, string title)
        {
            Code = code;
            Title = title;
            WeeklyHours = WeeklyHours;
        }

        public Course(string code, string title, int weeklyHours)
        {
            Code = code;
            Title = title;
            WeeklyHours = WeeklyHours;
        }
    }
}
```

#### RegisterCourse.aspx (HTML)

```html
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6Trial.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!-- Title -->
         <title>Algonquin: Course Registration</title>

        <!-- Use Bootstrap to style the page -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
    
        <!-- Jquery required by Bootstrap  -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    
        <!-- Bootstrap's Javascript library -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

        <!-- Style Sheet -->
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
    </head>

    <body>
        <form id="form1" runat="server">
            <div class="container">
                <!-- Header -->
                <h1>Algonquin College Course Registration</h1>
                <hr />

                <!-- Student Info -->
                <div class="row">
                    Student Name:
                    <asp:TextBox runat="server" ID="studentName" CssClass="col-3 right-marg"></asp:TextBox>
                    <div class="col-3 right-marg"><asp:RadioButtonList runat="server" ID="studentStatus" RepeatDirection="Horizontal">
                        <asp:ListItem Text="Full Time" Value="fulltime" />
                        <asp:ListItem Text="Part Time" Value="parttime" />
                        <asp:ListItem Text="Co-op" Value="coop" />
                    </asp:RadioButtonList></div>
                </div><br />

                <!-- Input Panel -->
                <asp:Panel runat="server" ID="inputPanel">
                    <!-- Error Message -->
                    <div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="studentName" ID="studentNameValidator" Class="error">Please enter student name!</asp:RequiredFieldValidator>&nbsp;&nbsp;
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="studentStatus" Class="error">Please select student status!</asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="errorMessage" Visible="false" CssClass="error"></asp:Label>
                    </div>

                    <!-- Courses Checkbox-->
                    <p>The following courses are available for registration:</p>
                    <asp:CheckBoxList runat="server" ID="coursesList"></asp:CheckBoxList>

                    <!-- Submit Button -->
                    <asp:Button runat="server" ID="submitButton" Text="Submit" OnClick="submitButton_Click"/>
                </asp:Panel>



                <!-- Results Panel -->
                <asp:Panel runat="server" ID="resultsPanel" Visible="false">
                    <!-- Student has enrolled in the followin courses -->
                    <p id="enrollmentLabel"></p>

                    <!-- Table -->
                    <asp:Table runat="server" CssClass="table" ID="courseTable">
                        <asp:TableHeaderRow>
                            <asp:TableHeaderCell CssClass="distinct">Course Code</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Title</asp:TableHeaderCell>
                            <asp:TableHeaderCell CssClass="distinct">Weekly Hours</asp:TableHeaderCell>
                        </asp:TableHeaderRow>
                    </asp:Table>
                </asp:Panel>

            </div>
        </form>
    </body>
</html>
```

#### RegisterCourse.aspx.cs (C#)

```c#
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab6Trial.Models;

namespace Lab6Trial
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Populate all courses in checkbox
                foreach (Course course in Helper.GetAvailableCourses())
                {
                    coursesList.Items.Add(new ListItem($"{course.Title} - {course.WeeklyHours}", $"{course.Code}"));
                }
            }
        }

        protected void submitButton_Click(object sender, EventArgs e)
        {
            // Declare variables
            int totalCourses = 0;
            int totalHours = 0;
            bool containsError = false;
            // Create list of selectedCourses
            List<Course> selectedCourses = new List<Course>();


            // Get all items in the checkbox
            foreach (ListItem c in coursesList.Items)
            {
                // Calculate total weekly hours and total number of courses
                if (c.Selected)
                {
                    // Get course
                    Course getCourse = Helper.GetCourseByCode(c.Value);
                    // Add to list of selectedCourses
                    selectedCourses.Add(getCourse);
                    // Increment number of courses
                    totalCourses++;
                    // Total of weekly hours
                    totalHours += getCourse.WeeklyHours;
                }
            }

            // Error for fulltime: 16 weekly hours
            if (totalHours > 16 && studentStatus.SelectedValue == "fulltime")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 16 hours per week";
                containsError = true;
            }

            // Error for parttime: 3 courses
            if (totalCourses > 3 && studentStatus.SelectedValue == "parttime")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 3 courses";
                containsError = true;
            }

            // Error for coop: 2 courses
            if (totalCourses > 2 && studentStatus.SelectedValue == "coop")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 2 courses";
                containsError = true;
            }

            // Error for coop: 4 weekly hours
            if (totalHours > 4 && studentStatus.SelectedValue == "coop")
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! Your selection exceeds the maximum: 4 hours per week";
                containsError = true;
            }


            // Error for no course selected
            if (selectedCourses == null)
            {
                errorMessage.Visible = true;
                errorMessage.Text = "ERROR! You have not selected any course yet";
                containsError = true;

            }

            if (!containsError)
            {
                // Change visibility
                studentName.Enabled = false;
                studentStatus.Enabled = false;
                inputPanel.Visible = false;
                resultsPanel.Visible = true;

                foreach (Course course in selectedCourses)
                {
                    // Row
                    TableRow row = new TableRow();
                    courseTable.Rows.Add(row);

                    // Cell - code
                    TableCell cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.Code.ToString();

                    // Cell - title
                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.Title.ToString();

                    // Cell - weekly hours
                    cell = new TableCell();
                    row.Cells.Add(cell);
                    cell.Text = course.WeeklyHours.ToString();
                }
            }
        }
    }
}
```



# **Lab 7 - Add Student**

#### Student.cs

```c#
namespace Lab7Trial.Models
{
    public class Student
    {
        // properties
        public int Id { get; }
        public string Name { get; }

        // constructor taking one parameter of string type for initializing the Name property
        // the constructor will initialize Id property with a randomly generated 6-digit number
        protected Student (string name)
        {
            Random random = new Random();
            Id = random.Next(100000, 999999);
            Name = name;
        }
    }
}
```

#### FulltimeStudent.cs

```c#
namespace Lab7Trial.Models
{
    public class FulltimeStudent : Student
    {
        // property
        public int MaxWeeklyHours { get; set; }

        // constructor taking one parameter of string type to pass to the base class's constructor to initialize the base classes Name property
        public FulltimeStudent (string name) : base (name) { }
    }
}
```

#### ParttimeStudent.cs

```c#
namespace Lab7Trial.Models
{
    public class ParttimeStudent : Student
    {
        // property
        public int MaxNumOfCourses { get; set; }

        // constructor taking one parameter of strin gtype to pass to the base class' constructor to initialie the base classes Name property
        public ParttimeStudent (string name) : base (name) { }
    }
}
```

#### CoopStudent.cs

```c#
namespace Lab7Trial.Models
{
    public class CoopStudent : Student
    {
        // properties
        public int MaxWeeklyHours { get; set; }
        public int MaxNumOfCourses { get; set; }

        // constructor taking one parameter of string type to pass to the base class' constructor to initialize the base classes Name property
        public CoopStudent (string name) : base (name) { }
    }
}
```

#### AddStudent.aspx (HTML)

```html
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <!-- Title -->
         <title>Algonquin: Student Registration</title>
        <!-- Use Bootstrap to style the page -->
        <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"/>
        <!-- Jquery required by Bootstrap  -->
        <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
        <!-- Bootstrap's Javascript library -->
        <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
        <!-- Style Sheet -->
        <link href="App_Themes/SiteStyles.css" rel="stylesheet" type="text/css" />
    </head>

    <body class="container">
        <form id="form1" runat="server">

            <!-- -->

            <!-- Student Info-->
            <div class="row">
                <!-- Name -->
                <div class="col-3 text-right mt-2">Name:</div>
                <div class="col-9 mt-2"><asp:TextBox runat="server" ID="studentName" CssClass="input" Width="250px"></asp:TextBox></div>

                <!-- Status -->
                <div class="col-3 text-right mt-2">Status</div>
                <div class="col-9 mt-2"><asp:DropDownList runat="server" ID="studentStatus" width="250px">
                    <asp:ListItem Value="0">Select status...</asp:ListItem>
                    <asp:ListItem>Full Time</asp:ListItem>
                    <asp:ListItem>Part Time</asp:ListItem>
                    <asp:ListItem>Coop</asp:ListItem>
                </asp:DropDownList></div>

                <!-- Button -->
                <div class="col-3 mt-2 text-right"><asp:Button runat="server" ID="addButton" CssClass="button" OnClick="AddStudent_Click" Text="Add"/></div>

                <!-- Error -->
                <div class="col-9 mt-2">
                    <asp:RequiredFieldValidator runat="server" CssClass="error" ControlToValidate="studentName">Please enter student name.</asp:RequiredFieldValidator> &nbsp;
                    <asp:CompareValidator runat="server" CssClass="error" ControlToValidate="studentStatus" Display="Dynamic" Operator="NotEqual" ValueToCompare="0">Please enter student status.</asp:CompareValidator> &nbsp;
                    <asp:Label runat="server" ID="errorMessage" CssClass="error" Visible="false" />
                </div>

            </div>

            <!-- Table -->
            <asp:Table runat="server" ID="studentTable" CssClass="table">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>ID</asp:TableHeaderCell>
                    <asp:TableHeaderCell>Name</asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>

        </form>
    </body>
</html>
```

#### AddStudent.aspx.cs (C#)

```c#
using Lab7Trial.Models;

namespace Lab7Trial
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void AddStudent_Click(object sender, EventArgs e)
        {
            // declare and initialize students list
            List<Student> students = new List<Student>();
            // add students to session if list is not empty
            if (Session["students"] != null)
            { students = Session["students"] as List<Student>; }

            // fulltime student
            if (studentStatus.Text == "Full Time")
            {
                // add studentName as Student FulltimeStudent instance
                Student student = new FulltimeStudent (studentName.Text);
                // add student to students list
                students.Add (student);
            } else if (studentStatus.Text == "Part Time")
            {
                // add studentName as Student ParttimeStudent instance
                Student student = new ParttimeStudent(studentName.Text);
                // add student to students list
                students.Add(student);
            } else
            {
                // add studentName as Student CoopStudent instance
                Student student = new CoopStudent(studentName.Text);
                // add student to students list
                students.Add(student);
            }

            // add students to session
            Session["students"] = students;



            if (students.Count != 0)
            {
                // add students to studentTable
                foreach (Student student in students)
                {
                    // add new row
                    TableRow tableRow = new TableRow();
                    studentTable.Rows.Add(tableRow);
                    // add Id to cell
                    TableCell cell = new TableCell();
                    tableRow.Cells.Add(cell);
                    cell.Text = student.Id.ToString();
                    // add Name to cell
                    cell = new TableCell();
                    tableRow.Cells.Add(cell);
                    cell.Text = student.Name;
                }
            }

            // clear textbox and dropdown selection
            studentName.Text = "";
            studentStatus.SelectedValue = "0";
        }
    }
}
```





