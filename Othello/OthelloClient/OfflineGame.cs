using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Othello
{
    public partial class OfflineGame : Othello.Game
    {
        public OfflineGame(Menu parent) : base(parent)
        {
            InitializeComponent();
        }
    }
}
