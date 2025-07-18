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
        private Button[,] gridButtons;
        private bool AllowTurn;
        private int TurnsTaken;
        private int XScore;
        private int OScore;
        private int GamesPlayed;

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

            AllowTurn = true;
            TurnsTaken = 0;

            XStartRadioButton.Enabled = true;
            XStartRadioButton.Checked = false;
            OStartRadioButton.Enabled = true;
            OStartRadioButton.Checked = false;
        }

        private void ResetScore()
        {
            XScore = 0;
            OScore = 0;
            UpdateScore();
        }

        /// <summary>
        /// Updates score by adding 1 to the player specified and updating the label
        /// </summary>
        /// <param name="player">X, O or Both</param>
        /// <exception cref="ArgumentException">Thrown when player is not valid</exception>
        private void UpdateScore(string player)
        {
            if (player.Equals("X"))
            {
                XScore++;
            }
            else if (player.Equals("O"))
            {
                OScore++;
            }
            else if (player.Equals("Both"))
            {
                XScore++;
                OScore++;
            }
            else
            {
                throw new ArgumentException("Player must be X, O or Both");
            }
            UpdateScore();
        }

        /// <summary>
        /// Updates the score label with current score
        /// </summary>
        private void UpdateScore()
        {
            ScoreLabel.Text = $"X:{XScore} - O:{OScore} from {GamesPlayed} games";
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
            gridButtons = new Button[rows, cols];
            // double for loop to handle all rows and columns
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    // create newTicTacToeButton control which will be one 
                    // of the buttons of the grid
                    gridButtons[r, c] = new Button()
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
                    if (CheckRowsAndCols(r, c))
                    {
                        return true;
                    }
                }
            }
            return CheckDiagonals();
        }

        private bool CheckForWin(int r, int c)
        {
            if (CheckRowsAndCols(r, c))
            {
                return true;
            }
            return CheckDiagonals();
        }

        private bool CheckRowsAndCols(int r, int c)
        {
            if (!gridButtons[r, c].Text.Equals(""))
            {
                if (
                    gridButtons[r, 0].Text == gridButtons[r, 1].Text && gridButtons[r, 0].Text == gridButtons[r, 2].Text // row
                    ||
                    gridButtons[0, c].Text == gridButtons[1, c].Text && gridButtons[0, c].Text == gridButtons[2, c].Text // col
                    )
                {
                    return true;
                }
            }
            return false;
        }

        private bool CheckDiagonals()
        {
            if (!gridButtons[1, 1].Text.Equals(""))
            {
                if (gridButtons[0, 2].Text == gridButtons[1, 1].Text && gridButtons[0, 2].Text == gridButtons[2, 0].Text)
                {
                    return true;
                }
                if (gridButtons[0, 0].Text == gridButtons[1, 1].Text && gridButtons[0, 0].Text == gridButtons[2, 2].Text)
                {
                    return true;
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
            ResetScore();
            NewGame();
        }

        private void gridButton_Click(object sender, EventArgs e)
        {
            if (AllowTurn && ((Button)sender).Text == "")
            {
                if (TurnsTaken == 0)
                {
                    if (XStartRadioButton.Checked)
                    {
                        NoughtOrCross = "X";
                    }
                    else if (OStartRadioButton.Checked)
                    {
                        NoughtOrCross = "O";
                    }
                    else
                    {
                        MessageBox.Show("Select a player to start");
                        return;
                    }
                    XStartRadioButton.Enabled = false;
                    OStartRadioButton.Enabled = false;
                }
                ((Button)sender).Text = NoughtOrCross;

                TurnsTaken++;

                if (CheckForWin())
                {
                    AllowTurn = false;
                    MessageBox.Show($"Player {NoughtOrCross} has won");
                    UpdateScore(NoughtOrCross);
                }
                else if (TurnsTaken >= 9)
                {
                    AllowTurn = false;
                    MessageBox.Show("You have drawn");
                    UpdateScore("Both");
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

        private void resetScoreButton_Click(object sender, EventArgs e)
        {
            ResetScore();
        }
    }
}
