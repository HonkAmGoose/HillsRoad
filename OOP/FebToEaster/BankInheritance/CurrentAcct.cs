using System;

namespace BankInheritance
{
    internal class CurrentAcct : BankAcct
    {
        protected double arrangedOverdraft;
        protected double unarrangedOverdraft;

        public CurrentAcct(string holder, int number, double balance, double arrangedOverdraft, double unarrangedOverdraft) : base(holder, number, balance)
        {
            this.arrangedOverdraft = arrangedOverdraft;
            this.unarrangedOverdraft = unarrangedOverdraft;

            Console.WriteLine("Current Account Created");
        }

        public override void Withdraw(double amount)
        {
            if (amount < currentBalance + arrangedOverdraft + unarrangedOverdraft)
            {
                currentBalance -= amount;
            }
            else
            {
                Console.WriteLine("Widthdrawl not allowed");
            }
        }

        public override string ToString()
        {
            return base.ToString() + "";
        }
    }
}
