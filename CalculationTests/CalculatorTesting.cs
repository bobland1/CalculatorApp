using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculationTests
{
    [TestClass]
    public class CalculatorTesting 
    {
        [TestMethod]
        [DataRow("test", false)]
        [DataRow("1+1", true)]
        [DataRow("1+h", false)]
        [DataRow("1+1+", false)]
        public void IsEquationValidTest(string value, bool expected)
        {
            var result = EquationValidator.IsEquationValid(value);

            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        [DataRow("1+1", 2)]
        [DataRow("1*3", 3)]
        [DataRow("4/2", 2)]
        [DataRow("1+1+1", 3)]
        [DataRow("12-2+2", 12)]
        [DataRow("10*10/2+25", 75)]
        public void SumOfEquationTest(string equation, int expected)
        {
            Calculator calc = new Calculator();
            var result = calc.CalculateEquation(equation);

            Assert.AreEqual(expected, result);
        }

    }
}
