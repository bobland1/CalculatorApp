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
                do
                {
                    equation = EquationHandler();
                    Console.WriteLine(
                    CalculationBuilder.Calculation(equation).getValue());
                    Console.WriteLine("Enter another equation or Type 'exit' to exit: ");
                }
                while (equation.ToLower() != "exit");
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR. Please try again");
                IntializeCalculator();
            }
        }

        public static string EquationHandler()
        {
            string equation;
            do
            {
                equation = Console.ReadLine()?.Trim();
                if (equation == "exit") return equation;
                if(!EquationValidator.IsEquationValid(EquationValidator.RemoveWhitespace(equation))) Console.WriteLine("Invalid Equation! Please try again.");
            }
            while (!EquationValidator.IsEquationValid(EquationValidator.RemoveWhitespace(equation)));
            return equation;
        }

    }
}
