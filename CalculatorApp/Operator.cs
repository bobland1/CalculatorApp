using System;

namespace CalculatorApp
{
    public interface IOperator
    {
        double DoMaths(double FirstNumber, double SecondNumber);
    }
    public class Add: IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
    }
    public class Subtract : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }
    }
    public class Multiply : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
    }
    public class Divide : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }
    }
    public class Indices : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
        {
            return Math.Pow(FirstNumber, SecondNumber);
        }
    }

    public class NoOperator : IOperator
    {
        public double DoMaths(double FirstNumber, double SecondNumber)
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
                case '^':
                    return new Indices();
                default:
                    throw new InvalidOperatorException("Invalid Operator");
                    
            }
        }
    }

}