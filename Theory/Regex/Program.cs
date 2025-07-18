using System.Text.RegularExpressions;

namespace _Regex
{
    class Program
    {
        public static void Main(string[] args)
        {
            string pattern = @"^[\w\-\.\+]+@[\w\-\.]+\.ac\.uk$";
            Regex r = new Regex(pattern);

            while (true)
            {
                Console.Write("Enter an email: ");
                string input = Console.ReadLine();

                if (r.IsMatch(input))
                {
                    Console.WriteLine("Match");
                }
                else
                {
                    Console.WriteLine("Invalid");
                }
            }
        }
    }
}
/*

want to match phone numbers in form

+44 7*** ******
+447*********
07*** ******
07*********

+44
01*** ******
01*********
02*** ******
02*********

*/