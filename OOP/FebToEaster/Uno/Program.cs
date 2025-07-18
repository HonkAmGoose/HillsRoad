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
            Game game = new Game(1, 4);
            game.Setup();
            game.Play();
            Console.ResetColor();
            while (Console.ReadLine().ToLower() != "q"); // Wait for q<enter> at the end so I can hold down <enter> to test without exiting at the end
        }
    }
}