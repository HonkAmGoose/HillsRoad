namespace PlayerClasses
{
    internal class ComputerPlayer : Player
    {
        /// <summary>
        /// Constructor, sets IsHuman false and calls base()
        /// </summary>
        public ComputerPlayer() : base() 
        {
            IsHuman = false;
        }

        /// <summary>
        /// Function to generate a card to play (used by TakeTurn())
        /// </summary>
        /// <param name="indexes">The indexes of the valid cards</param>
        /// <param name="options">The 2char representations of the valid cards</param>
        /// <returns>The index of the selected card</returns>
        protected override int ChooseCard(int[] indexes, string[] options)
        {
            Random rnd = new();
            int num = rnd.Next(indexes.Length);

            return indexes[num];
        }

        /// <summary>
        /// Function to generate a colour
        /// </summary>
        /// <returns>The ConsoleColor representation of the desired colour</returns>
        protected override ConsoleColor ChooseColour()
        {
            return colours[0];
        }

        /// <summary>
        /// Function to generate a name
        /// </summary>
        /// <returns>The string representation of the desired name</returns>
        protected override string ChooseName()
        {
            string name = names[0];
            Console.WriteLine($"Computer player {ID} is called {name}");
            return name;
        }
    }
}
