namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the calculator program\n");

            bool again = true;

            while (again)
            {
                // Ask the user for two number and store them as floats
                Console.WriteLine("Enter the first number: ");
                float number1 = float.Parse(Console.ReadLine());

                Console.WriteLine("Enter the second number: ");
                float number2 = float.Parse(Console.ReadLine());

                // Output the menu options
                Console.WriteLine("\nEnter the menu number of the calculation to perform: ");
                Console.WriteLine("1 - Addition\n");
                Console.WriteLine("2 - Subtraction\n");
                Console.WriteLine("3 - Multiplication\n");
                Console.WriteLine("4 - Division\n");
                Console.WriteLine("q - Quit\n");

                // Ask for the menu option
                string menuOption = Console.ReadLine();

                // Perform a subroutine based on the menu option
                switch (menuOption)
                {
                    case "1":
                        Addition(number1, number2);
                        break;

                    case "2":
                        Subtraction(number1, number2);
                        break;

                    case "3":
                        Division(number1, number2);
                        break;

                    case "4":
                        Multiplication(number1, number2);
                        break;

                    case "q":
                        again = false;
                        break;
    
                    default:
                        Console.WriteLine("Enter a valid menu option");
                        break;
                }
            }
        }


        // The addition procedure has two floats as parameters, adds them together and outputs the result
        static void Addition(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + (num1 + num2));
        }
        static void Subtraction(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + (num1 - num2));
        }
        static void Multiplication(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + (num1 * num2));
        }
        static void Division(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + (num1 / num2));
        }
    }
}