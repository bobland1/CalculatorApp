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
            IntializeCalculator();
        }
        public static void IntializeCalculator()
        {
            Calculator calc = new Calculator();
            string equation = EquationHandler();

            Console.WriteLine(
                calc.CalculateEquation(
                    EquationValidator.RemoveWhitespace(equation)));
            Console.ReadKey();

        }
        public static string EquationHandler()
        {
            string equation;
            do
            {
                Console.WriteLine("Enter your equation: ");
                equation = Console.ReadLine()?.Trim();
            }
            while (!EquationValidator.IsEquationValid(equation));

            return equation;
        }

    }
}
