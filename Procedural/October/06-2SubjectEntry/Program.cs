namespace SubjectEntry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of subjects that you currently study:");
            int numberOfSubjects = Convert.ToInt32(Console.ReadLine());

            string[] subjects = new string[numberOfSubjects];

            for (int i = 0; i < numberOfSubjects; i++)
            {
                Console.WriteLine("Enter a subject:");
                subjects[i] = Console.ReadLine();
            }

            int j;
            do
            {
                Console.WriteLine("If you would like to amend a choice, enter the number of which you want to edit (0 to finish editing):");
                j = Convert.ToInt32(Console.ReadLine());
                if (j != 0)
                {
                    Console.WriteLine($"The current value at index {j} is {subjects[j - 1]}.\nEnter the new value for this subject:");
                    subjects[j - 1] = Console.ReadLine();
                }
            } while (j != 0);

            foreach (string subject in subjects)
            {
                Console.WriteLine(subject);
            }
        }
    }
}