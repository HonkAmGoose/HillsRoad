using System;

namespace MeasurementConversion
{
    class Program
    {
        // Global variables
        

        static void Main(string[] args)
        {
            // Call the Menu() procedure
            Menu();
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

            // Call the approriate subroutine
            switch (choice)
            {
                case 1:
                    {
                        CmToInches();
                        break;
                    }

                case 2:
                    {
                        InchesToCm();
                        break;
                    }

                case 3:
                    {
                        Environment.Exit(0);
                        break;
                    }
            }
        }

        // Procedure to convert cm to inches
        static void CmToInches()
        {
            // Ask the user to input cm
            Console.Write("\nEnter cm: ");
            double cm = Convert.ToDouble(Console.ReadLine());

            // Convert cm to inches
            double inches = cm * 0.393700787;
            Console.WriteLine(inches + " inches");

            // Call the Menu() procedure
            Menu();
        }

        // Procedure to convert inches to cm
        static void InchesToCm()
        {
            // Ask the user to input inches
            Console.Write("\nEnter inches: ");
            double inches = Convert.ToDouble(Console.ReadLine());

            // Convert inches to cm
            double cm = inches * 2.54;
            Console.WriteLine(cm + " cm");

            // Call the Menu() procedure
            Menu();
        }
    }
}