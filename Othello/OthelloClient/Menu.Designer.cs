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
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoggedInCheckBox = new System.Windows.Forms.CheckBox();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.OfflineVsHumanButton = new System.Windows.Forms.Button();
            this.OnlineChallengeButton = new System.Windows.Forms.Button();
            this.OfflineVsAIButton = new System.Windows.Forms.Button();
            this.ComingSoonLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "OTHELLO";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(340, 10);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(50, 40);
            this.LoginButton.TabIndex = 1;
            this.LoginButton.Text = "Log in";
            this.LoginButton.UseVisualStyleBackColor = true;
            // 
            // LoggedInCheckBox
            // 
            this.LoggedInCheckBox.AutoSize = true;
            this.LoggedInCheckBox.Enabled = false;
            this.LoggedInCheckBox.Location = new System.Drawing.Point(396, 24);
            this.LoggedInCheckBox.Name = "LoggedInCheckBox";
            this.LoggedInCheckBox.Size = new System.Drawing.Size(15, 14);
            this.LoggedInCheckBox.TabIndex = 2;
            this.LoggedInCheckBox.UseVisualStyleBackColor = true;
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(340, 55);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(75, 25);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
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
            // OfflineVsAIButton
            // 
            this.OfflineVsAIButton.Enabled = false;
            this.OfflineVsAIButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OfflineVsAIButton.Location = new System.Drawing.Point(100, 400);
            this.OfflineVsAIButton.Name = "OfflineVsAIButton";
            this.OfflineVsAIButton.Size = new System.Drawing.Size(240, 80);
            this.OfflineVsAIButton.TabIndex = 6;
            this.OfflineVsAIButton.Text = "Offline vs AI";
            this.OfflineVsAIButton.UseVisualStyleBackColor = true;
            // 
            // ComingSoonLabel
            // 
            this.ComingSoonLabel.AutoSize = true;
            this.ComingSoonLabel.BackColor = System.Drawing.Color.MistyRose;
            this.ComingSoonLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComingSoonLabel.ForeColor = System.Drawing.Color.Red;
            this.ComingSoonLabel.Location = new System.Drawing.Point(160, 405);
            this.ComingSoonLabel.Name = "ComingSoonLabel";
            this.ComingSoonLabel.Size = new System.Drawing.Size(114, 20);
            this.ComingSoonLabel.TabIndex = 7;
            this.ComingSoonLabel.Text = "Coming soon...";
            // 
            // OthelloMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 521);
            this.Controls.Add(this.ComingSoonLabel);
            this.Controls.Add(this.OfflineVsAIButton);
            this.Controls.Add(this.OnlineChallengeButton);
            this.Controls.Add(this.OfflineVsHumanButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.LoggedInCheckBox);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.label1);
            this.Name = "OthelloMenu";
            this.Text = "Menu";
            this.Enter += new System.EventHandler(this.OthelloMenu_Enter);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.CheckBox LoggedInCheckBox;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button OfflineVsHumanButton;
        private System.Windows.Forms.Button OnlineChallengeButton;
        private System.Windows.Forms.Button OfflineVsAIButton;
        private System.Windows.Forms.Label ComingSoonLabel;
    }
}