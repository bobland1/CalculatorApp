namespace CalculatorApp.Operators
{
    public class OperatorFactory
    {
        public IOperator GetOperator(char op)
        {
            switch (op)
            {
                case '+':
                    return new Add();
                case '-':
                    return new Subtract();
                case '*':
                    return new Multiply();
                case '/':
                    return new Divide();
                case '^':
                    return new Indices();
                default:
                    throw new InvalidOperatorException("Invalid Operator");
                    
            }
        }
    }

}