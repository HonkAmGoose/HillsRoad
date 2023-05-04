namespace TicTacToe
{
    partial class TicTacToeForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.newGameButton = new System.Windows.Forms.Button();
            this.StartPlayerGroupBox = new System.Windows.Forms.GroupBox();
            this.XStartRadioButton = new System.Windows.Forms.RadioButton();
            this.OStartRadioButton = new System.Windows.Forms.RadioButton();
            this.StartPlayerGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(41, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Noughts and Crosses";
            // 
            // newGameButton
            // 
            this.newGameButton.Location = new System.Drawing.Point(66, 460);
            this.newGameButton.Name = "newGameButton";
            this.newGameButton.Size = new System.Drawing.Size(75, 23);
            this.newGameButton.TabIndex = 1;
            this.newGameButton.Text = "New Game";
            this.newGameButton.UseVisualStyleBackColor = true;
            this.newGameButton.Click += new System.EventHandler(this.newGameButton_Click);
            // 
            // StartPlayerGroupBox
            // 
            this.StartPlayerGroupBox.Controls.Add(this.OStartRadioButton);
            this.StartPlayerGroupBox.Controls.Add(this.XStartRadioButton);
            this.StartPlayerGroupBox.Location = new System.Drawing.Point(181, 447);
            this.StartPlayerGroupBox.Name = "StartPlayerGroupBox";
            this.StartPlayerGroupBox.Size = new System.Drawing.Size(152, 41);
            this.StartPlayerGroupBox.TabIndex = 2;
            this.StartPlayerGroupBox.TabStop = false;
            this.StartPlayerGroupBox.Text = "Start Player";
            // 
            // XStartRadioButton
            // 
            this.XStartRadioButton.AutoSize = true;
            this.XStartRadioButton.Location = new System.Drawing.Point(6, 19);
            this.XStartRadioButton.Name = "XStartRadioButton";
            this.XStartRadioButton.Size = new System.Drawing.Size(64, 17);
            this.XStartRadioButton.TabIndex = 0;
            this.XStartRadioButton.TabStop = true;
            this.XStartRadioButton.Text = "Player X";
            this.XStartRadioButton.UseVisualStyleBackColor = true;
            // 
            // OStartRadioButton
            // 
            this.OStartRadioButton.AutoSize = true;
            this.OStartRadioButton.Location = new System.Drawing.Point(76, 19);
            this.OStartRadioButton.Name = "OStartRadioButton";
            this.OStartRadioButton.Size = new System.Drawing.Size(65, 17);
            this.OStartRadioButton.TabIndex = 1;
            this.OStartRadioButton.TabStop = true;
            this.OStartRadioButton.Text = "Player O";
            this.OStartRadioButton.UseVisualStyleBackColor = true;
            // 
            // TicTacToeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 501);
            this.Controls.Add(this.StartPlayerGroupBox);
            this.Controls.Add(this.newGameButton);
            this.Controls.Add(this.label1);
            this.Name = "TicTacToeForm";
            this.Text = "Noughts and Crosses";
            this.Load += new System.EventHandler(this.TicTacToeForm_Load);
            this.StartPlayerGroupBox.ResumeLayout(false);
            this.StartPlayerGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newGameButton;
        private System.Windows.Forms.GroupBox StartPlayerGroupBox;
        private System.Windows.Forms.RadioButton XStartRadioButton;
        private System.Windows.Forms.RadioButton OStartRadioButton;
    }
}

