using System;
using System.Drawing;
using System.Windows.Forms;

namespace Othello
{
    public partial class GUI : Form
    {
        Graphics DisplayGraphics;
        GameBoard GameBoard;
        int NoValidMovesCounter;
        int BlackWins = 0, WhiteWins = 0;

        SolidBrush[] TileBrushes = new SolidBrush[] { new SolidBrush(Color.Black), new SolidBrush(Color.White), new SolidBrush(Color.Gold) };

        public GUI()
        {
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            DisplayGraphics = DisplayPanel.CreateGraphics();
            BonusComboBox.SelectedIndex = 0;
            NewGame();
            Refresh();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
            Refresh();
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            GameBoard.HintMoves();
            Refresh();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {
            EndTurnButton.Enabled = false;
            if (GameBoard.IsMoveProposed)
            {
                GameBoard.ConfirmMove();
                StartTurn();
                Refresh();
            }
            EndTurnButton.Enabled = true;
        }

        private void DisplayPanel_MouseUp(object sender, MouseEventArgs e)
        {
            Coordinate previous = null;
            if (GameBoard.IsMoveProposed)
            {
                previous = GameBoard.ProposedMove;
                GameBoard.CancelMove();
            }

            int x, y;
            Coordinate location;
            if (e.Location.X % 50 > 5 && e.Location.Y % 50 > 5)
            {
                x = e.Location.X / 50;
                y = e.Location.Y / 50;
                location = new Coordinate(x, y);
                if (location != previous && GameBoard.SearchValidMoves(location))
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

        private void NewGame()
        {
            if (BonusComboBox.SelectedIndex == 0)
            {
                GameBoard = new GameBoard();
            }
            else
            {
                int bonus = BonusComboBox.SelectedIndex - 1;
                GameBoard = new GameBoard(bonus / 4 == 0 ? 'B' : 'W', bonus % 4 + 1);
            }
            NoValidMovesCounter = 0;
            StartTurn();
            DisplayPanel.Enabled = true;
            HintButton.Enabled = true;
            EndTurnButton.Enabled = true;
        }

        private void StartTurn()
        {
            if (!GameBoard.StartTurn())
            {
                NoValidMovesCounter++;
                if (NoValidMovesCounter >= 2)
                {
                    EndGame();
                    return;
                }
                StartTurn();
            }
            else
            {
                if (NoValidMovesCounter != 0)
                {
                    MessageBox.Show("No valid moves for " + ((GameBoard.PlayerTurn == 'B') ? "white" : "black"));
                    NoValidMovesCounter = 0;
                }
            }
        }

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

        private void UpdateCounterNumbers()
        {
            BlackCounterLabel.Text = GameBoard.CounterNumbers[0].ToString();
            WhiteCounterLabel.Text = GameBoard.CounterNumbers[1].ToString();
        }

        private void DrawBackground()
        {
            using (SolidBrush lineBrush = new SolidBrush(Color.Black))
            {
                DisplayGraphics.Clear(Color.Green);

                for (int i = 0; i <= 405; i += 50)
                {
                    DisplayGraphics.FillRectangle(lineBrush, i, 0, 5, 405);
                    DisplayGraphics.FillRectangle(lineBrush, 0, i, 405, 5);
                }
            }
        }

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
                            case 'C':
                                DrawCounter(TileBrushes[playerColour], x, y);
                                break;

                            case 'P':
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case 'T':
                                DrawCounter(TileBrushes[opponentColour], x, y);
                                DrawSmallCounter(TileBrushes[playerColour], x, y);
                                break;

                            case 'H':
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
    }
}
