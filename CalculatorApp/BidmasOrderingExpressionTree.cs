using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class BidmasOrderingExpressionTree
    {
        
    }

    public static class NodeBuilder
    {
        private static List<char> OrderedOperators = new List<char>() {'-','+','*','/' };
        private static OperatorFactory Operation = new OperatorFactory();


        public static INode BuildNode(string equation)
        {
            if(equation[0] == '(' && equation[equation.Length-1] == ')')
            {
                return BuildNode(equation.Substring(1, equation.Length - 2));
            }
            if (EquationValidator.IsStringNumber(equation))
            {
                return new Number(equation);
            }


            foreach(var op in OrderedOperators)
            {
                var bracketCounter = 0;
                for(int i = 0; i < equation.Length; i++)
                {
                    if (equation[i] == '(')
                    {
                        bracketCounter++;
                    } else if (equation[i] == ')')
                    {
                        bracketCounter--;
                    }
                    if (equation[i] == op && bracketCounter == 0)
                    {
                        return new Node(equation.Substring(0, i), equation.Substring(i+1), Operation.GetOperator(equation[i]));
                    }
                }
            }

            //are both ends of equation brackets?  if so return less brackets


            

            throw new NotImplementedException();
        }
    }

    public interface INode
    {
        int getValue();
    }

    public class Node : INode
    {
        private INode Left;
        private INode Right;
        private IOperator Operator;

        public Node(string leftSide, string rightSide, IOperator Operator)
        {
            Left = NodeBuilder.BuildNode(leftSide);
            Right = NodeBuilder.BuildNode(rightSide);
            this.Operator = Operator;
        }

        public int getValue()
        {
            return Operator.DoMaths(Left.getValue(), Right.getValue());
        }
    }

    public class Number : INode
    {
        private int num;
        public Number(string equation)
        {
            num = int.Parse(equation);
        }

        public int getValue()
        {
            return num;
        }
    }
}
