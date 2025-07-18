using System;

namespace Test2
{
    class Program2
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("The first few prime numbers are:");

            int count2;
            string prime;
            for (int count1 = 2; count1 < 51; count1++)
            {
                count2 = 2;
                prime = "Yes";
                while (count2 * count2 <= count1)
                {
                    if (count1 % count2 == 0)
                    {
                        prime = "No";
                    }
                    count2 += 1;
                }
                if (prime.Equals("Yes"))
                {
                    Console.WriteLine(count1);
                }
            }
        }
    }
}