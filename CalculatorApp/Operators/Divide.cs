namespace CalculatorApp.Operators
{
    public class Divide : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }
    }
}