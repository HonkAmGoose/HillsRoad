using System;

namespace BankInheritance
{
    public class BankAcct
    {
        protected string accountHolder;
        protected int accountNumber;
        protected double currentBalance;

        public BankAcct(string holder, int number, double balance)
        {
            accountHolder = holder;
            accountNumber = number;
            currentBalance = balance;
            Console.WriteLine("Bank Account Created");
        }

        public void Deposit(double amount)
        {
            currentBalance += amount;
        }

        public virtual void Withdraw(double amount)
        {
            if (amount <= currentBalance)
            {
                currentBalance -= amount;
            }
            else
            {
                Console.WriteLine("Widthdrawl not allowed");
            }
        }

        public double GetBalance()
        {
            return currentBalance;
        }

        public int GetAccountNumber()
        {
            return accountNumber;
        }

        public string GetAccountHolder()
        {
            return accountHolder;
        }

        public override string ToString()
        {
            return $"Account Number: {accountNumber}\tAccount Holder: {accountHolder}\tBalance: {currentBalance}";
        }

    }
}
