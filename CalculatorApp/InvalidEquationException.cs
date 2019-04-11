using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class InvalidEquationException : Exception
    {
        public override string Message { get; }

        public InvalidEquationException(string message)
        {
            Message = message;
        }
    }
}
