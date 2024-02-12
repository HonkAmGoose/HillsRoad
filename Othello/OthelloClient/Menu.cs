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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void OfflineVsHumanButton_Click(object sender, EventArgs e)
        {
            Game game = new Game(this);
            game.Show();
            Hide();
        }

        private void OnlineChallengeButton_Click(object sender, EventArgs e)
        {
            RoomSelect roomSelect = RoomSelect.Instance;
            if (roomSelect == null ) (roomSelect = new RoomSelect()).Show();
            roomSelect.BringToFront();
        }
    }
}
