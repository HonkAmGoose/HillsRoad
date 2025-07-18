namespace BankAccounts
{
    public class Account
    {
        private string acctHolder;
        private string acctNumber;
        private double currentBalance;

        public Account(string name, string number, double balance)
        {
            this.acctHolder = name;
            this.acctNumber = number;
            this.currentBalance = balance;
        }

        public void Deposit(double amount)
        {
            this.currentBalance += amount;
        }

        public void Withdraw(double amount)
        {
            this.currentBalance -= amount;
        }

        public double GetBalance()
        {
            return this.currentBalance;
        }

        public string GetAcctHolder()
        {
            return this.acctHolder;
        }

        public string GetAcctNumber()
        {
            return this.acctNumber;
        }

        public override string ToString()
        {
            return $"Account number {this.acctNumber}, held by {this.acctHolder}, with balance {this.currentBalance}";
        }
    }
}