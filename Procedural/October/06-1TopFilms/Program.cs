using System;

namespace TopFilms
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] films = { "Ready Player 1", "Back to the Future", "The Matrix", "Bob the Builder", "In the Night Garden"};

            for (int i = 0; i < 4; i++)
            {
                foreach (string film in films)
                {
                    Console.WriteLine(film);
                }
                Console.WriteLine();
                if (i == 0)
                {
                    Array.Sort(films);
                }
                else if (i == 1)
                {
                    Array.Reverse(films);
                }
                else if (i == 2)
                {
                    films[4] = "Octonaughts";
                }
            }
        }
    }
}