using System;

namespace ModeFinder
{
    class Program
    {
        public static void Main(string[] args)
        {
            int[] frequencies = new int[10];

            Console.WriteLine("How many numeric digits would you like to enter?");
            int numberOfDigits = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numberOfDigits; i++)
            {
                Console.WriteLine("Enter your next digit:");
                int digit = Convert.ToInt32(Console.ReadLine());
                frequencies[digit]++;
            }

            int modeFreq = 0;
            bool multiModal = false;

            for (int i = 0; i < frequencies.Length; i++)
            {
                if (frequencies[i] > modeFreq)
                {
                    modeFreq = frequencies[i];
                    multiModal = false;
                }
                else if (frequencies[i] == modeFreq)
                {
                    multiModal = true;
                }
            }

            if (!multiModal)
            {
                Console.WriteLine(modeFreq);
            }
            else
            {
                Console.WriteLine("Data was multimodal");
            }
        }
    }
}