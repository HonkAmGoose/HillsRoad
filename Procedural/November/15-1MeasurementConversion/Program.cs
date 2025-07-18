using System;

namespace MeasurementConversion
{
    class Program
    {
        // Global variables
        

        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }

        // Procedure to present a menu of choices to the user
        static void Menu()
        {
            // Output the menu choices
            Console.WriteLine("\nChoose a menu option 1-3");
            Console.WriteLine("1. cm to inches");
            Console.WriteLine("2. inches to cm");
            Console.WriteLine("3. Quit");

            int choice;
            // Check that the user choice is valid
            do
            {
                Console.Write("\nEnter menu choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            while (choice < 1 || choice > 3);

            double? num = 0;
            if (choice != 3)
            {
                Console.WriteLine("Enter the number you want to convert: ");
                num = Convert.ToDouble(Console.ReadLine());
            }
            double result = 0;

            // Call the approriate subroutine
            switch (choice)
            {
                case 1:
                    {
                        result = (double)CmToInches(num);
                        break;
                    }

                case 2:
                    {
                        result = (double)InchesToCm(num);
                        break;
                    }

                case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }

            Console.WriteLine($"Your answer was {result}");
        }

        static double? CmToInches(double? num)
        {
            // Convert cm to inches and return
            num *= 0.393700787;

            return num;
        }
        static double? InchesToCm(double? num)
        {
            // Convert inches to cm and return
            num *= 2.54;

            return num;
        }
    }
}