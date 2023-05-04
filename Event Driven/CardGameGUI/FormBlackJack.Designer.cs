namespace CardGameGUI
{
    partial class FormBlackJack
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.NewGameButton = new System.Windows.Forms.Button();
            this.Player1DealButton = new System.Windows.Forms.Button();
            this.P1CurrentScoreLabel = new System.Windows.Forms.Label();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.P1ScoreLabel = new System.Windows.Forms.Label();
            this.P2ScoreLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player2DealButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(34, 11);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(75, 42);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // Player1DealButton
            // 
            this.Player1DealButton.Location = new System.Drawing.Point(64, 224);
            this.Player1DealButton.Name = "Player1DealButton";
            this.Player1DealButton.Size = new System.Drawing.Size(148, 46);
            this.Player1DealButton.TabIndex = 2;
            this.Player1DealButton.Text = "Player 1 Deal";
            this.Player1DealButton.UseVisualStyleBackColor = true;
            this.Player1DealButton.Click += new System.EventHandler(this.Player1DealButton_Click);
            // 
            // P1CurrentScoreLabel
            // 
            this.P1CurrentScoreLabel.AutoSize = true;
            this.P1CurrentScoreLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1CurrentScoreLabel.Location = new System.Drawing.Point(30, 148);
            this.P1CurrentScoreLabel.Name = "P1CurrentScoreLabel";
            this.P1CurrentScoreLabel.Size = new System.Drawing.Size(19, 21);
            this.P1CurrentScoreLabel.TabIndex = 3;
            this.P1CurrentScoreLabel.Text = "0";
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(676, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(651, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "P1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(728, 50);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "P2";
            // 
            // P1ScoreLabel
            // 
            this.P1ScoreLabel.AutoSize = true;
            this.P1ScoreLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P1ScoreLabel.Location = new System.Drawing.Point(656, 80);
            this.P1ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P1ScoreLabel.Name = "P1ScoreLabel";
            this.P1ScoreLabel.Size = new System.Drawing.Size(19, 21);
            this.P1ScoreLabel.TabIndex = 7;
            this.P1ScoreLabel.Text = "0";
            // 
            // P2ScoreLabel
            // 
            this.P2ScoreLabel.AutoSize = true;
            this.P2ScoreLabel.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.P2ScoreLabel.Location = new System.Drawing.Point(732, 80);
            this.P2ScoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.P2ScoreLabel.Name = "P2ScoreLabel";
            this.P2ScoreLabel.Size = new System.Drawing.Size(19, 21);
            this.P2ScoreLabel.TabIndex = 8;
            this.P2ScoreLabel.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 21);
            this.label4.TabIndex = 9;
            this.label4.Text = "Player 1";
            // 
            // Player2DealButton
            // 
            this.Player2DealButton.Location = new System.Drawing.Point(64, 472);
            this.Player2DealButton.Name = "Player2DealButton";
            this.Player2DealButton.Size = new System.Drawing.Size(148, 46);
            this.Player2DealButton.TabIndex = 10;
            this.Player2DealButton.Text = "Player 2 Deal";
            this.Player2DealButton.UseVisualStyleBackColor = true;
            this.Player2DealButton.Click += new System.EventHandler(this.Player2DealButton_Click);
            // 
            // FormBlackJack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 561);
            this.Controls.Add(this.Player2DealButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.P2ScoreLabel);
            this.Controls.Add(this.P1ScoreLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.P1CurrentScoreLabel);
            this.Controls.Add(this.Player1DealButton);
            this.Controls.Add(this.NewGameButton);
            this.Name = "FormBlackJack";
            this.Text = "Card Game";
            this.Load += new System.EventHandler(this.FormBlackJack_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormBlackJack_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Button Player1DealButton;
        private System.Windows.Forms.Label P1CurrentScoreLabel;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label P1ScoreLabel;
        private System.Windows.Forms.Label P2ScoreLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Player2DealButton;
    }
}

