namespace Uno
{
    /// <summary>
    /// Main program class
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args">Arguments from cmd (currently unused)</param>
        static void Main(string[] args)
        {
            Game game = new Game(1, 0);
            game.Play();
        }
    }
}