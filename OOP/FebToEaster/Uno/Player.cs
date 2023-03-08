using CardClasses;

namespace PlayerClasses
{
    abstract class Player
    {
        private static int nextID = 0;
        public int ID { get; protected set; }

        public Hand Cards { get; protected set; }

        public ConsoleColor Colour { get; protected set; }
        protected static List<ConsoleColor> colours = new() { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Blue, ConsoleColor.Cyan, ConsoleColor.Yellow, ConsoleColor.Magenta };

        public string Name { get; protected set; }
        protected static List<string> names = new() { "Sam", "Alex", "Jo", "Dan", "Charlie", "Rowan" };
        
        public Player()
        {
            if (nextID > 5)
            {
                throw new Exception("Cannot have more than six players");
            }
            ID = nextID;
            nextID++;

            Cards = new Hand();

            Name = ChooseName();
            names.Remove(Name);

            Colour = ChooseColour();
            colours.Remove(Colour);
        }

        public int TakeTurn(Card top)
        {
            Console.Write($"\nThe current top card is {top.GetNameAs2Char()}\n\nYour hand consists of: ");

            List<int> ints = new List<int>();
            List<string> options = new List<string>();
            for (int i = 0; i < Cards.Size; i++)
            {
                Console.Write(" " + Cards[i].GetNameAs2Char());
                if (
                    top.GetSuit() == Cards[i].GetSuit()
                    ||
                    top.GetRank() == Cards[i].GetRank()
                    )
                {
                    ints.Add(i);
                    options.Add(Cards[i].GetNameAs2Char());
                }
            }

            Console.WriteLine("\n");

            if (options.Count > 0)
            {
                return ChooseCard(ints.ToArray(), options.ToArray());
            }
            else
            {
                return -1;
            }
        }

        protected abstract int ChooseCard(int[] ints, string[] options);

        protected abstract ConsoleColor ChooseColour();

        protected abstract string ChooseName();
    }
}
