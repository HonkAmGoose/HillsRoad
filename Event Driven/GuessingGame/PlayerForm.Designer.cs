namespace GuessingGame
{
    partial class PlayerForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.GameMenuFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.NewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.GuessesLeftLabel = new System.Windows.Forms.Label();
            this.NewButton = new System.Windows.Forms.Button();
            this.GuessTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GuessButton = new System.Windows.Forms.Button();
            this.ResponseLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.GuessesListBox = new System.Windows.Forms.ListBox();
            this.PlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.ComputerRadioButton = new System.Windows.Forms.RadioButton();
            this.MeRadioButton = new System.Windows.Forms.RadioButton();
            this.menuStrip1.SuspendLayout();
            this.PlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMenuFolder});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(334, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // GameMenuFolder
            // 
            this.GameMenuFolder.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewMenuItem,
            this.OpenMenuItem,
            this.SaveMenuItem,
            this.ExitMenuItem});
            this.GameMenuFolder.Name = "GameMenuFolder";
            this.GameMenuFolder.Size = new System.Drawing.Size(50, 20);
            this.GameMenuFolder.Text = "Game";
            // 
            // NewMenuItem
            // 
            this.NewMenuItem.Name = "NewMenuItem";
            this.NewMenuItem.Size = new System.Drawing.Size(103, 22);
            this.NewMenuItem.Text = "New";
            this.NewMenuItem.Click += new System.EventHandler(this.NewMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(103, 22);
            this.OpenMenuItem.Text = "Open";
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(103, 22);
            this.SaveMenuItem.Text = "Save";
            // 
            // ExitMenuItem
            // 
            this.ExitMenuItem.Name = "ExitMenuItem";
            this.ExitMenuItem.Size = new System.Drawing.Size(103, 22);
            this.ExitMenuItem.Text = "Exit";
            this.ExitMenuItem.Click += new System.EventHandler(this.ExitMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of guesses left:";
            // 
            // GuessesLeftLabel
            // 
            this.GuessesLeftLabel.AutoSize = true;
            this.GuessesLeftLabel.Location = new System.Drawing.Point(136, 35);
            this.GuessesLeftLabel.Name = "GuessesLeftLabel";
            this.GuessesLeftLabel.Size = new System.Drawing.Size(19, 13);
            this.GuessesLeftLabel.TabIndex = 2;
            this.GuessesLeftLabel.Text = "10";
            // 
            // NewButton
            // 
            this.NewButton.Location = new System.Drawing.Point(161, 31);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 5;
            this.NewButton.Text = "New";
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // GuessTextBox
            // 
            this.GuessTextBox.Location = new System.Drawing.Point(125, 72);
            this.GuessTextBox.Name = "GuessTextBox";
            this.GuessTextBox.Size = new System.Drawing.Size(30, 20);
            this.GuessTextBox.TabIndex = 3;
            this.GuessTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GuessTextBox_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Guess:";
            // 
            // GuessButton
            // 
            this.GuessButton.Location = new System.Drawing.Point(161, 71);
            this.GuessButton.Name = "GuessButton";
            this.GuessButton.Size = new System.Drawing.Size(75, 23);
            this.GuessButton.TabIndex = 4;
            this.GuessButton.Text = "Guess";
            this.GuessButton.UseVisualStyleBackColor = true;
            this.GuessButton.Click += new System.EventHandler(this.GuessButton_Click);
            // 
            // ResponseLabel
            // 
            this.ResponseLabel.AutoSize = true;
            this.ResponseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResponseLabel.ForeColor = System.Drawing.Color.Red;
            this.ResponseLabel.Location = new System.Drawing.Point(12, 115);
            this.ResponseLabel.Name = "ResponseLabel";
            this.ResponseLabel.Size = new System.Drawing.Size(83, 25);
            this.ResponseLabel.TabIndex = 7;
            this.ResponseLabel.Text = "Testing";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Your previous guesses:";
            // 
            // GuessesListBox
            // 
            this.GuessesListBox.FormattingEnabled = true;
            this.GuessesListBox.Location = new System.Drawing.Point(12, 180);
            this.GuessesListBox.Name = "GuessesListBox";
            this.GuessesListBox.Size = new System.Drawing.Size(120, 95);
            this.GuessesListBox.TabIndex = 9;
            // 
            // PlayerGroupBox
            // 
            this.PlayerGroupBox.Controls.Add(this.ComputerRadioButton);
            this.PlayerGroupBox.Controls.Add(this.MeRadioButton);
            this.PlayerGroupBox.Location = new System.Drawing.Point(161, 160);
            this.PlayerGroupBox.Name = "PlayerGroupBox";
            this.PlayerGroupBox.Size = new System.Drawing.Size(120, 72);
            this.PlayerGroupBox.TabIndex = 10;
            this.PlayerGroupBox.TabStop = false;
            this.PlayerGroupBox.Text = "Who guesses?";
            // 
            // ComputerRadioButton
            // 
            this.ComputerRadioButton.AutoSize = true;
            this.ComputerRadioButton.Location = new System.Drawing.Point(7, 44);
            this.ComputerRadioButton.Name = "ComputerRadioButton";
            this.ComputerRadioButton.Size = new System.Drawing.Size(70, 17);
            this.ComputerRadioButton.TabIndex = 1;
            this.ComputerRadioButton.TabStop = true;
            this.ComputerRadioButton.Text = "Computer";
            this.ComputerRadioButton.UseVisualStyleBackColor = true;
            this.ComputerRadioButton.CheckedChanged += new System.EventHandler(this.ComputerRadioButton_CheckedChanged);
            // 
            // MeRadioButton
            // 
            this.MeRadioButton.AutoSize = true;
            this.MeRadioButton.Location = new System.Drawing.Point(7, 20);
            this.MeRadioButton.Name = "MeRadioButton";
            this.MeRadioButton.Size = new System.Drawing.Size(40, 17);
            this.MeRadioButton.TabIndex = 0;
            this.MeRadioButton.TabStop = true;
            this.MeRadioButton.Text = "Me";
            this.MeRadioButton.UseVisualStyleBackColor = true;
            // 
            // PlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 311);
            this.Controls.Add(this.PlayerGroupBox);
            this.Controls.Add(this.GuessesListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ResponseLabel);
            this.Controls.Add(this.GuessButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.GuessTextBox);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.GuessesLeftLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayerForm";
            this.Text = "Guessing Game";
            this.Load += new System.EventHandler(this.PlayerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.PlayerGroupBox.ResumeLayout(false);
            this.PlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem GameMenuFolder;
        private System.Windows.Forms.ToolStripMenuItem NewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label GuessesLeftLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.TextBox GuessTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button GuessButton;
        private System.Windows.Forms.Label ResponseLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox GuessesListBox;
        private System.Windows.Forms.GroupBox PlayerGroupBox;
        private System.Windows.Forms.RadioButton ComputerRadioButton;
        private System.Windows.Forms.RadioButton MeRadioButton;
    }
}

