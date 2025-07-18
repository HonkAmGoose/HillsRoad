using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuessingGame
{
    public partial class ComputerForm : Form
    {
        private PlayerForm playerForm;

        public ComputerForm(PlayerForm origin)
        {
            InitializeComponent();
            playerForm = origin;
        }

        private void ComputerForm_Load(object sender, EventArgs e)
        {
            ComputerRadioButton.Checked = true;
        }

        private void MeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MeRadioButton.Checked == true)
            {
                playerForm.Show();

                Hide();
            }
        }

        private void ComputerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            playerForm.Close();
        }
    }
}
