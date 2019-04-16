using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Calculator : Form
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "3";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "4";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "5";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "6";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "0";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "+";
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "-";
        }

        private void btnMulitply_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "*";
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "/";
        }

        private void btnOpenBracket_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "(";
        }

        private void btnClosedBracket_Click(object sender, EventArgs e)
        {
            txtMessage.Text += ")";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtMessage.Text = "";
        }

        private void btnDecimal_Click(object sender, EventArgs e)
        {
            txtMessage.Text += ".";
        }

        private void btnIndices_Click(object sender, EventArgs e)
        {
            txtMessage.Text += "^";
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                var input = txtMessage.Text;

                var equation = EquationHelper.RemoveWhitespace(input);

                if (EquationValidator.IsEquationValid(equation))
                {
                    var result = EquationTreeGenerator.Calculation(equation).getValue();
                    txtMessage.Text = result.ToString();

                    lblMessage.Text = "Enter another equation";
                }
                else
                {
                    lblMessage.Text = "Invalid Equation! Please try again";
                }
            }
            catch (InvalidEquationException ex)
            {
                lblMessage.Text = ex.Message;
            }
        }
    }
}
