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

        /// <summary>
        /// Create form and initialise values
        /// </summary>
        public OthelloMenu()
        {
            InitializeComponent();

            ID = Guid.NewGuid().ToString();
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
            roomSelect.BringToFront();
        }

        /// <summary>
        /// Creates a new online game with the specified roomID and password - called by RoomSelect
        /// </summary>
        public void NewOnlineGame()
        {
            Game game = new Game(this, true);
            game.Show();
            Hide();
        } 
    }
}
