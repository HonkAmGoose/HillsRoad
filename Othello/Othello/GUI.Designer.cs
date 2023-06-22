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
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 561);
            this.Controls.Add(this.EndTurnButton);
            this.Controls.Add(this.HintButton);
            this.Controls.Add(this.DisplayPanel);
            this.Controls.Add(this.NewGameButton);
            this.Name = "GUI";
            this.Text = "Othello Game";
            this.Load += new System.EventHandler(this.GUI_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGameButton;
        private System.Windows.Forms.Panel DisplayPanel;
        private System.Windows.Forms.Button HintButton;
        private System.Windows.Forms.Button EndTurnButton;
    }
}

