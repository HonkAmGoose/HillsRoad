namespace Passwords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string filename = "passwords.txt";

            string username = GetStrInput("Enter the username: ");
            string password = GetStrInput("Enter the password: ");

            using (StreamWriter sw = new StreamWriter(filename, true))
            {
                sw.WriteLine(username);
                sw.WriteLine(password);
            }

            Console.WriteLine();

            using (StreamReader sr = new StreamReader(filename))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static string GetStrInput(string enterPrompt)
        {
            Console.WriteLine(enterPrompt);
            return Console.ReadLine();
        }
    }
}