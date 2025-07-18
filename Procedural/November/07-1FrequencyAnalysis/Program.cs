namespace FrequencyAnalysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Dictionary<char, double> Frequency = new Dictionary<char, double>();
            Frequency.Add('A', 7.80);
            Frequency.Add('B', 2);
            Frequency.Add('C', 4);
            Frequency.Add('D', 3.80);
            Frequency.Add('E', 11);
            Frequency.Add('F', 1.40);
            Frequency.Add('G', 3);
            Frequency.Add('H', 2.30);
            Frequency.Add('I', 8.60);
            Frequency.Add('J', 0.21);
            Frequency.Add('K', 0.97);
            Frequency.Add('L', 5.30);
            Frequency.Add('M', 2.70);
            Frequency.Add('N', 7.20);
            Frequency.Add('O', 6.10);
            Frequency.Add('P', 2.80);
            Frequency.Add('Q', 0.19);
            Frequency.Add('R', 7.30);
            Frequency.Add('S', 8.70);
            Frequency.Add('T', 6.70);
            Frequency.Add('U', 3.30);
            Frequency.Add('V', 1);
            Frequency.Add('W', 0.91);
            Frequency.Add('X', 0.27);
            Frequency.Add('Y', 1.60);
            Frequency.Add('Z', 0.44);

            const string FilePath = "C:\\Users\\Dom\\My stuff\\SixthForm\\Computer Science\\Code\\November\\07-1FrequencyAnalysis\\TheTempest.txt";
            string text = File.ReadAllText(FilePath);
            
            Dictionary<char, int> letters = new Dictionary<char, int>();
            int total = 0;
            
            foreach (char c in text)
            {
                char cUp = c.ToString().ToUpper().ToCharArray()[0];
                if (Alphabet.Contains(cUp))
                {
                    total += 1;

                    if (letters.ContainsKey(cUp))
                    {
                        letters[cUp] += 1;
                    }
                    else
                    {
                        letters.Add(cUp, 1);
                    }
                }
            }

            int num;
            foreach (char c in Alphabet)
            {
                try
                {
                    num = letters[c];
                }
                catch (KeyNotFoundException)
                {
                    num = 0;
                }
                Console.WriteLine($"   There were {num + "\t"} characters {c} in the text, which accounts for {Math.Round((float)num / total * 100, 2) + "%\t"}, expected frequency {Frequency[c] + "%\t"}");
            }
        }
    }
}