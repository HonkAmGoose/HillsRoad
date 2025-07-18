namespace PlayerClasses
{
    internal class HumanPlayer : Player
    {
        /// <summary>
        /// Constructor, sets IsHuman true and calls base()
        /// </summary>
        public HumanPlayer() : base() 
        {
            IsHuman = true;
        }

        /// <summary>
        /// Function to prompt player for a card to play (used by TakeTurn())
        /// </summary>
        /// <param name="indexes">The indexes of the valid cards</param>
        /// <param name="options">The 2char representations of the valid cards</param>
        /// <returns>The index of the selected card</returns>
        protected override int ChooseCard(int[] indexes, string[] options)
        {
            int response = Uno.Helpers.DisplayMenu
                (
                "Select a card to play:", 
                "Type in the corresponding number:", 
                "Type in an integer", 
                "Type in a number in range", 
                options
                );
            
            return indexes[response];
        }

        /// <summary>
        /// Function to prompt player for colour
        /// </summary>
        /// <returns>The ConsoleColor representation of the desired colour</returns>
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

        /// <summary>
        /// Function to prompt the player for a name
        /// </summary>
        /// <returns>The string representation of the desired name</returns>
        protected override string ChooseName()
        {
            return Uno.Helpers.GetStrInput($"Enter the name for human player {ID}");
        }
    }
}
