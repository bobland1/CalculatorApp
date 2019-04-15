using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class EquationValidator
    {
        public static bool IsEquationValid(string _input)
        {
            if (string.IsNullOrEmpty(_input)) return false;

            var hasInvalidCharacter = _input.Any(_character =>
                !(EquationHelper.IsCharacterNumber(_character) ||
                  EquationHelper.IsCharacterOperator(_character) ||
                  (EquationHelper.IsBracketsValid(_input, EquationHelper.IsCharacterBracket(_character)) && EquationHelper.IsCharacterBracket(_character))));
            if (hasInvalidCharacter) return false;

            if (EquationHelper.IsNumberMultipleDecimal(_input)) return false;

            if (EquationHelper.IsLastCharacterAOperator(_input)) return false;

            if (EquationHelper.IsOperatorDuplicated(_input)) return false;
            return true;
        }
    }
}
