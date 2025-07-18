using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;
using CardClasses;
using BlackJackGUI.Properties;


namespace CardGameGUI
{
    public partial class FormBlackJack : Form
    {
        Pack pack;
        BlackJackHand P1Hand;
        BlackJackHand P2Hand;
        BlackJackHand PDHand;
        ImageList P1images = new ImageList();
        ImageList P2images = new ImageList();
        ImageList PDimages = new ImageList();
        int P1longScore = 0;
        int P2longScore = 0;
        int PDlongScore = 0;

        // A resource manager provides convenient access to culture-specific resources at run time.
        // We need this to access the images that Resources for this project
        ResourceManager rm = Resources.ResourceManager;
        Graphics g;


        /// <summary>
        /// Form Constructor
        /// </summary>
        public FormBlackJack()
        {
            InitializeComponent();
        }

        private void FormBlackJack_Load(object sender, EventArgs e)
        {
            pack = new Pack();
            P1Hand = new BlackJackHand();
            P2Hand = new BlackJackHand();
            PDHand = new BlackJackHand();
            g = CreateGraphics();
            // C# ImageList Use: Windows Forms. 
            //ImageList provides a container for image data. 
            //The control is not visible directly. It is instead referenced from other controls such as ListView, 
            // which acquire the images from index values into the ImageList.
            P1images.ImageSize = new Size(72, 96); // Sets the size of the images in the image list.
            P2images.ImageSize = new Size(72, 96);
            PDimages.ImageSize = new Size(72, 96);
            pack.Shuffle();

            Player1DealButton.Enabled = false;
            Player2DealButton.Enabled = false;
            Player1StickButton.Enabled = false;
            Player2StickButton.Enabled = false;
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            // Hand is emptied, any card in P1Hand is returned to the pack 
            while (!P1Hand.IsEmpty())
            {
                pack.AddCard(P1Hand.RemoveCard(P1Hand.First()));
            }

            while (!P2Hand.IsEmpty())
            {
                pack.AddCard(P2Hand.RemoveCard(P2Hand.First()));
            }

            while (!PDHand.IsEmpty())
            {
                pack.AddCard(PDHand.RemoveCard(PDHand.First()));
            }

            P1images.Images.Clear();
            P2images.Images.Clear();
            PDimages.Images.Clear();
            Invalidate(); // forces to repaint the form

            P1Hand.AddCard(pack.DealCard());
            CreateImage(P1Hand.Last(), 0, 1);

            P2Hand.AddCard(pack.DealCard());
            CreateImage(P2Hand.Last(), 0, 2);

            PDHand.AddCard(pack.DealCard());
            CreateImage(P2Hand.Last(), 0, 3);

            P1CurrentScoreLabel.Text = "0";
            P2CurrentScoreLabel.Text = "0";
            PDCurrentScoreLabel.Text = "0";

            P1CurrentScoreLabel.Visible = true;
            P2CurrentScoreLabel.Visible = true;
            PDCurrentScoreLabel.Visible = true;

            Player1DealButton.Enabled = true;
            Player2DealButton.Enabled = false;
            Player1StickButton.Enabled = true;
            Player2StickButton.Enabled = false;
        }

        private void Player1DealButton_Click(object sender, EventArgs e)
        {
            P1Hand.AddCard(pack.DealCard());
            CreateImage(P1Hand.Last(), P1Hand.Size - 1, 1);

            int score = P1Hand.GetScore();
            P1CurrentScoreLabel.Text = score.ToString();

            if (score >= 21 || P1images.Images.Count >= 5)
            { 
                P1EndHand();
            }
        }

        private void Player1StickButton_Click(object sender, EventArgs e)
        {
            P1EndHand();
        }

        private void P1EndHand()
        {
            Player1DealButton.Enabled = false;
            Player2DealButton.Enabled = true;
            Player1StickButton.Enabled = false;
            Player2StickButton.Enabled = true;
        }

        private void Player2DealButton_Click(object sender, EventArgs e)
        {
            P2Hand.AddCard(pack.DealCard());
            CreateImage(P2Hand.Last(), P2Hand.Size - 1, 2);

            int score = P2Hand.GetScore();
            P2CurrentScoreLabel.Text = score.ToString();

            if (score >= 21 || P2images.Images.Count >= 5)
            {
                P2EndHand();
            }
        }

        private void Player2StickButton_Click(object sender, EventArgs e)
        {
            P2EndHand();
        }

        private void P2EndHand()
        {
            Player1DealButton.Enabled = false;
            Player2DealButton.Enabled = false;
            Player1StickButton.Enabled = false;
            Player2StickButton.Enabled = false;
        }

        private void PlayDealer()
        {
            CalculateWin();
        }

        private void CalculateWin()
        {
            int p1Score = AugmentScore(P1Hand.GetScore(), P1Hand.Cards.Count);
            int p2Score = AugmentScore(P2Hand.GetScore(), P2Hand.Cards.Count);

            if (p1Score > p2Score)
            {
                MessageBox.Show("Player 1 won");
                P1longScore++;
                P1ScoreLabel.Text = P1longScore.ToString();
            }
            else if (p1Score < p2Score)
            {
                MessageBox.Show("Player 2 won");
                P2longScore++;
                P2ScoreLabel.Text = P2longScore.ToString();
            }
            else if (p1Score == p2Score)
            {
                MessageBox.Show("There was a draw");
                P1longScore++;
                P1ScoreLabel.Text = P1longScore.ToString();
                P2longScore++;
                P2ScoreLabel.Text = P2longScore.ToString();
            }
        }

        private int AugmentScore(int score, int num)
        {
            if (score > 21)
            {
                score = 0;
            }
            else if (score == 21 && num == 2)
            {
                score = 100;
            }
            else if (score <= 21 && num >= 5)
            {
                score = 50;
            }
            return score;
        }

        private void CreateImage(Card card, int index, int player)
        {
            // Image name example: _1c 1 is the rank, c first character of suit (clubs)  
            string imagename = "_" + card.GetRank().ToString() + card.GetSuitAsString().ToLower()[0];
            // get the resource from Resources (casted to Image)
            Image cardimage = (Image)rm.GetObject(imagename);

            if (player == 1)
            {
                P1images.Images.Add(cardimage);
            }
            else if (player == 2)
            {
                P2images.Images.Add(cardimage);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Player should be 1 or 2");
            }

            // force a call to the Paint method of the form
            Invalidate();
        }

        private void FormBlackJack_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < P1images.Images.Count; i++)
            {
                // (image, X, Y, Width, Height) 
                // cards will be spaced every 100 pixels (i*100)
                g.DrawImage(P1images.Images[i], 100 + i * 100, 100, 72, 96);
            }
            for (int i = 0; i < P2images.Images.Count; i++)
            {
                g.DrawImage(P2images.Images[i], 100 + i * 100, 348, 72, 96);
            }
        }

        
    }
}

