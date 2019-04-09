using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class BidmasOrdering
    {
        public string Convert(string equation)
        {
            var resultFromBracketsCalcuation = BracketsFiltering(equation);

            var equationWithBidmasOrdering = resultFromBracketsCalcuation;
            return equationWithBidmasOrdering;
        }

        private string BracketsFiltering(string equation)
        {
            var equationPreBracketsFiltering = BuildEquationForBidmasOrdering(equation);

            do
                foreach (var character in equationPreBracketsFiltering)
                {
                    if (character == '(')
                    {
                        var indexCount = ((equationPreBracketsFiltering.IndexOf(')')-equationPreBracketsFiltering.LastIndexOf('('))+1);
                        var firstIndex = equationPreBracketsFiltering.LastIndexOf('(');
                        var bracketsSection = equationPreBracketsFiltering.GetRange(firstIndex, indexCount);

                        //equation = equation.Replace(BuildListToString(bracketsSection), BracketsCalculating(BuildListToString(bracketsSection)));
                    }
                }
            while (!NoBracketsLeft(equation));
            return equation;
        }
        private int BracketsCalculating(string equation)
        {
            Calculator calc = new Calculator();
            equation = equation.Replace("(", "").Replace(")", "");

            var result = calc.CalculateEquation(equation);
            return result;
        }
        private bool NoBracketsLeft(string equation)
        {
            if (equation.IndexOf('(') == -1) return true; 
            return false;
        }


        private string Indices()
        {
            return "";
        }
        private string DivisionFiltering(string equation)
        {
            var equationPreDivisionFiltering = BuildEquationForBidmasOrdering(equation);

            return "";
        }
        private string Multiplication(string equation)
        {
            var equationPreMuliplicationFiltering = BuildEquationForBidmasOrdering(equation);

            return "";
        }
        private string Addition()
        {
            return "";
        }
        private string Subtraction()
        {
            return "";
        }

        private string BuildListToString(List<char> list)
        {
            string listToString = string.Join("", list);
            return listToString;
        }
        private List<char> BuildEquationForBidmasOrdering(string equation)
        {
            var charactersInEquation = new List<char>();

            foreach (var character in equation)
            {
                charactersInEquation.Add(character);
            }
            return charactersInEquation;
        }
    }
}
