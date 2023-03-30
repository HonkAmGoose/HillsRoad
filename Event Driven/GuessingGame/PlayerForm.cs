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
            Guesses = new List<int>();
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
            if (e.KeyChar.ToString().Equals(Keys.Enter.ToString()))
            {
                MakeGuess();
            }
        }

        private void MakeGuess()
        {
            int guess = 0;
            string message = "";
            bool checkGuess = true;

            if (GuessesLeft < 1)
            {
                // Not enough guesses left
                message = "No guesses left!";
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
                    message = "Guess integer!";
                    checkGuess = false;
                }

                if (checkGuess)
                {
                    if (guess < 1 | guess > 100)
                    {
                        // Out of bounds
                        message = "Guess 1-100!";
                    }
                    else if (Guesses.Contains(guess))
                    {
                        // Already guessed
                        message = "Guess something new!";
                    }
                    else if (guess == Number)
                    {
                        // Win
                        message = "You win!";
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
                    }
                }
            }

            // Display message
            ResponseLabel.Text = message;
            ResponseLabel.Visible = true;
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
        }
    }
}
