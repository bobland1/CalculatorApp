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
        [DataRow("2*5/4-3(2*2)",-9.5)]
        public void SumOfEquationTest(string equation, int expected)
        {
            Calculator calc = new Calculator();
            var result = calc.CalculateEquation(equation);

            Assert.AreEqual(expected, result);
        }
        //[TestMethod]
        //[DataRow("1+1(2+2(3+3))", "1+1*14")]
        //public void ConvertEquationToBidmasTest(string equation, string expected)
        //{
        //    BidmasOrdering Bidmas = new BidmasOrdering();
        //    var result = Bidmas.Convert(equation);

        //    Assert.AreEqual(expected, result);
        //}
        [TestMethod]
        [DataRow("1+1", 2)]
        [DataRow("1+1+1", 3)]
        [DataRow("2+2*2/2", 4)]
        [DataRow("2/2*2+2", 4)]
        [DataRow("1+(2+2)", 5)]
        [DataRow("(1+2)+2", 5)]
        [DataRow("(1*2)*(2+4)", 12)]
        [DataRow("4-3*7+(2/2+(7*2)", -2)]
        public void BidmasTest(string equation, int expected)
        {
            var sut = NodeBuilder.BuildNode(equation);

            Assert.AreEqual(expected, sut.getValue());
        }
    }
}
