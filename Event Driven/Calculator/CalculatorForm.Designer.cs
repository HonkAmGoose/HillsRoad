namespace Calculator
{
    partial class CalculatorForm
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
            this.AddButton = new System.Windows.Forms.Button();
            this.Operand1TextBox = new System.Windows.Forms.TextBox();
            this.Operand2TextBox = new System.Windows.Forms.TextBox();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.Operand1Label = new System.Windows.Forms.Label();
            this.Operand2Label = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.MultiplyButton = new System.Windows.Forms.Button();
            this.SubtractButton = new System.Windows.Forms.Button();
            this.DivideButton = new System.Windows.Forms.Button();
            this.RoundCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(274, 61);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // Operand1TextBox
            // 
            this.Operand1TextBox.Location = new System.Drawing.Point(137, 61);
            this.Operand1TextBox.Name = "Operand1TextBox";
            this.Operand1TextBox.Size = new System.Drawing.Size(100, 20);
            this.Operand1TextBox.TabIndex = 1;
            // 
            // Operand2TextBox
            // 
            this.Operand2TextBox.Location = new System.Drawing.Point(137, 103);
            this.Operand2TextBox.Name = "Operand2TextBox";
            this.Operand2TextBox.Size = new System.Drawing.Size(100, 20);
            this.Operand2TextBox.TabIndex = 2;
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.Location = new System.Drawing.Point(137, 170);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(100, 20);
            this.ResultTextBox.TabIndex = 3;
            // 
            // Operand1Label
            // 
            this.Operand1Label.AutoSize = true;
            this.Operand1Label.Location = new System.Drawing.Point(51, 61);
            this.Operand1Label.Name = "Operand1Label";
            this.Operand1Label.Size = new System.Drawing.Size(57, 13);
            this.Operand1Label.TabIndex = 4;
            this.Operand1Label.Text = "Operand 1";
            // 
            // Operand2Label
            // 
            this.Operand2Label.AutoSize = true;
            this.Operand2Label.Location = new System.Drawing.Point(51, 103);
            this.Operand2Label.Name = "Operand2Label";
            this.Operand2Label.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Operand2Label.Size = new System.Drawing.Size(57, 13);
            this.Operand2Label.TabIndex = 5;
            this.Operand2Label.Text = "Operand 2";
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Location = new System.Drawing.Point(51, 170);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(37, 13);
            this.ResultLabel.TabIndex = 6;
            this.ResultLabel.Text = "Result";
            // 
            // MultiplyButton
            // 
            this.MultiplyButton.Location = new System.Drawing.Point(274, 103);
            this.MultiplyButton.Name = "MultiplyButton";
            this.MultiplyButton.Size = new System.Drawing.Size(75, 23);
            this.MultiplyButton.TabIndex = 7;
            this.MultiplyButton.Text = "Multiply";
            this.MultiplyButton.UseVisualStyleBackColor = true;
            this.MultiplyButton.Click += new System.EventHandler(this.MultiplyButton_Click);
            // 
            // SubtractButton
            // 
            this.SubtractButton.Location = new System.Drawing.Point(367, 61);
            this.SubtractButton.Name = "SubtractButton";
            this.SubtractButton.Size = new System.Drawing.Size(75, 23);
            this.SubtractButton.TabIndex = 8;
            this.SubtractButton.Text = "Subtract";
            this.SubtractButton.UseVisualStyleBackColor = true;
            this.SubtractButton.Click += new System.EventHandler(this.SubtractButton_Click);
            // 
            // DivideButton
            // 
            this.DivideButton.Location = new System.Drawing.Point(367, 103);
            this.DivideButton.Name = "DivideButton";
            this.DivideButton.Size = new System.Drawing.Size(75, 23);
            this.DivideButton.TabIndex = 9;
            this.DivideButton.Text = "Divide";
            this.DivideButton.UseVisualStyleBackColor = true;
            this.DivideButton.Click += new System.EventHandler(this.DivideButton_Click);
            // 
            // RoundCheckBox
            // 
            this.RoundCheckBox.AutoSize = true;
            this.RoundCheckBox.Location = new System.Drawing.Point(274, 170);
            this.RoundCheckBox.Name = "RoundCheckBox";
            this.RoundCheckBox.Size = new System.Drawing.Size(64, 17);
            this.RoundCheckBox.TabIndex = 10;
            this.RoundCheckBox.Text = "Round?";
            this.RoundCheckBox.UseVisualStyleBackColor = true;
            this.RoundCheckBox.CheckedChanged += new System.EventHandler(this.RoundCheckBox_CheckedChanged);
            // 
            // CalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 263);
            this.Controls.Add(this.RoundCheckBox);
            this.Controls.Add(this.DivideButton);
            this.Controls.Add(this.SubtractButton);
            this.Controls.Add(this.MultiplyButton);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.Operand2Label);
            this.Controls.Add(this.Operand1Label);
            this.Controls.Add(this.ResultTextBox);
            this.Controls.Add(this.Operand2TextBox);
            this.Controls.Add(this.Operand1TextBox);
            this.Controls.Add(this.AddButton);
            this.Name = "CalculatorForm";
            this.Text = "Calculator";
            this.Load += new System.EventHandler(this.CalculatorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.TextBox Operand1TextBox;
        private System.Windows.Forms.TextBox Operand2TextBox;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Label Operand1Label;
        private System.Windows.Forms.Label Operand2Label;
        private System.Windows.Forms.Label ResultLabel;
        private System.Windows.Forms.Button MultiplyButton;
        private System.Windows.Forms.Button SubtractButton;
        private System.Windows.Forms.Button DivideButton;
        private System.Windows.Forms.CheckBox RoundCheckBox;
    }
}

