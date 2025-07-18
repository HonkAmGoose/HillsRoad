using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MasterMind
{
 /*
 
 Version for students to complete/extend
 Tasks:  see the booklet for help
 1. Write the CheckScore function
 2. Add an extra peg colour: fuchsia: you can use the colour constant, Color.Fuchsia

 */

public partial class FormMM : Form
    {
        enum PegColour { grey, red, yellow, blue, green, purple, fuchsia };
        enum ScorePegColour { grey, black, white };
        private PegColour[] Data = new PegColour[40];
        private PegColour[] solution = new PegColour[4];
        private ScorePegColour[] ScorePegs = new ScorePegColour[40];
        DBPanel pegBoard;
        int currentRow;
        Random rand = new Random();

        public FormMM()
        {
            InitializeComponent();
        }


        private Color GetPegColour(PegColour c)
        {
            switch (c)
            {
                case PegColour.grey:
                    return Color.DarkGray;
                case PegColour.red:
                    return Color.Red;
                case PegColour.yellow:
                    return Color.Yellow;
                case PegColour.blue:
                    return Color.Blue;
                case PegColour.green:
                    return Color.Green;
                case PegColour.purple:
                    return Color.Purple;
                case PegColour.fuchsia:
                    return Color.Fuchsia;
                default:
                    return Color.DarkGray;
            }
        }



        private void FormMM_Load(object sender, EventArgs e)
        {
            pegBoard = new DBPanel(); // uses double-buffered subclass, defined below, to avoid flicker on repaint
            pegBoard.Height = 440;
            pegBoard.Width = 150;
            pegBoard.Left = 60;
            pegBoard.Top = 50;
            pegBoard.BorderStyle = BorderStyle.FixedSingle;
            pegBoard.Paint += new PaintEventHandler(pegBoard_Paint);
            pegBoard.MouseDown += new MouseEventHandler(board_MouseDown);
            this.Controls.Add(pegBoard);
            for (int i = 0; i < 40; i++)
            {
                Data[i] = PegColour.grey;
            }
            buttonCheck.Enabled = false;
            buttonNewGame_Click(sender, e);
        }

        private void pegBoard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            {
                using (SolidBrush brush = new SolidBrush(Color.DarkGray))
                {
                    for (int i = 0; i < 40; i++)
                    {
                        brush.Color = GetPegColour(Data[i]);
                        int col = i % 4;
                        int row = i / 4;
                        int x = 22 + (col * 30);
                        int y = 393 - (row * 40);
                        g.FillEllipse(brush, x, y, 15, 15);
                    }
                }
            }
        }

        private void board_MouseDown(object sender, MouseEventArgs e)
        {
            int row = (e.Y - 20) / 40;
            if (9 - row == currentRow && buttonNewGame.Enabled) //only if click is on current rows
            {
                int col = (e.X - 15) / 30;
                int index = 36 - (row * 4) + col;
                Data[index]++;
                Data[index] = (PegColour)(((int)Data[index]) % 7);
                pegBoard.Invalidate();
            }

        }

        private void CheckScore(int rownum, ref int black, ref int white)
        //write this function yourself: see the booklet for help
        {
            //calculates score for row Rownum:
            //black becomes number of correct colours in correct place
            //white becomes number of correct colours in wrong place

            black = 0;
            white = 0;

            PegColour[] guess = new PegColour[4];
            bool[] guessUsed = new bool[4];
            bool[] solutionUsed = new bool[4];

            int rowoffset = rownum * 4;
            for (int i = 0; i < 4; i++)
            {
                guess[i] = Data[rowoffset + i];
            }

            for (int i = 0; i < guess.Length; i++)
            {
                if (guess[i] == solution[i])
                {
                    black++;
                    guessUsed[i] = true;
                    solutionUsed[i] = true;
                }
            }
            
            for (int i = 0; i < guess.Length; i++)
            {
                for (int j = 0; j < solution.Length; j++)
                {
                    if (!guessUsed[i] && !solutionUsed[j] && guess[i] == solution[j])
                    {
                        white++;
                        guessUsed[i] = true;
                        solutionUsed[j] = true;
                    }
                }
            }
            //MessageBox.Show(black.ToString() + white.ToString());
        }

        bool WholeRowIsClicked(int guessNum)
        {
            for (int i = guessNum * 4; i <= (guessNum * 4) + 3; i++)
            {
                if (Data[i] == PegColour.grey)
                {
                    return false;
                }
            }
            return true;
        }
        private void DisplayScore(int guessNum, int black, int white)
        {
            int pegnum = guessNum * 4;
            int coloured = 0;
            while (coloured < black)
            {
                ScorePegs[pegnum] = ScorePegColour.black;
                pegnum++;
                coloured++;
            }
            coloured = 0;
            while (coloured < white)
            {
                ScorePegs[pegnum] = ScorePegColour.white;
                pegnum++;
                coloured++;
            }
        }
        private void buttonCheck_Click(object sender, EventArgs e)
        {
            int black = 0;
            int white = 0;
            if ((currentRow <= 9) && (WholeRowIsClicked(currentRow)))
            {
                for (int i = currentRow * 4; i < (currentRow * 4) + 3; i++)
                {
                    //disable pegs??
                }
                CheckScore(currentRow, ref black, ref white);
                DisplayScore(currentRow, black, white);
                scoreboard.Invalidate();
                if (black == 4)
                {
                    MessageBox.Show($"Well done. You have cracked the code: {solution[0]} {solution[1]} {solution[2]} {solution[3]}");
                    buttonCheck.Enabled = false;
                    scoreboard.Enabled = false;
                }
                else if (currentRow == 9)
                {
                    MessageBox.Show($"Oh dear. You have run out of guesses. The code was: {solution[0]} {solution[1]} {solution[2]} {solution[3]}");
                    buttonCheck.Enabled = false;
                    scoreboard.Enabled = false;
                }
                else
                {
                    currentRow++;
                }

            }
        }

        private void scoreboard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            {
                using (SolidBrush brush = new SolidBrush(Color.DarkGray))
                {
                    for (int i = 0; i < 40; i++)
                    {
                        brush.Color = Color.DarkGray;
                        if (ScorePegs[i] == ScorePegColour.black)
                        {
                            brush.Color = Color.Black;
                        }
                        if (ScorePegs[i] == ScorePegColour.white)
                        {
                            brush.Color = Color.White;
                        }
                        int col = i % 2;
                        int row = i / 2;
                        int x = 4 + (col * 20);
                        int y = 405 - (row * 20);
                        g.FillEllipse(brush, x, y, 10, 10);
                    }
                }
            }
        }

        private void buttonNewGame_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                Data[i] = PegColour.grey;
                ScorePegs[i] = ScorePegColour.grey;
            }
            pegBoard.Invalidate();
            for (int i = 0; i < 4; i++)
            {
                solution[i] = (PegColour)(rand.Next(6) + 1);
            }
            scoreboard.Invalidate();
            currentRow = 0;
            buttonCheck.Enabled = true;
            scoreboard.Enabled = true;

            //MessageBox.Show($"{solution[0]}{solution[1]}{solution[2]}{solution[3]}");
        }
    }

    //subclass to avoid flicker when pegs are clicked and board repainted
    public class DBPanel : Panel
    {
        public DBPanel()
        {
            this.DoubleBuffered = true;
        }
    }
}

