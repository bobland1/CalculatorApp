using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter your equation: ");
            Process();
        }

        private static void Process()
        {
            try
            {
                var input = Console.ReadLine()?.Trim();

                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting..");
                    Environment.Exit(-1);
                }

                var equation = EquationHelper.RemoveWhitespace(input);

                if (EquationValidator.IsEquationValid(equation))
                {
                    var result = EquationTreeGenerator.Calculation(equation).getValue();
                    Console.WriteLine(result);
                    
                    Console.WriteLine("Enter another equation or Type 'exit' to exit: ");
                    Process();
                }
                else
                {
                    Console.WriteLine("Invalid Equation! Please try again.");
                    Process();
                }
            }
            catch (InvalidEquationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
