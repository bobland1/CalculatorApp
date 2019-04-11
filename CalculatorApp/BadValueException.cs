using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class BadValueException : Exception
    {
        public override string Message { get; }

        public BadValueException(string message)
        {
            Message = message;
        }
    }
}
