using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class TicTacToeButton : Button
    {
        public int Row;
        public int Col;

        public TicTacToeButton(int row, int col)
        {
            InitializeComponent();
            Row = row;
            Col = col;
        }
    }
}
