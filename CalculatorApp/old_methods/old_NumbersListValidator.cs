using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class NumbersListValidator
    {
        public static bool IsListEmpty(List<int> list)
        {
            if(list.Count() == 0)
            {
                return true;
            }
            return false;
        }
    }
}
