using System;

namespace ReduceNumber
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to see how many steps it requires to reduce to zero:");
            int num = Convert.ToInt32(Console.ReadLine());
            int steps = 0;

            while (num > 0)
            {
                if (num % 2 == 0)
                {
                    num /= 2;
                }
                else if (num % 2 == 1)
                {
                    num -= 1;
                }
                else
                {
                    throw new Exception("Something went wrong");
                }
                steps++;
            }

            Console.WriteLine($"It took {steps} steps to reduce to 0");
        }
    }
}