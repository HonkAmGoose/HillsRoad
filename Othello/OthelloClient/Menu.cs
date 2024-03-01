using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Transports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Othello
{
    public partial class OthelloMenu : Form
    {
        public int roomID = -1;
        public string password = "";
        public readonly string ID;

        public OthelloMenu()
        {
            InitializeComponent();

            Random rand = new Random();
            ID = Guid.NewGuid().ToString();
        }

        private void OfflineVsHumanButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(this, false);
            game.Show();
            Hide();
        }

        private void OnlineChallengeButton_Click(object sender, EventArgs e)
        {
            RoomSelect roomSelect = RoomSelect.Instance;
            if (roomSelect == null) (roomSelect = new RoomSelect(this)).Show();

            if (InvokeRequired) Invoke(new Action(() => roomSelect.BringToFront()));
            else roomSelect.BringToFront();
        }

        public void NewOnlineGame(int roomID, string password)
        {
            Game game = new Game(this, true);
            game.Show();
            //if (InvokeRequired) Invoke(new Action(() => Hide()));
            Hide();
        } 
    }
}
