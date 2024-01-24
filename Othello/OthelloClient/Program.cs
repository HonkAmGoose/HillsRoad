using System;
using System.Threading;
using System.Windows.Forms;

namespace Othello
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Uncomment to start an extra version
            //var thread = new Thread(ThreadStart);
            //thread.TrySetApartmentState(ApartmentState.STA);
            //thread.Start();

            Application.Run(new Menu());

        }
        private static void ThreadStart()
        {
            Application.Run(new Menu());
        }
    }
}
