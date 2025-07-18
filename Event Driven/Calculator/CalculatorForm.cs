using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        private void CalculatorForm_Load(object sender, EventArgs e)
        {

        }

        // Helper Functions //

        private double fullAnswer = 0;

        private double[] ParseOperands()
        {
            double operand1 = 0, operand2 = 0;
            try
            {
                operand1 = double.Parse(Operand1TextBox.Text);
                operand2 = double.Parse(Operand2TextBox.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid input");
            }

            return new double[] { operand1, operand2 };
        }

        private void OutputNewResult(double answer)
        {
            fullAnswer = answer;
            OutputOldResult();
        }

        private void OutputOldResult()
        {
            double answer = fullAnswer;
            if (RoundCheckBox.Checked == true)
            {
                answer = Math.Round(answer, int.Parse(DecimalPlaces.Value.ToString()));
            }
            ResultTextBox.Text = answer.ToString();
        }

        // Event Functions //

        private void AddButton_Click(object sender, EventArgs e)
        {
            double[] operands = ParseOperands();
            OutputNewResult(operands[0] + operands[1]);
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            double[] operands = ParseOperands();
            OutputNewResult(operands[0] - operands[1]);
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            double[] operands = ParseOperands();
            OutputNewResult(operands[0] * operands[1]);
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            double[] operands = ParseOperands();
            OutputNewResult(operands[0] / operands[1]);
        }

        private void RoundCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            OutputOldResult();
        }

        private void DecimalPlaces_ValueChanged(object sender, EventArgs e)
        {
            OutputOldResult();
        }
    }
}
