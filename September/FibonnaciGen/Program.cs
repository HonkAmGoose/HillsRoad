using System;

namespace FibbonacciGen
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter how many terms of the fibbonacci sequence you would like to generate");
            int num = Convert.ToInt32(Console.ReadLine());
            UInt64 x = 0;
            UInt64 y = 1;

            Console.Write(x + ", ");
            for (int i = 0; i < num; i++)
            {
                if (i % 2 == 0)
                {
                    y += x;
                    Console.Write(y + ", ");
                }
                else if (i % 2 == 1)
                {
                    x += y;
                    Console.Write(x + ", ");
                }
            }
        }
    }
}