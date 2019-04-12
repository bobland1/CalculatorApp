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
            IntializeCalculator();
        }

        public static void IntializeCalculator()
        {
            string equation;
            try
            {
                equation = EquationHandler();
                Console.WriteLine(
                CalculationGenerator.Calculation(equation).getValue());
                Console.WriteLine("Enter another equation or Type 'exit' to exit: ");
            }
            catch (InvalidEquationException e)
            {
                Console.WriteLine(e.Message);
            }
            IntializeCalculator();
        }

        public static string EquationHandler()
        {
            string equation;
            do
            {
                equation = Console.ReadLine()?.Trim();
                if (equation.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("Exiting..");
                    Environment.Exit(-1);
                }
                if (!EquationValidator.IsEquationValid(EquationValidator.RemoveWhitespace(equation)))
                {
                    Console.WriteLine("Invalid Equation! Please try again.");
                }
            }
            while (!EquationValidator.IsEquationValid(EquationValidator.RemoveWhitespace(equation)));
            return equation;
        }

    }
}
