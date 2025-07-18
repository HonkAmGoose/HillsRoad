using System;

namespace BankInheritance
{
    public class SavingsAcct : BankAcct
    {
        protected double interestRate;
        protected bool allowWithdrawl;
        protected DateTime maturityDate;
        protected DateTime nextInterest;

        public SavingsAcct(string holder, int number, double balance, double interest, DateTime nextInterest, bool allowWithdrawl, DateTime maturity) : base(holder, number, balance)
        {
            interestRate = interest;
            this.allowWithdrawl = allowWithdrawl;
            maturityDate = maturity;
            this.nextInterest = nextInterest;

            Console.WriteLine("Savings Account Created");
        }

        public override void Withdraw(double amount)
        {
            if (allowWithdrawl && amount <= currentBalance)
            {
                currentBalance -= amount;
            }
            else
            {
                Console.WriteLine("Widthdrawl not allowed");
            }
        }

        public virtual BankAcct Mature()
        {
            if (DateTime.Now >= maturityDate)
            {
                return new BankAcct(accountHolder, accountNumber, currentBalance);
            }
            else
            {
                return null;
            }
        }

        public virtual void AddInterest()
        {
            if (DateTime.Now >= nextInterest)
            {
                currentBalance += currentBalance * interestRate;
                Console.WriteLine("Interest added");
                nextInterest = nextInterest.AddMinutes(1);
            }
            else
            {
                Console.WriteLine("Interest cannot be added");
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"\tInterest Rate: {interestRate}";
        }
    }

}
