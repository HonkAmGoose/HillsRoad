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
    public partial class PlayerForm : Form
    {
        private int GuessesLeft, Number;
        private List<int> Guesses;
        private Random rnd;
        private ComputerForm computerForm;

        public PlayerForm()
        {
            InitializeComponent();
        }

        private void PlayerForm_Load(object sender, EventArgs e)
        {
            rnd = new Random();
            NewGame();
        }

        private void NewButton_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void GuessButton_Click(object sender, EventArgs e)
        {
            int guess;
            string message = "";

            try
            {
                guess = int.Parse(GuessTextBox.Text);

                if (guess < 1 | guess > 100)
                {
                    throw new ArgumentOutOfRangeException();
                }
                else if (Guesses.Contains(guess))
                {
                    throw new InvalidOperationException();
                }

                else if (guess == Number)
                {
                    message = "You win!";
                }
                else if (guess > Number)
                {
                    message = "Too high!";
                }
                else if (guess < Number)
                {
                    message = "Too low!";
                }

                GuessesLeft -= 1;
                GuessesLeftLabel.Text = GuessesLeft.ToString();

                Guesses.Add(guess);
                GuessesListBox.Items.Add(guess.ToString() + " - " + message);
            }
            catch (FormatException)
            {
                message = "Guess integer";
            }
            catch (ArgumentOutOfRangeException)
            {
                message = "Guess 1-100";
            }
            catch (InvalidOperationException)
            {
                message = "Guess something new";
            }

            ResponseLabel.Text = message;
            ResponseLabel.Visible = true;
        }

        private void NewGame()
        {
            Number = rnd.Next(100) + 1;
            GuessesLeft = 10;
            GuessesLeftLabel.Text = "10";
            GuessesListBox.Items.Clear();
            GuessTextBox.Clear();
            ResponseLabel.Visible = false;
        }
    }
}
