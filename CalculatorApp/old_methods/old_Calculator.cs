using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CalculatorApp.Operators;

namespace CalculatorApp
{
    public class OldCalculator
    {
        private CalculationManager calcManager;

        public OldCalculator()
        {

        }

        public double CalculateEquation(string equation)
        {
            var numberCharacterBuilder = new StringBuilder();

            var numbers = new List<int>();
            var operators = new List<char>();

            double result = 0;
            int counter = 0;

            var Operation = new OperatorFactory();
            calcManager = new CalculationManager();

            var updatedPreviousResult = 0;
            var updatedCurrentValue = 0;

            foreach (var character in equation)
            {
                if (EquationHelper.IsCharacterNumber(character))
                {
                    numberCharacterBuilder.Append(character);
                }
                else
                {
                    if (NumbersListValidator.IsListEmpty(numbers))
                    {
                        updatedPreviousResult = UpdateCalcManagerPrevious(numbers, numberCharacterBuilder.ToString());
                        numberCharacterBuilder.Clear();
                    }
                    else
                    {
                        updatedCurrentValue = UpdateCalcManagerCurrent(numbers, numberCharacterBuilder.ToString());
                        numberCharacterBuilder.Clear();

                        var NextOperation = Operation.GetOperator(operators[counter-1]);
                        result = NextOperation.DoMaths(updatedPreviousResult, updatedCurrentValue);
                        updatedPreviousResult = UpdateCalcManagerPrevious(numbers, result.ToString());
                    }
                    counter++;
                    operators.Add(character);
                }
            }
            updatedCurrentValue = UpdateCalcManagerCurrent(numbers, numberCharacterBuilder.ToString());

            var LastOperation = Operation.GetOperator(operators[operators.Count()-1]);
            result = LastOperation.DoMaths(updatedPreviousResult, updatedCurrentValue);

            return result;
        }

        private int UpdateCalcManagerPrevious(List<int> numbers, string number)
        {
            ListManagement.AddToList(numbers, number);
            return calcManager.Update(number, CalculationManager.UpdateActions.UpdatePrevious);
        }
        private int UpdateCalcManagerCurrent(List<int> numbers, string number)
        {
            ListManagement.AddToList(numbers, number);
            return calcManager.Update(number, CalculationManager.UpdateActions.UpdateCurrent);
        }
    }
}
