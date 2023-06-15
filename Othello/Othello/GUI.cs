﻿using System;
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
        Graphics DisplayGraphics;
        GameBoard GameBoard;
        int NoValidMovesCounter;

        SolidBrush[,] TileBrushes = new SolidBrush[,] { 
            { new SolidBrush(Color.Black), new SolidBrush(Color.White) },
            { new SolidBrush(Color.DarkRed), new SolidBrush(Color.Pink) },
            { new SolidBrush(Color.Navy), new SolidBrush(Color.Aqua) },
            { new SolidBrush(Color.Orange), new SolidBrush(Color.Yellow) }
        };

        public GUI()
        {
            InitializeComponent();
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            DisplayGraphics = DisplayPanel.CreateGraphics();
            NewGame();
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
            GameBoard.ConfirmMove();
            StartTurn();
            Refresh();
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
            using(SolidBrush lineBrush = new SolidBrush(Color.Black))
            {
                DisplayGraphics.Clear(Color.Green);

                for (int i = 0; i <= 405; i += 50)
                {
                    DisplayGraphics.FillRectangle(lineBrush, i, 0, 5, 405);
                    DisplayGraphics.FillRectangle(lineBrush, 0, i, 405, 5);
                }
            }
            DrawPieces();
        }

        private void NewGame()
        {
            GameBoard = new GameBoard();
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
                NoValidMovesCounter = 0;
            }
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
            Tile toPaint;
            for (int x = 0; x <= Coordinate.maxX; x++)
            {
                for (int y = 0; y <= Coordinate.maxY; y++)
                {
                    toPaint = GameBoard.Tiles[x, y];
                    if (toPaint.Status != 'N')
                    {
                        int status = 100;
                        switch (toPaint.Status)
                        {
                            case 'C':
                                status = 0;
                                break;

                            case 'P':
                                status = 1;
                                break;

                            case 'T':
                                status = 2;
                                break;

                            case 'H':
                                status = 3;
                                break;
                        }
                        int counterColour = (toPaint.CounterColour == 'B') ? 0 : 1;

                        DrawCounter(TileBrushes[status, counterColour], x, y);
                    }
                }
            }
        }

        private void DrawCounter(SolidBrush brush, int x, int y)
        {
            DisplayGraphics.FillEllipse(brush, x * 50 + 7, y * 50 + 7, 40, 40);
        }
    }
}
