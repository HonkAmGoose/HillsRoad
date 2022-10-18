namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator program\n");

            // Ask the user for two number and store them as floats
            Console.WriteLine("Enter the first number: ");
            float number1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            float number2 = float.Parse(Console.ReadLine());

            // Output the menu options
            Console.WriteLine("\nEnter the menu number of the calculation to perform: ");
            Console.WriteLine("1 - Addition");
            Console.WriteLine("2 - Subtraction");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - Division\n");

            // Ask for the menu option
            string menuOption = Console.ReadLine();

            // Perform a subroutine based on the menu option
            if (menuOption == "1")
            {
                Addition(number1, number2);
            }
            else
            {
                Console.WriteLine("Please choose a valid option");
            }
        }

        // The addition procedure has two floats as parameters, adds them together and outputs the result
        static void Addition(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + num1 + num2);
        }
    }
}