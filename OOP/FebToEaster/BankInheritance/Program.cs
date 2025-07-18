using System;

namespace BankInheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAcct account1 = new BankAcct("SAM", 1, 5.50);
            Console.WriteLine(account1.ToString());
            account1.Deposit(100);
            Console.WriteLine(account1.ToString());
            account1.Withdraw(600);
            Console.WriteLine(account1.ToString());


            SavingsAcct account2 = new SavingsAcct("JOE", 2, 1000, 0.05, DateTime.Now, true, DateTime.Now.AddMinutes(5));
            Console.WriteLine(account2.ToString());
            account2.Deposit(100);
            Console.WriteLine(account2.ToString());
            account2.Withdraw(100);
            Console.WriteLine(account2.ToString());
            account2.Withdraw(1200);
            Console.WriteLine(account2.ToString());
            account2.AddInterest();
            Console.WriteLine(account2.ToString());
            account2.AddInterest();
            Console.WriteLine(account2.ToString());

            CurrentAcct account3 = new CurrentAcct("BOB", 3, 200, 100, 1000);
        }
    }
}
