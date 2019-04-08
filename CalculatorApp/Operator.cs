using System;

namespace CalculatorApp
{
    public interface IOperator
    {
        int DoMaths(int FirstNumber, int SecondNumber);
    }
    public class Add: IOperator
    {
        public int DoMaths(int FirstNumber, int SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
    }
    public class Subtract : IOperator
    {
        public int DoMaths(int FirstNumber, int SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }
    }
    public class Multiply : IOperator
    {
        public int DoMaths(int FirstNumber, int SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
    }
    public class Divide : IOperator
    {
        public int DoMaths(int FirstNumber, int SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }
    }

    public class NoOperator : IOperator
    {
        public int DoMaths(int FirstNumber, int SecondNumber)
        {
            return FirstNumber;
        }
    }
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
                case ' ':
                    return new NoOperator();
                default:
                    throw new Exception("Invalid Operator");
                    
            }
        }
    }

}