using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class ListManagement
    {
        public static List<int> AddToList(List<int> list, string input)
        {
            list.Add(int.Parse(input));
            return list;
        }
        public static List<int> InsertToList(List<int> list, string input, int index)
        {
            list.Insert(index, int.Parse(input));
            return list;
        }
    }
}
