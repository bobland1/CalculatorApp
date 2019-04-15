using System;

namespace CalculatorApp.Operators
{
    public class Indices : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return Math.Pow(FirstNumber, SecondNumber);
        }
    }
}