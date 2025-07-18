using System;
using System.Threading;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// Enum to store the colour of a tile or player
    /// </summary>
    public enum Colour
    {
        None,
        Black, 
        White,
    }

    /// <summary>
    /// Enum to store the status of a tile
    /// </summary>
    public enum Status
    {
        None,
        Proposed,
        Confirmed,
        Turning,
        Hinted,
    }

    /// <summary>
    /// Client program
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Stores the hubconnection URL
        /// </summary>
        public const string hubConnection = "http://localhost:9082";

        /// <summary>
        /// The main entry point for the application
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start an extra version
            var thread = new Thread(ThreadStart);
            thread.TrySetApartmentState(ApartmentState.STA);
            thread.Start();

            Application.Run(new OthelloMenu());

        }

        /// <summary>
        /// Starts a second copy of the game
        /// </summary>
        private static void ThreadStart()
        {
            Application.Run(new OthelloMenu());
        }
    }
}
