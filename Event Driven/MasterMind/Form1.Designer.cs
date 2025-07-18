namespace MasterMind
{
    partial class FormMM
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
            this.scoreboard = new System.Windows.Forms.Panel();
            this.buttonNewGame = new System.Windows.Forms.Button();
            this.buttonCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scoreboard
            // 
            this.scoreboard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scoreboard.Location = new System.Drawing.Point(217, 50);
            this.scoreboard.Name = "scoreboard";
            this.scoreboard.Size = new System.Drawing.Size(40, 450);
            this.scoreboard.TabIndex = 1;
            this.scoreboard.Paint += new System.Windows.Forms.PaintEventHandler(this.scoreboard_Paint);
            // 
            // buttonNewGame
            // 
            this.buttonNewGame.Location = new System.Drawing.Point(303, 92);
            this.buttonNewGame.Name = "buttonNewGame";
            this.buttonNewGame.Size = new System.Drawing.Size(75, 23);
            this.buttonNewGame.TabIndex = 2;
            this.buttonNewGame.Text = "New Game";
            this.buttonNewGame.UseVisualStyleBackColor = true;
            this.buttonNewGame.Click += new System.EventHandler(this.buttonNewGame_Click);
            // 
            // buttonCheck
            // 
            this.buttonCheck.Location = new System.Drawing.Point(156, 506);
            this.buttonCheck.Name = "buttonCheck";
            this.buttonCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonCheck.TabIndex = 3;
            this.buttonCheck.Text = "Check";
            this.buttonCheck.UseVisualStyleBackColor = true;
            this.buttonCheck.Click += new System.EventHandler(this.buttonCheck_Click);
            // 
            // FormMM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 541);
            this.Controls.Add(this.buttonCheck);
            this.Controls.Add(this.buttonNewGame);
            this.Controls.Add(this.scoreboard);
            this.DoubleBuffered = true;
            this.Name = "FormMM";
            this.Text = "MasterMind";
            this.Load += new System.EventHandler(this.FormMM_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel scoreboard;
        private System.Windows.Forms.Button buttonNewGame;
        private System.Windows.Forms.Button buttonCheck;
    }
}

