using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Calculator
    {
        
    }

    public static class CalculationBuilder
    {
        private static OperatorFactory Operation = new OperatorFactory();

        public static IEquation Calculation(string equation)
        {
            if (EquationValidator.IsWholeEquationWithinBrackets(equation) && EquationValidator.IsOperatorUnbracketed(equation)) return Calculation(equation.Substring(1, equation.Length - 2));

            if (EquationValidator.IsStringNumber(equation)) return new Number(equation);

            foreach (var op in EquationValidator.orderedOperators)
            {
                var bracketCounter = 0;
                for (int i = 0; i < equation.Length; i++)
                {
                    if (equation[i] == '(') bracketCounter++;
                    else if (equation[i] == ')') bracketCounter--;

                    if (equation[i] == op && bracketCounter == 0) return new Equation(
                        equation.Substring(0, i), 
                        equation.Substring(i+1), 
                        Operation.GetOperator(equation[i]));
                }
            }
            if (equation == "exit")
            {
                Console.WriteLine("Exiting..");
                Environment.Exit(-1);
            }
            throw new NotImplementedException();
        }
    }

    public interface IEquation
    {
        double getValue();
    }

    public class Equation : IEquation
    {
        private IEquation Left;
        private IEquation Right;
        private IOperator Operator;

        public Equation(string leftSide, string rightSide, IOperator Operator)
        {
            Left = CalculationBuilder.Calculation(leftSide);
            Right = CalculationBuilder.Calculation(rightSide);
            this.Operator = Operator;
        }

        public double getValue()
        {
            return Operator.DoMaths(Left.getValue(), Right.getValue());
        }
    }

    public class Number : IEquation
    {
        private double num;
        public Number(string equation)
        {
            double.TryParse(equation, out num);
        }

        public double getValue()
        {
            return num;
        }
    }
}