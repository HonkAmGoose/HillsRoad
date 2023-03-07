using System;

namespace Uno
{
    internal class HumanPlayer : Player
    {
        public override int ChooseCard()
        {
            return 0;
        }

        public override ConsoleColor ChooseColour()
        {
            string[] options = new string[colours.Count];
            for (int i = 0; i < colours.Count; i++)
            {
                options[i] = colours[i].ToString();
            }

            int response = Helpers.DisplayMenu("Select a colour:", "Type in the corresponding number:", "Type in an integer", "Type in a number in range", options);

            return colours[response];
        }

        public override string ChooseName()
        {
            return Helpers.GetStrInput($"Enter the name for human player {ID}");
        }
    }
}
