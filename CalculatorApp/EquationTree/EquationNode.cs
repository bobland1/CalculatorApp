using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Operators;

namespace CalculatorApp
{
    public class EquationNode : IEquationNode
    {
        private IEquationNode Left;
        private IEquationNode Right;
        private IOperator Operator;

        public EquationNode(string leftSide, string rightSide, IOperator Operator)
        {
            Left = EquationTreeGenerator.Calculation(leftSide);
            Right = EquationTreeGenerator.Calculation(rightSide);
            this.Operator = Operator;
        }

        public double getValue()
        {
            return Operator.DoMaths(Left.getValue(), Right.getValue());
        }
    }
}
