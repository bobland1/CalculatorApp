namespace CalculatorApp.Operators
{
    public class Add: IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
    }
}