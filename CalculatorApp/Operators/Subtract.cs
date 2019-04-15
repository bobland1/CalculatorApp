namespace CalculatorApp.Operators
{
    public class Subtract : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }
    }
}