namespace StringCheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Set sentence and split on spaces into seperate words
            string toCheck = "I am going to check every word of this sentence for the keywords";
            string[] words = toCheck.Split(" ");

            // Initialise dictionary to count keywords
            Dictionary<string, int> count = new Dictionary<string, int>();
            count.Add("check", 0);
            count.Add("word", 0);
            count.Add("sentence", 0);

            // Count number of each keyword in sentence and put in dictionary
            foreach (string word in words)
            {
                foreach (string key in count.Keys)
                {
                    if (word.Equals(key))
                    {
                        count[key]++;
                    }
                }
            }

            // Output dictionary with nice formatting
            foreach (string key in count.Keys)
            {
                Console.WriteLine($"There were {count[key]} instances of the word {key}");
            }

            // Output the sentence with keywords in red
            foreach (string word in words)
            {
                if (count.Keys.Contains(word))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(word + " ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(word + " ");
                }
            }

            Console.ReadLine();
        }
    }
}