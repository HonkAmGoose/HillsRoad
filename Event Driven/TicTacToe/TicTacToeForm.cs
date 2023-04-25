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
    public partial class TicTacToeForm : Form
    {
        // Variables

        private string NoughtOrCross;
        private TicTacToeButton[,] gridButtons;
        private bool AllowTurn;
        private int TurnsTaken;

        const int SQUARE_GRID_SIZE = 3;
        const int cols = SQUARE_GRID_SIZE;
        const int rows = SQUARE_GRID_SIZE;
        const int gridWidth = 300;
        const int gridHeight = 300;
        const int tileWidth = gridWidth / cols;
        const int tileHeight = gridHeight / rows;
        const int gridTop = 100;
        const int gridLeft = 50;

        // My methods

        /// <summary>
        /// Creates a new game
        /// </summary>
        private void NewGame()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    gridButtons[r, c].Text = "";
                    gridButtons[r, c].Enabled = true;
                    gridButtons[r, c].BackColor = Color.Beige;
                }
            }

            NoughtOrCross = "X";
            AllowTurn = true;
        }

        /// <summary>
        /// Generates a grid of buttons  
        /// </summary>
        /// <param name="rows">Numebr of rows</param>
        /// <param name="cols">Number of columns</param>
        /// <param name="tileWidth">Button Width</param>
        /// <param name="tileHeight">Button Height</param>
        /// <param name="gridTop">Vertical position</param> 
        /// <param name="gridLeft">Horizontal position</param>
        private void CreateGrid(int rows, int cols, int tileWidth, int tileHeight, int gridTop, int gridLeft)
        {
            gridButtons = new TicTacToeButton[rows, cols];
            // double for loop to handle all rows and columns
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // create newTicTacToeButton control which will be one 
                    // of the buttons of the grid
                    gridButtons[r, c] = new TicTacToeButton(r, c)
                    {
                        Size = new Size(tileWidth, tileHeight),
                        Location = new Point(tileWidth * c + gridLeft, tileHeight * r + gridTop),
                        BackColor = Color.Beige,
                        Font = new Font("Arial", gridWidth / cols / 3), // font size proportional to width and # columns
                    };
                    // you can also modify the properties 
                    gridButtons[r, c].ForeColor = Color.Black;
                    // add the event handler for the button
                    gridButtons[r, c].Click += new EventHandler(gridButton_Click);
                    // add to Form's Controls so that they show up
                    Controls.Add(gridButtons[r, c]);
                }
            }
        }

        private bool CheckForWin()
        {
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    if (CheckForWin(r, c))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool CheckForWin(int r, int c)
        {
            if (!gridButtons[r, c].Equals(""))
            {
                if (
                    gridButtons[r, 0].Text == gridButtons[r, 1].Text && gridButtons[r, 0].Text == gridButtons[r, 2].Text // row
                    ||
                    gridButtons[0, c].Text == gridButtons[1, c].Text && gridButtons[0, c].Text == gridButtons[2, c].Text // col
                    )
                {
                    return true;
                }
                if (r + c == 2) // coordinate is on forward diagonal
                {
                    if (gridButtons[0, 2].Text == gridButtons[1, 1].Text && gridButtons[0, 2].Text == gridButtons[2, 0].Text)
                    {
                        return true;
                    }
                }
                if (r % 2 == 0 && c % 2 == 0) // coordinate is on backwards diagonal
                {
                    if (gridButtons[0, 0].Text == gridButtons[1, 1].Text && gridButtons[0, 0].Text == gridButtons[2, 2].Text)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        // Default generated event handlers

        public TicTacToeForm()
        {
            InitializeComponent();
        }
       
        private void TicTacToeForm_Load(object sender, EventArgs e)
        {
            CreateGrid(rows, cols, tileWidth, tileHeight, gridTop, gridLeft);
            NewGame();
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            if (AllowTurn && ((TicTacToeButton)sender).Text == "")
            {
                ((TicTacToeButton)sender).Text = NoughtOrCross;

                if (CheckForWin())
                {
                    AllowTurn = false;
                    MessageBox.Show($"Player {NoughtOrCross} has won");
                }

                TurnsTaken++;
                if (TurnsTaken >= 9)
                {
                    AllowTurn = false;
                    MessageBox.Show("You have drawn");
                }

                if (NoughtOrCross == "X")
                {
                    NoughtOrCross = "O";
                }
                else
                {
                    NoughtOrCross = "X";
                }
            } 
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }
    }
}
