using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class EquationValidator
    {
        public static string RemoveWhitespace(string input)
        {
            input = input.Replace(" ", string.Empty);

            return input;
        }
        public static bool IsCharacterIn(char input, IEnumerable<char> characterArray) => characterArray.Contains(input);

        public static bool IsCharacterNumber(char input) => IsCharacterIn(input,
            new char[10] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'});
        public static bool IsCharacterOperator(char input) => IsCharacterIn(input,
            new char[4] { '+', '-', '*', '/' });

        public static bool IsOperatorDuplicated(string equation)
        {
            var _number = new StringBuilder();
            char _operator = ' ';
            var _numbers = new List<int>();

            foreach (var character in RemoveWhitespace(equation))
            {
                if (EquationValidator.IsCharacterNumber(character))
                {
                    _number.Append(character);
                    _operator = ' ';
                }
                else
                {
                    if (_operator != ' ')
                    {
                        return true;
                    }
                    _numbers.Add(int.Parse(_number.ToString()));
                    _number.Clear();
                    _operator = character;
                }
            }
            _numbers.Add(int.Parse(_number.ToString()));

            return false;
        }
        public static bool IsLastCharacterAOperator(string equation)
        {
            char LastChar = equation.Substring(equation.Length - 1)[0];
            if (IsCharacterOperator(LastChar))
            {
                return true;
            }
            return false;
        }

        public static bool IsEquationValid(string equation)
        {

            var hasInValidCharacter = RemoveWhitespace(equation).Any(character =>
                !(IsCharacterNumber(character) ||
                IsCharacterOperator(character)));

            if (hasInValidCharacter)
            {
                return false;
            }
            var hasOperatorAtEnd = IsLastCharacterAOperator(equation);

            if (hasOperatorAtEnd)
            {
                return false;
            }

            var hasDoubleOperators = IsOperatorDuplicated(equation);

            if(hasDoubleOperators)
            {
                return false;
            } else {
                return true;
            }
        }
    }
}
