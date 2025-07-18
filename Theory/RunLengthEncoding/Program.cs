using System;

namespace RLE
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input some text to compress");
            string original = Console.ReadLine();
            int running = 1;
            for (int i = 0; i < original.Length - 1; i++)
            {
                if (original[i] == original[i + 1])
                {
                    running++;
                }
                else if (i == original.Length - 2)
                {
                    if (original[i] == original[i + 1])
                    {
                        running++;
                        Console.WriteLine($"{original[i]} {running}");
                    }
                    else
                    {
                        Console.WriteLine($"{original[i]} {running} {original[i + 1]} 1");
                    }
                }
                else
                {
                    Console.Write($"{original[i]} {running} ");
                    running = 1;
                }
            }
        }
    }
}