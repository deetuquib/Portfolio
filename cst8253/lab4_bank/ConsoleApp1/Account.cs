using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Account
    {
        private int AccountNumber;
        private string Owner;
        private double Balance, MonthlyDepositAmount;

        public static double MonthlyFee = 4.0,
            MonthlyInterestRate = 0.0025,
            MinimumInitialBalance = 1000,
            MinimumMonthlyDeposit = 50;

        public Account(string name, double initBalance, double monthlyDeposit = -1)
        {
            this.Owner = name;
            //sets the initial deposit
            if (initBalance >= MinimumInitialBalance)
                this.Balance = initBalance;
            //sets the monthly deposit
            if (monthlyDeposit >= MinimumMonthlyDeposit)
                this.MonthlyDepositAmount = monthlyDeposit;
            //generates a random account number
            Random acctNumGen = new Random();
            AccountNumber = acctNumGen.Next(9999) + 90000;
        }

        //deposits the amount into the accounts
        public int Deposit(double amount)
        {
            if (amount < 0) return 1;
            this.Balance += Math.Round(amount, 2);
            return 0;
        }

        //withdraws the amount into the accounts
        public int Withdraw(double amount)
        {
            if (amount < 0) return 1;
            this.Balance -= Math.Round(amount, 2);
            return 0;
        }

        //returns the monthly deposit
        public double GetMonthlyDeposit()
        {
            return this.MonthlyDepositAmount;
        }

        //returns the account balance
        public double GetBalance()
        {
            return this.Balance;
        }

        //returns the account number
        public int GetAccountNum()
        {
            return this.AccountNumber;
        }

        //returns the account owner
        public string GetOwner()
        {
            return this.Owner;
        }

    }
}
