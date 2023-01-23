using System;

class solution
{
    public static void Main(string[] args)
    {
        int upper = Convert.ToInt32(Console.ReadLine());
        int lower = Convert.ToInt32(Console.ReadLine());
        int difference = Math.Abs(upper - lower);
        int n = 0;

        while (difference != 0)
        {
            upper = difference + 1;
            difference = Math.Abs(upper - lower);
            n++;

            if (difference == 0)
            {
                break;
            }
            else
            {
                lower = difference + 1;
                difference = Math.Abs(upper - lower);
                n++;
            }
        }

        Console.WriteLine(n);
    }
}