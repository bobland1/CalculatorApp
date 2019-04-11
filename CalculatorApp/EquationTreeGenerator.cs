using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public interface IEquationNode
    {
        double getValue();
    }

    public class EquationTreeGenerator : IEquationNode
    {
        private IEquationNode Left;
        private IEquationNode Right;
        private IOperator Operator;

        public EquationTreeGenerator(string leftSide, string rightSide, IOperator Operator)
        {
            Left = CalculationGenerator.Calculation(leftSide);
            Right = CalculationGenerator.Calculation(rightSide);
            this.Operator = Operator;
        }

        public double getValue()
        {
            return Operator.DoMaths(Left.getValue(), Right.getValue());
        }
    }

    public class Number : IEquationNode
    {
        private double num;
        public Number(string equation)
        {
            try
            {
                if (!double.TryParse(equation, out num))
                {
                    throw new BadValueException("Bad Value Returned!");
                }
            }
            catch (BadValueException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public double getValue()
        {
            return num;
        }
    }
}
