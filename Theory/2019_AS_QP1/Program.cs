using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter a positive whole number: ");
        int NumberIn = Convert.ToInt32(Console.ReadLine());
        int NumberOut = 0;
        int Count = 0;

        while (NumberIn > 0)
        {
            Count++;
            int PartValue = NumberIn % 2;
            NumberIn = NumberIn / 2;
            
            for (int i = 1; i <= Count - 1; i++)
            {
                PartValue *= 10;
            }

            NumberOut += PartValue;
        }

        Console.WriteLine("The result is: " + NumberOut);
    }
}