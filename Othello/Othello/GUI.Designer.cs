namespace Othello
{
    partial class GUI
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
            this.NewGameButton = new System.Windows.Forms.Button();
            this.DisplayPanel = new System.Windows.Forms.Panel();
            this.HintButton = new System.Windows.Forms.Button();
            this.EndTurnButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BonusComboBox = new System.Windows.Forms.ComboBox();
            this.BlackCounterLabel = new System.Windows.Forms.Label();
            this.BlackWinLabel = new System.Windows.Forms.Label();
            this.WhiteCounterLabel = new System.Windows.Forms.Label();
            this.WhiteWinLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NewGameButton
            // 
            this.NewGameButton.Location = new System.Drawing.Point(332, 425);
            this.NewGameButton.Name = "NewGameButton";
            this.NewGameButton.Size = new System.Drawing.Size(80, 30);
            this.NewGameButton.TabIndex = 0;
            this.NewGameButton.Text = "New Game";
            this.NewGameButton.UseVisualStyleBackColor = true;
            this.NewGameButton.Click += new System.EventHandler(this.NewGameButton_Click);
            // 
            // DisplayPanel
            // 
            this.DisplayPanel.Location = new System.Drawing.Point(10, 10);
            this.DisplayPanel.Name = "DisplayPanel";
            this.DisplayPanel.Size = new System.Drawing.Size(405, 405);
            this.DisplayPanel.TabIndex = 1;
            this.DisplayPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.DisplayPanel_Paint);
            this.DisplayPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.DisplayPanel_MouseUp);
            // 
            // HintButton
            // 
            this.HintButton.Location = new System.Drawing.Point(10, 475);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(80, 30);
            this.HintButton.TabIndex = 2;
            this.HintButton.Text = "Hint";
            this.HintButton.UseVisualStyleBackColor = true;
            this.HintButton.Click += new System.EventHandler(this.HintButton_Click);
            // 
            // EndTurnButton
            // 
            this.EndTurnButton.Location = new System.Drawing.Point(10, 425);
            this.EndTurnButton.Name = "EndTurnButton";
            this.EndTurnButton.Size = new System.Drawing.Size(80, 30);
            this.EndTurnButton.TabIndex = 4;
            this.EndTurnButton.Text = "End Turn";
            this.EndTurnButton.UseVisualStyleBackColor = true;
            this.EndTurnButton.Click += new System.EventHandler(this.EndTurnButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 425);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Counters - Wins";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(125, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "B:";
            // 
            // BonusComboBox
            // 
            this.BonusComboBox.FormattingEnabled = true;
            this.BonusComboBox.Items.AddRange(new object[] {
            "No Bonus",
            "Black 1",
            "Black 2",
            "Black 3",
            "Black 4",
            "White 1",
            "White 2",
            "White 3",
            "White 4"});
            this.BonusComboBox.Location = new System.Drawing.Point(332, 475);
            this.BonusComboBox.Name = "BonusComboBox";
            this.BonusComboBox.Size = new System.Drawing.Size(80, 21);
            this.BonusComboBox.TabIndex = 7;
            // 
            // BlackCounterLabel
            // 
            this.BlackCounterLabel.AutoSize = true;
            this.BlackCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackCounterLabel.Location = new System.Drawing.Point(175, 450);
            this.BlackCounterLabel.Name = "BlackCounterLabel";
            this.BlackCounterLabel.Size = new System.Drawing.Size(24, 25);
            this.BlackCounterLabel.TabIndex = 8;
            this.BlackCounterLabel.Text = "0";
            // 
            // BlackWinLabel
            // 
            this.BlackWinLabel.AutoSize = true;
            this.BlackWinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BlackWinLabel.Location = new System.Drawing.Point(225, 450);
            this.BlackWinLabel.Name = "BlackWinLabel";
            this.BlackWinLabel.Size = new System.Drawing.Size(24, 25);
            this.BlackWinLabel.TabIndex = 9;
            this.BlackWinLabel.Text = "0";
            // 
            // WhiteCounterLabel
            // 
            this.WhiteCounterLabel.AutoSize = true;
            this.WhiteCounterLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteCounterLabel.Location = new System.Drawing.Point(175, 480);
            this.WhiteCounterLabel.Name = "WhiteCounterLabel";
            this.WhiteCounterLabel.Size = new System.Drawing.Size(24, 25);
            this.WhiteCounterLabel.TabIndex = 10;
            this.WhiteCounterLabel.Text = "0";
            // 
            // WhiteWinLabel
            // 
            this.WhiteWinLabel.AutoSize = true;
            this.WhiteWinLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhiteWinLabel.Location = new System.Drawing.Point(225, 480);
            this.WhiteWinLabel.Name = "WhiteWinLabel";
            this.WhiteWinLabel.Size = new System.Drawing.Size(24, 25);
            this.WhiteWinLabel.TabIndex = 9;
            this.WhiteWinLabel.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(125, 480);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 25);
            this.label7.TabIndex = 11;
            this.label7.Text = "W:";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 521);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.WhiteWinLabel);
            this.Controls.Add(this.WhiteCounterLabel);
            this.Controls.Add(this.BlackWinLabel);
            this.Controls.Add(this.BlackCounterLabel);
            this.Controls.Add(this.BonusComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EndTurnButton);
            this.Controls.Add(this.HintButton);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.NewGameButton);
            this.Name = "GUI";
            this.Text = "Othello Game";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Button HintButton;
        private System.Windows.Forms.Button EndTurnButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox BonusComboBox;
        private System.Windows.Forms.Label BlackCounterLabel;
        private System.Windows.Forms.Label BlackWinLabel;
        private System.Windows.Forms.Label WhiteCounterLabel;
        private System.Windows.Forms.Label WhiteWinLabel;
        private System.Windows.Forms.Label label7;
    }
}

