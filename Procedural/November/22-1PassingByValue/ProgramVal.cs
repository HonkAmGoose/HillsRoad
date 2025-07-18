using System;

namespace PassingByValue
{
    class ProgramVal
    {
        static void Main()
        {
            double pay;
            pay = 2000;
            Console.WriteLine(pay);

            pay = CalculatePay(pay);
            Console.WriteLine(pay);

            pay = Bonus(pay);
            Console.WriteLine(pay);
        }

        // Function to calculate deductions from pay
        static double CalculatePercentage(double pay, double percent)
        {
            return (pay * percent) / 100;
        }

        static double CalculatePay(double pay)
        {
            // Subtract tax on pay at 22%
            return pay - CalculatePercentage(pay, 22);
        }

        static double Bonus(double pay)
        {
            // Add bonus of 5%
            return pay + CalculatePercentage(pay, 5);
        }
    }
}
