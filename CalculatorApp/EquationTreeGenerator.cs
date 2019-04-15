using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Operators;

namespace CalculatorApp
{
    public static class EquationTreeGenerator
    {
        private static OperatorFactory Operation = new OperatorFactory();

        public static IEquationNode Calculation(string equation)
        {
            if (EquationHelper.IsWholeEquationWithinBrackets(equation) && EquationHelper.EquationContainsAnUnbracketedOperator(equation))
            {
                return Calculation(equation.Substring(1, equation.Length - 2));
            }

            if (EquationHelper.IsStringNumber(equation))
            {
                return new Number(equation);
            }

            foreach (var op in EquationHelper.orderedOperators)
            {
                var bracketCounter = 0;
                for (int i = 0; i < equation.Length; i++)
                {
                    if (equation[i] == '(') bracketCounter++;
                    else if (equation[i] == ')') bracketCounter--;

                    if (equation[i] == op && bracketCounter == 0) return new EquationNode(
                        equation.Substring(0, i),
                        equation.Substring(i + 1),
                        Operation.GetOperator(equation[i]));
                }
            }
            throw new InvalidEquationException("Equation is Invalid!");
        }
    }
}