using System;

namespace Uno
{
    internal class ComputerPlayer : Player
    {
        public override int ChooseCard()
        {
            return 0;
        }

        public override ConsoleColor ChooseColour()
        {
            return colours[0];
        }

        public override string ChooseName()
        {
            string name = names[0];
            Console.WriteLine($"Computer player {ID} is called {name}");
            return name;
        }
    }
}
