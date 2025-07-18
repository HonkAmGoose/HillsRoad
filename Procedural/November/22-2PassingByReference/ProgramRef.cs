using System;

namespace PassingByReference
{
    class ProgramRef
    {
        static void Main()
        {
            double pay;
            pay = 2000;
            Console.WriteLine(pay);

            CalculatePay(ref pay);
            Console.WriteLine(pay);

            Bonus(ref pay);
            Console.WriteLine(pay);
        }

        // Function to calculate deductions from pay
        static double CalculatePercentage(double pay, double percent)
        {
            return (pay * percent) / 100;
        }

        static void CalculatePay(ref double pay)
        {
            // Subtract tax on pay at 22%
            pay -= CalculatePercentage(pay, 22);
        }
        static void Bonus(ref double pay)
        {
            // Add bonus of 5%
            pay += CalculatePercentage(pay, 5);
        }
    }
}
