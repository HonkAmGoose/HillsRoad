using System;

namespace TestMarks
{
    internal class Program
    {
        static bool AskYNQuestion(string question, bool defaultYes)
        {
            Console.WriteLine(question);
            if (defaultYes)
            {
                Console.Write("Y/n: ");
            }
            else
            {
                Console.Write("y/N: ");
            }
            string response = Console.ReadLine().ToUpper();
            if (response.Equals("Y"))
            {
                return true;
            }
            else if (response.Equals("N"))
            {
                return false;
            }
            else if (defaultYes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool AskYNQuestion(string question) // defaults to defaultYes = false if not given
        {
            return AskYNQuestion(question, false);
        }
        static int[,] CreateArray()
        {
            Console.WriteLine("Enter the number of papers you have:");
            int papers = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of students you have:");
            int students = Convert.ToInt32(Console.ReadLine());
            int[,] marks = new int[papers, students];

            for (int row = 0; row < marks.GetLength(0); row++)
            {
                for (int col = 0; col < marks.GetLength(1); col++)
                {
                    Console.WriteLine($"Enter the mark for paper {row}, student {col}:");
                    int mark = Convert.ToInt32(Console.ReadLine());
                    marks[row, col] = mark;
                }
            }
            return marks;
        }
        static void PrintArray(int[,] marks)
        {
            // Traverse the marks 2D array to output all the elements
            for (int row = 0; row < marks.GetLength(0); row++)
            {
                for (int col = 0; col < marks.GetLength(1); col++)
                {
                    // Output the test mark
                    Console.WriteLine($"In paper {row}, student {col} got {marks[row,col]}");
                }
            }
        }
        static int[,] EditSingleMark(int[,] marks)
        {
            Console.WriteLine("Enter the paper you would like to amend:");
            int paper = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the student you would like to amend:");
            int student = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the new mark:");
            int mark = Convert.ToInt32(Console.ReadLine());
            marks[paper, student] = mark;
            return marks;
        }
        static int[,] EditPaper(int[,] marks)
        {
            Console.WriteLine("Enter the paper you would like to amend:");
            int paper = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < marks.GetLength(1); i++)
            {
                Console.WriteLine($"Enter the new mark for student {i}:");
                int mark = Convert.ToInt32(Console.ReadLine());
                marks[paper, i] = mark;
            }
            return marks;
        }
        static int[,] EditStudent(int[,] marks)
        {
            Console.WriteLine("Enter the student you would like to amend:");
            int student = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                Console.WriteLine($"Enter the new mark for paper {i}:");
                int mark = Convert.ToInt32(Console.ReadLine());
                marks[i, student] = mark;
            }
            return marks;
        }
        static void Main(string[] args)
        {
            // Declare and initialise a 2D array for the test marks of Paper 1 and Paper 2
            int[,] marks = CreateArray();
            PrintArray(marks);

            while (AskYNQuestion("Would you like to edit a mark?"))
            {
                marks = EditSingleMark(marks);
                PrintArray(marks);
            }

            while (AskYNQuestion("Would you like to edit a whole paper?"))
            {
                marks = EditPaper(marks);
                PrintArray(marks);
            }

            while (AskYNQuestion("Would you like to edit all of a student's marks?"))
            {
                marks = EditStudent(marks);
                PrintArray(marks);
            }

            /* TASKS:
            - Output a clear message with the student number (0-5) and the paper number (1-2)
            - Allow the user to replace a single test mark then output the updated 2D array
            - Allow the user to replace all of the test marks using another nested for loop

            Challenge: Ask the user for the number of papers and students to submit marks for. 
            The program should create an empty 2D array and then ask the user for each mark.
            */
        }
    }
}