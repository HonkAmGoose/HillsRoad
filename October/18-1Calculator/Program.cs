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
                Console.WriteLine("A - Addition\n");
                Console.WriteLine("S - Minus/Subtraction\n");
                Console.WriteLine("T - Times/Multiplication\n");
                Console.WriteLine("D - Division\n");
                Console.WriteLine("I - Integer Division\n");
                Console.WriteLine("M - Modulus\n");
                Console.WriteLine("q - Quit\n");

                // Ask for the menu option
                string menuOption = Console.ReadLine().ToLower();

                // Perform a subroutine based on the menu option
                switch (menuOption)
                {
                    case "a":
                        Addition(number1, number2);
                        break;

                    case "s":
                        Subtraction(number1, number2);
                        break;

                    case "t":
                        Division(number1, number2);
                        break;

                    case "d":
                        Multiplication(number1, number2);
                        break;

                    case "i":
                        IntDiv(number1, number2);
                        break;

                    case "m":
                        Modulus(number1, number2);
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
        static void IntDiv(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + Math.Floor(num1 / num2));
        }
        static void Modulus(float num1, float num2)
        {
            Console.WriteLine("\nThe result is: " + (num1 % num2));
        }
    }
}