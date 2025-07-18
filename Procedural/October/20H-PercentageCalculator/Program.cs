using System;

namespace PercentageCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int available = getIntInput("Enter how many marks are available on this test: ");
            int length = getIntInput("Enter the total amount of marks that are going to be input: ");
            
            int[] marks = getMarks(length);
            float[] percentages = getPercentages(marks, available);
            float mean = getMean(marks);

            Console.WriteLine("\nHere are the marks you inputted:\n");
            displayMarks(marks, available);

            Console.WriteLine("\nHere are the percentages:\n");
            displayPercentages(percentages);

            Console.WriteLine($"The mean value of marks was {mean}");
        }
        static int[] getMarks(int length)
        {
            int[] marks = new int[length];
            for (int i = 0; i < length; i++)
            {
                marks[i] = getIntInput($"Enter the mark for student {i + 1}:");
            }
            return marks;
        }
        static void displayMarks(int[] marks, int available)
        {
            for (int i = 0; i < marks.Length; i++)
            {
                Console.WriteLine($"Student {i} got {marks[i]} marks out of {available}");
            }
        }
        static float[] getPercentages(int[] marks, int available)
        {
            int length = marks.Length;
            float[] percentages = new float[length];
            for (int i = 0; i < length; i++)
            {
                percentages[i] = (float)marks[i] / available * 100;
            }
            return percentages;
        }
        static void displayPercentages(float[] percentages)
        {
            for (int i = 0; i < percentages.Length; i++)
            {
                Console.WriteLine($"Student {i} got {Math.Round(percentages[i]), 2}%");
            }
        }
        static float getMean(int[] marks)
        {
            int total = 0;
            int length = marks.Length;
            for (int i = 0; i < length; i++)
            {
                total += marks[i];
            }
            return (float)total / length;
        }
        static int getIntInput(string prompt)
        {
            bool valid = false;
            int value = 0;
            while (!valid)
            {
                Console.Write(prompt);
                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a valid integer");
                    continue;
                }
                valid = true;
            }
            return value;
        }
    }
}