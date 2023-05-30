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
    public partial class GUI : Form
    {
        Graphics displayGraphics;
        GameBoard gameBoard;
        int noValidMovesCounter;

        public GUI()
        {
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            displayGraphics = DisplayPanel.CreateGraphics();
            NewGame();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void HintButton_Click(object sender, EventArgs e)
        {
            gameBoard.HintMoves();
            Refresh();
        }

        private void EndTurnButton_Click(object sender, EventArgs e)
        {

        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            using(SolidBrush lineBrush = new SolidBrush(Color.Black))
            {
                displayGraphics.Clear(Color.Green);

                for (int i = 0; i <= 405; i += 50)
                {
                    displayGraphics.FillRectangle(lineBrush, i, 0, 5, 405);
                    displayGraphics.FillRectangle(lineBrush, 0, i, 405, 5);
                }
            }
            DrawPieces();
        }

        private void NewGame()
        {
            gameBoard = new GameBoard();
            noValidMovesCounter = 0;
            StartTurn();
            DisplayPanel.Enabled = true;
            HintButton.Enabled = true;
            EndTurnButton.Enabled = true;
        }

        private void StartTurn()
        {
            if (!gameBoard.StartTurn())
            {
                noValidMovesCounter++;
            }
            else
            {
                noValidMovesCounter = 0;
            }
            if (noValidMovesCounter >= 2)
            {
                EndGame();
            }
            Refresh();
        }

        private void EndGame()
        {
            MessageBox.Show("Game Over");
            DisplayPanel.Enabled = false;
            HintButton.Enabled = false;
            EndTurnButton.Enabled = false;
        }

        private void DrawPieces()
        {
            SolidBrush blackC = new SolidBrush(Color.Black);
            SolidBrush whiteC = new SolidBrush(Color.White);
            SolidBrush blackP = new SolidBrush(Color.DarkRed);
            SolidBrush whiteP = new SolidBrush(Color.LightPink);
            SolidBrush blackT = new SolidBrush(Color.Navy);
            SolidBrush whiteT = new SolidBrush(Color.LightBlue);
            SolidBrush blackH = new SolidBrush(Color.Orange);
            SolidBrush whiteH = new SolidBrush(Color.Yellow);

            Tile toPaint;
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    toPaint = gameBoard.Tiles[x, y];
                    if (toPaint.Status != 'N')
                    {
                        if (toPaint.Status == 'C')
                        {
                            if (toPaint.CounterColour == 'B')
                            {
                                DrawCounter(blackC, x, y);
                            }
                            else
                            {
                                DrawCounter(whiteC, x, y);
                            }
                        }
                        else if (toPaint.Status == 'P')
                        {
                            if (toPaint.CounterColour == 'B')
                            {
                                DrawCounter(blackP, x, y);
                            }
                            else
                            {
                                DrawCounter(whiteP, x, y);
                            }
                        }
                        else if (toPaint.Status == 'T')
                        {
                            if (toPaint.CounterColour == 'B')
                            {
                                DrawCounter(blackT, x, y);
                            }
                            else
                            {
                                DrawCounter(whiteT, x, y);
                            }
                        }
                        else if (toPaint.Status == 'H')
                        {
                            if (toPaint.CounterColour == 'B')
                            {
                                DrawCounter(blackH, x, y);
                            }
                            else
                            {
                                DrawCounter(whiteH, x, y);
                            }
                        }
                    }
                }
            }

            blackC.Dispose();
            whiteC.Dispose();
            blackP.Dispose();
            whiteP.Dispose();
            blackT.Dispose();
            whiteT.Dispose();
            blackH.Dispose();
            whiteH.Dispose();
        }

        private void DrawCounter(SolidBrush brush, int x, int y)
        {
            displayGraphics.FillEllipse(brush, x * 50 + 7, y * 50 + 7, 40, 40);
        }
    }
}
