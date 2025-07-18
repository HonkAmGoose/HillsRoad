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
                float number1 = SafeFloatInput("Enter the first number: ", "You must enter a valid number.");
                float number2 = SafeFloatInput("Enter the second number: ", "You must enter a valid number.");

                // Output the menu options
                Console.WriteLine("\nEnter the menu number of the calculation to perform: ");
                Console.WriteLine("A - Addition");
                Console.WriteLine("S - Minus/Subtraction");
                Console.WriteLine("T - Times/Multiplication");
                Console.WriteLine("D - Division");
                Console.WriteLine("I - Integer Division");
                Console.WriteLine("M - Modulus");
                Console.WriteLine("q - Quit\n");

                // Ask for the menu option
                string menuOption = Console.ReadLine().ToLower();

                // Perform a subroutine based on the menu option
                switch (menuOption)
                {
                    case "a":
                        Console.WriteLine(Addition(number1, number2));
                        break;

                    case "s":
                        Console.WriteLine(Subtraction(number1, number2));
                        break;

                    case "t":
                        Console.WriteLine(Division(number1, number2));
                        break;

                    case "d":
                        Console.WriteLine(Multiplication(number1, number2));
                        break;

                    case "i":
                        Console.WriteLine(IntDiv(number1, number2));
                        break;

                    case "m":
                        Console.WriteLine(Modulus(number1, number2));
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

        //Get a safe input
        static string SafeInput(string prompt)
        {
            string response;
            Console.WriteLine(prompt);
            response = Console.ReadLine();
            if (response == null)
            {
                response = "";
            }
            return response;
        }
        static int SafeFloatInput(string prompt)
        {
            return SafeFloatInput(prompt, "Enter a float");
        }
        static int SafeFloatInput(string prompt, string failMessage)
        {
            bool ok = false;
            int response = 0;
            Console.WriteLine(prompt);
            while (ok == false)
            {
                try
                {
                    response = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine(failMessage);
                    continue;
                }
                ok = true;
            }
            return response;
        }

        // The addition procedure has two floats as parameters, adds them together and outputs the result
        static float Addition(float num1, float num2)
        {
            return num1 + num2;
        }
        static float Subtraction(float num1, float num2)
        {
            return num1 - num2;
        }
        static float Multiplication(float num1, float num2)
        {
            return num1 * num2;
        }
        static float Division(float num1, float num2)
        {
            return num1 / num2;
        }
        static float IntDiv(float num1, float num2)
        {
            return (float)Math.Floor(num1 / num2);
        }
        static float Modulus(float num1, float num2)
        {
            return num1 % num2;
        }
    }
}