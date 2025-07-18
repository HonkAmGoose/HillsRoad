using System;

namespace BankAccounts
{
    class Program
    {
        public static void Main(string[] args)
        {
            Account acct = new("Sam", "1", 0);
            Console.WriteLine(acct.ToString());
            acct.Deposit(50);
            Console.WriteLine(acct.GetBalance());
            acct.Withdraw(20.50);
            Console.WriteLine(acct.GetBalance());
        }
    }
}