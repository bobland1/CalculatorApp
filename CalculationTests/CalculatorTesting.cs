﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;

namespace CalculationTests
{
    [TestClass]
    public class CalculatorTesting 
    {
        [TestMethod]
        [DataRow("1+1", true)]
        [DataRow("1+(2+2)", true)]
        [DataRow("(1+2)+2", true)]
        [DataRow("2*5/4-3(2*2)", true)]
        [DataRow("(2+(3*4))*(1*2)", true)]
        [DataRow("4-3*7+(2/2+(7*2))", true)]
        [DataRow("(1*2)*(2+(3*4))*(1*2)", true)]

        [DataRow("", false)]
        [DataRow("test", false)]
        [DataRow("1++1", false)]
        [DataRow("1+1+", false)]
        [DataRow("1+h", false)]
        [DataRow("1++1", false)]
        [DataRow("1+1+", false)]
        [DataRow("1+(2+2", false)]
        [DataRow("(1+2++2)", false)]
        [DataRow("4+4+(2*2+(3+3)", false)]
        public void IsEquationValidTest(string _equation, bool expected)
        {
            var _result = EquationValidator.IsEquationValid(_equation);

            Assert.AreEqual(expected, _result);
        }

        [TestMethod]
        [DataRow("1+1", 2)]
        [DataRow("1*3", 3)]
        [DataRow("4/2", 2)]
        [DataRow("1+1+1", 3)]
        [DataRow("12-2+2", 8)]
        [DataRow("2+2*2/2", 4)]
        [DataRow("2/2*2+2", 4)]
        [DataRow("1+(2+2)", 5)]
        [DataRow("(1+2)+2", 5)]
        [DataRow("10*10/2+25", 75)]
        [DataRow("(1*2)*(2+4)", 12)]
        [DataRow("(1*3)+(3+4)", 10)]
        [DataRow("(1*2)*(2+(3*4))", 28)]
        [DataRow("(2+(3*4))*(1*2)", 28)] 
        [DataRow("(1*2)*(2+4)+3-2", 13)]
        [DataRow("2*5/4-3*(2*2)", -9.5)]
        [DataRow("((1*3)+(3+4)+3*7)", 31)]
        [DataRow("4-3*7+(2/2+(7*2))", -32)]
        [DataRow("(1*2)*(2+(3*4))*(1*2)", 56)]
        public void SumOfEquationTest(string _equation, double expected)
        {
            var _result = CalculationBuilder.Calculation(_equation);

            Assert.AreEqual(expected, _result.getValue());
        }
        [TestMethod]
        [DataRow("1^2", 1)]
        [DataRow("2^2", 4)]
        [DataRow("(6+6)^2", 144)]
        [DataRow("8+(7*2)^(2+1)", 2752)]
        public void IndicesTest(string _equation, double expected)
        {
            var _result = CalculationBuilder.Calculation(_equation);

            Assert.AreEqual(expected, _result.getValue());
        }
    }
}