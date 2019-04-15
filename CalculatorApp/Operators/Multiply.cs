namespace CalculatorApp.Operators
{
    public class Multiply : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
    }
}