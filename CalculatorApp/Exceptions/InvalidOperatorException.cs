using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class InvalidOperatorException : Exception
    {
        public InvalidOperatorException()
        {
        }

        public InvalidOperatorException(string message)
            : base(message)
        {
        }

        public InvalidOperatorException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }
}
