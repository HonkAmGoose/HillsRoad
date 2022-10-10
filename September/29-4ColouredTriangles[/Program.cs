using System.ComponentModel.DataAnnotations;

namespace ColouredTriangles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Get input
            Console.WriteLine("Enter the first line of the triangle");
            string input = Console.ReadLine();
            int length = input.Length;
            char[] ConstColours = { 'R', 'G', 'B' };
            List<char> colours;

            // Convert input to array

            /*
            PROBLEM
            This results in an array of length 0 and line.append doesn't work either so ???
            */
            char[] line = Array.Empty<char>();
            for (int i = 0; i <= length; i++)
            {
                line[i] = input[i];
                Console.WriteLine(line);
            }

            for (int i = 1; i <= length; i++)
            {
                for (int j = 0; j < length - i; j++)
                {
                    if (line[j] != line[j + 1])
                    {
                        colours = ConstColours.ToList();
                        colours.Remove(line[j]);
                        colours.Remove(line[j + 1]);
                        line[j] = colours[0];
                    }
                }
            }
        }
    }
}