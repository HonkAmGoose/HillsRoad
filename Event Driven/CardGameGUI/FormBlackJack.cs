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
            g = CreateGraphics();
            // C# ImageList Use: Windows Forms. 
            //ImageList provides a container for image data. 
            //The control is not visible directly. It is instead referenced from other controls such as ListView, 
            // which acquire the images from index values into the ImageList.
            imageList.ImageSize = new Size(72, 96); // Sets the size of the images in the image list.
            pack.Shuffle();
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
                pack.AddCard(P2Hand.RemoveCard(P1Hand.First()));
            }

            imageList.Images.Clear();
            Invalidate(); // forces to repaint the form

            P1Hand.AddCard(pack.DealCard());
            CreateImage(P1Hand.Last(), 0);

            P2Hand.AddCard(pack.DealCard());
            CreateImage(P2Hand.Last(), 0);

            P1CurrentScoreLabel.Visible = true;
        }

        private void Player1DealButton_Click(object sender, EventArgs e)
        {
            P1Hand.AddCard(pack.DealCard());
            CreateImage(P1Hand.Last(), P1Hand.Size - 1);
        }

        private void Player2DealButton_Click(object sender, EventArgs e)
        {
            P2Hand.AddCard(pack.DealCard());
            CreateImage(P2Hand.Last(), P2Hand.Size - 1);
        }

        private void CreateImage(Card card, int index)
        {
            // Image name exampke: _1c 1 is the rank, c first character of suit (clubs)  
            string imagename = "_" + card.GetRank().ToString() + card.GetSuitAsString().ToLower()[0];
            // get the resource from Resources (casted to Image)
            Image cardimage = (Image)rm.GetObject(imagename);

            imageList.Images.Add(cardimage);
            // force a call to the Paint method of the form
            Invalidate();
        }

        private void FormBlackJack_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < imageList.Images.Count; i++)
            {
                // (image, X, Y, Width, Height) 
                // cards will be spaced every 100 pixels (i*100)
                g.DrawImage(imageList.Images[i], 100 + i * 100, 100 + (248 * (i % 2)), 72, 96);
            }
        }
    }
}

