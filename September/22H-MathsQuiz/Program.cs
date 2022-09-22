using System;

namespace MathsQuiz
{
    class Program
    {
        public static void Main(string[] args)
        {
            int correct = 0;
            int a, b, answer;
            Random random = new();

            Console.WriteLine("Welcome! This program will test your addition skills. Answer the following 10 questions\n\n");

            for (int i = 0; i < 10; i++)
            {
                a = random.Next(1,20);
                b = random.Next(1,20);
                Console.Write($"{a} + {b} = ");
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer == a+b)
                {
                    correct++;
                    Console.WriteLine("Correct!\n");
                }
                else
                {
                    Console.WriteLine($"I'm sorry, the answer was actually {a+b}.\n");
                }
            }

            Console.Write($"You got a total of {correct} correct answers out of a possible 10. ");
            if (correct <= 2)
            {
                Console.WriteLine("Better luck next time!");
                Console.WriteLine("Grade C");
            }
            else if (correct <= 5)
            {
                Console.WriteLine("Keep trying!");
                Console.WriteLine("Grade B");
            }
            else if (correct <= 8)
            {
                Console.WriteLine("Well done!");
                Console.WriteLine("Grade A");
            }
            else
            {
                Console.WriteLine("You did awesomely!");
                Console.WriteLine("Grade A*");
            }
        }
    }
}