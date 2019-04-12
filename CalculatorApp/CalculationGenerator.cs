using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class CalculationGenerator
    {
        private static OperatorFactory Operation = new OperatorFactory();

        public static IEquationNode Calculation(string equation)
        {
            if (EquationValidator.IsWholeEquationWithinBrackets(equation) && EquationValidator.EquationContainsAnUnbracketedOperator(equation))
            {
                return Calculation(equation.Substring(1, equation.Length - 2));
            }

            if (EquationValidator.IsStringNumber(equation))
            {
                return new Number(equation);
            }

            foreach (var op in EquationValidator.orderedOperators)
            {
                var bracketCounter = 0;
                for (int i = 0; i < equation.Length; i++)
                {
                    if (equation[i] == '(') bracketCounter++;
                    else if (equation[i] == ')') bracketCounter--;

                    if (equation[i] == op && bracketCounter == 0) return new EquationTreeGenerator(
                        equation.Substring(0, i),
                        equation.Substring(i + 1),
                        Operation.GetOperator(equation[i]));
                }
            }
            throw new InvalidEquationException("Equation is Invalid!");
        }
    }
}