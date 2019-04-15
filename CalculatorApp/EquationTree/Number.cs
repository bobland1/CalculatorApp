using System;

namespace CalculatorApp
{
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