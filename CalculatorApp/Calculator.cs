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

        private void button1_Click(object sender, EventArgs e)
        {
            Process();
        }

        private void Process()
        {
            try
            {
                var input = txtEquation.Text;

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    lblMessage.Text = "Exiting..";
                    Environment.Exit(-1);
                }

                var equation = EquationHelper.RemoveWhitespace(input);

                if (EquationValidator.IsEquationValid(equation))
                {
                    var result = EquationTreeGenerator.Calculation(equation).getValue();
                    txtResult.Text = result.ToString();
                    txtResult.Refresh();


                    lblMessage.Text = "Enter another equation \n or Type 'exit' to exit";
                    lblMessage.Refresh();
                }
                else
                {
                    lblMessage.Text = "Invalid Equation! Please try again";
                    lblMessage.Refresh();
                }
            }
            catch (InvalidEquationException e)
            {
                lblMessage.Text = e.Message;
            }
        }
    }
}
