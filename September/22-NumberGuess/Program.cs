namespace NumberGuess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool again;
            int guess, target, numGuesses;
            Random random = new();
            do
            {
                target = random.Next(0, 100);

                Console.WriteLine("I am thinking of a number between 0 and 100 inclusive.\n");

                numGuesses = 0;
                do
                {
                    Console.Write("Guess the number:");
                    guess = Convert.ToInt32(Console.ReadLine());

                    if (guess < target)
                    {
                        Console.WriteLine("Too low!");
                    }
                    else if (guess > target)
                    {
                        Console.WriteLine("Too high!");
                    }
                    else
                    {
                        Console.WriteLine("Correct");
                    }

                    numGuesses++;
                } while (guess != target);

                Console.WriteLine($"You guessed the target {target} in {numGuesses} guesses");

                Console.WriteLine("Would you like to play again (y/N)");
                if (Console.ReadLine().ToLower().Equals("y"))
                {
                    again = true;
                }
                else
                {
                    again = false;
                }
            } while (again == true);
        }
    }
}