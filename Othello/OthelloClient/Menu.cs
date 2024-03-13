using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// Form to prompt the user to select a game type
    /// </summary>
    public partial class OthelloMenu : Form
    {
        public int roomID = -1;
        public string password = "";
        public readonly string ID;

        HubConnection connection;
        IHubProxy hubProxy;

        /// <summary>
        /// Create form and initialise values
        /// </summary>
        public OthelloMenu()
        {
            InitializeComponent();

            Random rand = new Random();
            ID = Guid.NewGuid().ToString();

            // Register hub events
            connection = new HubConnection("http://localhost:9082");
            hubProxy = connection.CreateHubProxy("MyHub");
            hubProxy.On<int, int, int, int>("ReturnStats", (blackGames, whiteGames, blackWins, whiteWins) => GetReturnedStats(blackGames, whiteGames, blackWins, whiteWins));
        }

        /// <summary>
        /// Creates a new offline game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfflineVsHumanButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(this, false);
            game.Show();
            Hide();
        }

        /// <summary>
        /// Creates a new online game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlineChallengeButton_Click(object sender, EventArgs e)
        {
            RoomSelect roomSelect = RoomSelect.Instance;
            if (roomSelect == null) (roomSelect = new RoomSelect(this)).Show();

            if (InvokeRequired) Invoke(new Action(() => roomSelect.BringToFront()));
            else roomSelect.BringToFront();
        }

        /// <summary>
        /// Creates a new online game with the specified roomID and password - called by RoomSelect
        /// </summary>
        public void NewOnlineGame(int roomID, string password)
        {
            Game game = new Game(this, true);
            game.Show();
            //if (InvokeRequired) Invoke(new Action(() => Hide()));
            Hide();
        }

        private async void StatisticsButton_Click(object sender, EventArgs e)
        {
            await connection.Start(new LongPollingTransport());
            _ = hubProxy.Invoke("GetStats", ID);
        }

        private void GetReturnedStats(int blackGames, int whiteGames, int blackWins, int whiteWins)
        {
            MessageBox.Show($"Games played - Black: {blackGames}, White: {whiteGames}\nGames won - Black: {blackWins}, White: {whiteWins}");
        }
    }
}