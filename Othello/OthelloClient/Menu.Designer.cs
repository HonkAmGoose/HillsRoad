namespace Othello
{
    partial class OthelloMenu
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
            this.OfflineVsHumanButton = new System.Windows.Forms.Button();
            this.OnlineChallengeButton = new System.Windows.Forms.Button();
            this.StatisticsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "OTHELLO";
            // 
            // OfflineVsHumanButton
            // 
            this.OfflineVsHumanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfflineVsHumanButton.Location = new System.Drawing.Point(100, 200);
            this.OfflineVsHumanButton.Name = "OfflineVsHumanButton";
            this.OfflineVsHumanButton.Size = new System.Drawing.Size(240, 80);
            this.OfflineVsHumanButton.TabIndex = 4;
            this.OfflineVsHumanButton.Text = "Offline vs Human";
            this.OfflineVsHumanButton.UseVisualStyleBackColor = true;
            this.OfflineVsHumanButton.Click += new System.EventHandler(this.OfflineVsHumanButton_Click);
            // 
            // OnlineChallengeButton
            // 
            this.OnlineChallengeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OnlineChallengeButton.Location = new System.Drawing.Point(100, 300);
            this.OnlineChallengeButton.Name = "OnlineChallengeButton";
            this.OnlineChallengeButton.Size = new System.Drawing.Size(240, 80);
            this.OnlineChallengeButton.TabIndex = 5;
            this.OnlineChallengeButton.Text = "Online Challenge";
            this.OnlineChallengeButton.UseVisualStyleBackColor = true;
            this.OnlineChallengeButton.Click += new System.EventHandler(this.OnlineChallengeButton_Click);
            // 
            // StatisticsButton
            // 
            this.StatisticsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatisticsButton.Location = new System.Drawing.Point(100, 400);
            this.StatisticsButton.Name = "StatisticsButton";
            this.StatisticsButton.Size = new System.Drawing.Size(240, 80);
            this.StatisticsButton.TabIndex = 6;
            this.StatisticsButton.Text = "Statistics";
            this.StatisticsButton.UseVisualStyleBackColor = true;
            this.StatisticsButton.Click += new System.EventHandler(this.StatisticsButton_Click);
            // 
            // OthelloMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 521);
            this.Controls.Add(this.StatisticsButton);
            this.Controls.Add(this.OnlineChallengeButton);
            this.Controls.Add(this.OfflineVsHumanButton);
            this.Controls.Add(this.label1);
            this.Name = "OthelloMenu";
            this.Text = "Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OfflineVsHumanButton;
        private System.Windows.Forms.Button OnlineChallengeButton;
        private System.Windows.Forms.Button StatisticsButton;
    }
}