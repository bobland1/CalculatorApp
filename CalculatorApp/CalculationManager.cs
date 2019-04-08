using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public class CalculationManager
    {
        
        public int Update(string value, UpdateActions action)
        {
            int previousResult;
            int currentValue;

            switch (action)
            {
                case UpdateActions.UpdatePrevious:
                    previousResult = int.Parse(value);
                    return previousResult;
                case UpdateActions.UpdateCurrent:
                    currentValue = int.Parse(value);
                    return currentValue;
                default:
                    return 0;
            }
        }

        public enum UpdateActions
        {
            Errored = -1,
            Undefined = 0,
            UpdatePrevious = 1,
            UpdateCurrent = 2
        }
    }
}
