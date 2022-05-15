using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Bank
    {
        static List<Account> userAccounts = new List<Account>();

        static void Main(string[] args)
        {
            string customerName;
            double initDeposit, monthlyDeposit, numOfMonth;
            Account newAccount;

            //gets the number of months
            Console.Write("Enter the number of months to deposit: ");
            numOfMonth = double.Parse(Console.ReadLine());

            do
            {
                //gets the customers name
                Console.Write("\nEnter Customer Name: ");
                customerName = Console.ReadLine();

                if (customerName != "")
                {
                    //gets the initial deposit
                    Console.Write("Enter {0}'s Initial Deposit Amount (minimum {1}): ", customerName, Account.MinimumInitialBalance.ToString("C"));
                    initDeposit = double.Parse(Console.ReadLine());

                    //gets the monthly deposit
                    Console.Write("Enter {0}'s Monthly Deposit Amount (minimum {1}): ", customerName, Account.MinimumMonthlyDeposit.ToString("C"));
                    monthlyDeposit = double.Parse(Console.ReadLine());

                    //creates the account with the given information
                    newAccount = new Account(customerName, initDeposit, monthlyDeposit);
                    userAccounts.Add(newAccount);

                }

                Console.WriteLine();
            } while (customerName != "");

            //calculates the activities of the bank account for the amount of months chosen
            for (int month = 0; month < numOfMonth; month++)
            {
                foreach (Account currentAccount in userAccounts) {
                    //takes the monthly fee
                    currentAccount.Withdraw(Account.MonthlyFee);
                    //adds the monthly interest
                    currentAccount.Deposit(currentAccount.GetBalance() * Account.MonthlyInterestRate);
                    //adds the monthly deposit
                    currentAccount.Deposit(currentAccount.GetMonthlyDeposit());
                }
                
            }

            //prints out the resulting balances
            foreach (Account currentAccount in userAccounts)
            {
                Console.WriteLine("After " + numOfMonth + " months, {0}'s account (#{1}), has a balance of: {2}", currentAccount.GetOwner(), currentAccount.GetAccountNum(), currentAccount.GetBalance().ToString("c"));
            }

            //ends program
            Console.Write("\n Press enter to complete ");
            Console.ReadLine();

            
        }
    }
}
