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
        private bool HasWon;
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
            Guesses = new List<int>();
            MeRadioButton.Checked = true;
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
            MakeGuess();
        }

        private void GuessTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                e.Handled = true;
                MakeGuess();
            }
        }

        private void ComputerRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (ComputerRadioButton.Checked == true)
            {
                if (Application.OpenForms.OfType<ComputerForm>().Count() == 0)
                {
                    computerForm = new ComputerForm(this);
                    computerForm.Show();
                    computerForm.Focus();
                }
                else
                {
                    computerForm.Focus();
                }
                Hide();
            }
            else
            {
                if (Application.OpenForms.OfType<ComputerForm>().Count() >= 1)
                {
                    computerForm.Hide();
                }
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MakeGuess()
        {
            int guess = 0;
            string message = "";
            bool doCheckGuess = true;

            if (GuessesLeft < 1)
            {
                // Not enough guesses left
                message = "No guesses left!";
            }
            else if (HasWon == true)
            {
                // Already won
                message = "Already won!";
            }
            else
            {
                try
                {
                    // Get guess
                    guess = int.Parse(GuessTextBox.Text);
                }
                catch (FormatException)
                {
                    // Not integer guess
                    message = "Guess an integer!";
                    doCheckGuess = false;
                }

                if (doCheckGuess)
                {
                    message = CheckGuess(guess);
                }
            }

            // Display message
            ResponseLabel.Text = message;
            ResponseLabel.Visible = true;
        }

        private string CheckGuess(int guess)
        {
            string message;

            if (guess < 1 | guess > 100)
            {
                // Out of bounds
                message = "Guess between 1-100!";
            }
            else if (Guesses.Contains(guess))
            {
                // Already guessed
                message = "Guess something new!";
            }
            else
            {
                // Valid guess to be added
                if (guess < Number)
                {
                    message = "Too low!";
                }
                else if (guess > Number)
                {
                    message = "Too high!";
                }
                else if (guess == Number)
                {
                    message = "You win!";
                    HasWon = true;
                    GuessButton.Enabled = false;
                }
                else
                {
                    throw new Exception("Should be unreachable");
                }

                // Decrease GuessesLeft and display
                GuessesLeft -= 1;
                GuessesLeftLabel.Text = GuessesLeft.ToString();

                // Add guess to list
                Guesses.Add(guess);
                GuessesListBox.Items.Add(guess.ToString() + " - " + message);

                // Clear guess box
                GuessTextBox.Clear();
            }

            return message;
        }

        private void NewGame()
        {
            // Generate number
            Number = rnd.Next(100) + 1;

            // Reset vars and display
            GuessesLeft = 10;
            GuessesLeftLabel.Text = "10";
            GuessesListBox.Items.Clear();
            GuessTextBox.Clear();
            ResponseLabel.Visible = false;

            // Focus and reenable controls
            GuessButton.Enabled = true;
            GuessTextBox.Focus();
        }
    }
}
