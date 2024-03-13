using System;
using System.Threading;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// Client program to run the GUI
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
        /// Starts another copy of the game
        /// </summary>
        private static void ThreadStart()
        {
            Application.Run(new OthelloMenu());
        }
    }
}