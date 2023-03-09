namespace PlayerClasses
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer() : base() 
        {
            IsHuman = true;
        }

        protected override int ChooseCard(int[] ints, string[] options)
        {
            int response = Uno.Helpers.DisplayMenu
                (
                "Select a card to play:", 
                "Type in the corresponding number:", 
                "Type in an integer", 
                "Type in a number in range", 
                options
                );
            
            return ints[response];
        }

        protected override ConsoleColor ChooseColour()
        {
            string[] options = new string[colours.Count];
            for (int i = 0; i < colours.Count; i++)
            {
                options[i] = colours[i].ToString();
            }

            int response = Uno.Helpers.DisplayMenu
                (
                "Select a colour:", 
                "Type in the corresponding number:", 
                "Type in an integer", 
                "Type in a number in range", 
                options
                );

            return colours[response];
        }

        protected override string ChooseName()
        {
            return Uno.Helpers.GetStrInput($"Enter the name for human player {ID}");
        }
    }
}
