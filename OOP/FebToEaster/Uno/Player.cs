using System;
using CardClasses;

namespace Uno
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

        public abstract int ChooseCard();

        public abstract ConsoleColor ChooseColour();

        public abstract string ChooseName();

        public Card TakeTurn()
        {
            return new Card(1, 1);
        }
    }
}
