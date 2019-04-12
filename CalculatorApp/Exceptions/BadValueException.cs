using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class BadValueException : Exception
    {
        public BadValueException()
        {
        }

        public BadValueException(string message)
            : base(message)
        {
        }

        public BadValueException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
