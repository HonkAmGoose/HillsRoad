using System;
using System.Drawing;
using System.Windows.Forms;

namespace Othello
{
    /// <summary>
    /// The GUI form
    /// </summary>
    public partial class Game : Form
    {
        Menu parent;
        Graphics DisplayGraphics;
        OfflineBoard GameBoard;
        int NoValidMovesCounter; // Used to end the game when both players have no valid moves
        int BlackWins = 0, WhiteWins = 0;

        SolidBrush[] TileBrushes = new SolidBrush[] { new SolidBrush(Color.Black), new SolidBrush(Color.White), new SolidBrush(Color.Gold) };

        public Game()
        {
            InitializeComponent();
        }

        public Game(Menu parent)
        {
            InitializeComponent();
            this.parent = parent;
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            DisplayGraphics = DisplayPanel.CreateGraphics(); // Get the graphics object to be referenced
            DisplayGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            BonusComboBox.SelectedIndex = 0; // Set combo box to default
            NewGame();
            Refresh();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGameButton.Enabled = false; // Don't allow multiple clicks
            Refresh();
            int index;
            if ((index = BonusComboBox.FindString(BonusComboBox.Text)) != -1) // Try to match input string to an option
            {
                BonusComboBox.SelectedIndex = index;
            }
            else // Otherwise revert to default
            {
                BonusComboBox.SelectedIndex = 0;
            }
            NewGame();
            NewGameButton.Enabled = true; 
            Refresh();
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            GameBoard.HintMoves();
            Refresh();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            EndTurnButton.Enabled = false; // Prevent spam of the button
            if (GameBoard.IsMoveProposed) // Only confirm move if one has been proposed
            {
                GameBoard.ConfirmMove();
                StartTurn();
                Refresh();
            }
            EndTurnButton.Enabled = true;
        }

        private void DisplayPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (GameBoard.IsMoveProposed)
            {
                GameBoard.CancelMove();
            }

            int x, y;
            Coordinate location;
            if (e.Location.X % 50 > 5 && e.Location.Y % 50 > 5) // Location is a green square and not a black line
            {
                // Convert coordinate to 2d index
                x = e.Location.X / 50; 
                y = e.Location.Y / 50;
                location = new Coordinate(x, y);
                if (GameBoard.SearchValidMoves(location))
                {
                    GameBoard.ProposeMove(location);
                }
                Refresh();
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            DrawBackground();
            DrawPieces();
            UpdateCounterNumbers();
        }

        /// <summary>
        /// Method to create a new game by generating a new game board and allowing input
        /// </summary>
        private void NewGame()
        {
            if (BonusComboBox.SelectedIndex == 0) // No bonus
            {
                GameBoard = new OfflineBoard();
            }
            else
            {
                int bonus = BonusComboBox.SelectedIndex - 1;
                GameBoard = new OfflineBoard(bonus / 4 == 0 ? 'B' : 'W', bonus % 4 + 1); // Black bonuses are first 4 and white the second 4
            }
            NoValidMovesCounter = 0;
            StartTurn();
            DisplayPanel.Enabled = true;
            HintButton.Enabled = true;
            EndTurnButton.Enabled = true;
        }

        /// <summary>
        /// Method used at the start of the turn to check for the end of the game
        /// </summary>
        private void StartTurn()
        {
            if (!GameBoard.StartTurn())
            {
                NoValidMovesCounter++;
                if (NoValidMovesCounter >= 2) // Neither player has valid moves
                {
                    EndGame();
                    return;
                }
                StartTurn(); // Recursion
            }
            else if(NoValidMovesCounter != 0)
            {
                MessageBox.Show("No valid moves for " + ((GameBoard.PlayerTurn == 'B') ? "white" : "black"));
                NoValidMovesCounter = 0;
            }
        }

        /// <summary>
        /// Method to end game by showing a messagebox and disabling input
        /// </summary>
        private void EndGame()
        {
            Refresh();
            if (GameBoard.CounterNumbers[0] > GameBoard.CounterNumbers[1])
            {
                BlackWinLabel.Text = (++BlackWins).ToString();
                MessageBox.Show("Game Over - Black wins!");
            }
            else if (GameBoard.CounterNumbers[0] < GameBoard.CounterNumbers[1])
            {
                WhiteWinLabel.Text = (++WhiteWins).ToString();
                MessageBox.Show("Game Over - White wins!");
            }
            else
            {
                BlackWinLabel.Text = (++BlackWins).ToString();
                WhiteWinLabel.Text = (++WhiteWins).ToString();
                MessageBox.Show("Game Over - Draw!");
            }
            DisplayPanel.Enabled = false;
            HintButton.Enabled = false;
            EndTurnButton.Enabled = false;
        }

        /// <summary>
        /// Method to update the counter numbers
        /// </summary>
        private void UpdateCounterNumbers()
        {
            BlackCounterLabel.Text = GameBoard.CounterNumbers[0].ToString();
            WhiteCounterLabel.Text = GameBoard.CounterNumbers[1].ToString();
        }

        /// <summary>
        /// Method to draw the background gameboard
        /// </summary>
        private void DrawBackground()
        {
            using (SolidBrush lineBrush = new SolidBrush(Color.Black))
            {
                DisplayGraphics.Clear(Color.Green); // Green background

                for (int i = 0; i <= 405; i += 50) // Black grid over the top
                {
                    DisplayGraphics.FillRectangle(lineBrush, i, 0, 5, 405);
                    DisplayGraphics.FillRectangle(lineBrush, 0, i, 405, 5);
                }
            }
        }

        /// <summary>
        /// Method to draw the pieces onto the board
        /// </summary>
        private void DrawPieces()
        {
            Tile toPaint;
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    toPaint = GameBoard.Tiles[x, y];
                    if (toPaint.Status != 'N')
                    {
                        int playerColour = (toPaint.CounterColour == 'B') ? 0 : 1;
                        int opponentColour = (toPaint.CounterColour == 'B') ? 1 : 0;
                        switch (toPaint.Status)
                        {
                            case 'C': // Confirmed is a whole counter of player colour
                                DrawCounter(TileBrushes[playerColour], x, y); 
                                break;

                            case 'T': // Turning is big counter of opponent with small counter of player colour
                                DrawCounter(TileBrushes[opponentColour], x, y);
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case 'P': // Proposed is small counter of player colour
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case 'H': // Hints are in gold
                                DrawSmallCounter(TileBrushes[2], x, y);
                                break;
                        }
                    }
                }
            }
        }

        private void DrawCounter(SolidBrush brush, int x, int y)
        {
            DisplayGraphics.FillEllipse(brush, x * 50 + 7, y * 50 + 7, 40, 40);
        }

        private void DrawSmallCounter(SolidBrush brush, int x, int y)
        {
            DisplayGraphics.FillEllipse(brush, x * 50 + 12, y * 50 + 12, 30, 30);
        }

        private void Game_FormClosed(object sender, FormClosedEventArgs e)
        {
            parent.Show();
        }
    }
}
