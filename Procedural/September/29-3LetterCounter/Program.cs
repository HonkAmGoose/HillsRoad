namespace LetterCounter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a sentence to count vowels and consonants:");
            string sentence = Console.ReadLine().ToLower();
            char[] vowelArray = { 'a', 'e', 'i', 'o', 'u' };
            int vowelCount = 0, consonantCount = 0;

            foreach (char character in sentence)
            {
                if (char.IsLetter(character))
                {
                    if (vowelArray.Contains(character))
                    {
                        vowelCount++;
                    }
                    else
                    {
                        consonantCount++;
                    }
                }
            }

            Console.WriteLine($"There were {vowelCount} vowels and {consonantCount} consonants in your sentence.");
        }
    }
}