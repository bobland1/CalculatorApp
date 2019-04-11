using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class InvalidOperatorException : Exception
    {
        public override string Message { get; }

        public InvalidOperatorException(string message)
        {
            Message = message;
        }
    }
}
