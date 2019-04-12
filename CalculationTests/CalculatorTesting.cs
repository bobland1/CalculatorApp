using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorApp;
using FluentAssertions;

namespace CalculationTests
{
    [TestClass]
    public class CalculatorTesting 
    {
        [TestMethod]
        [DataRow("1+1", true)]
        [DataRow("(6+6)^2", true)]
        [DataRow("1+(2+2)", true)]
        [DataRow("(1+2)+2", true)]
        [DataRow("2*5/4-3(2*2)", true)]
        [DataRow("8+(7*2)^(2+1)", true)]
        [DataRow("(2+(3*4))*(1*2)", true)]
        [DataRow("4-3*7+(2/2+(7*2))", true)]
        [DataRow("(1*2)*(2+(3*4))*(1*2)", true)]
        public void IsEquation_ValidTest(string _equation, bool expected)
        {
            var _result = EquationValidator.IsEquationValid(_equation);

            _result.Should().Be(expected);
        }

        [TestMethod]
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
        public void IsEquation_InvalidTest(string _equation, bool expected)
        {
            var _result = EquationValidator.IsEquationValid(_equation);

            _result.Should().Be(expected);
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
        public void SumOfEquation_OperatorsTest(string _equation, double expected)
        {
            var _result = CalculationGenerator.Calculation(_equation);

            _result.getValue().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("1+(2+2)", 5)]
        [DataRow("(1+2)+2", 5)]
        [DataRow("(1*2)*(2+4)", 12)]
        [DataRow("(1*3)+(3+4)", 10)]
        [DataRow("(1*2)*(2+(3*4))", 28)]
        [DataRow("(2+(3*4))*(1*2)", 28)]
        [DataRow("(1*2)*(2+4)+3-2", 13)]
        [DataRow("2*5/4-3*(2*2)", -9.5)]
        [DataRow("((1*3)+(3+4)+3*7)", 31)]
        [DataRow("4-3*7+(2/2+(7*2))", -32)]
        [DataRow("(1*2)*(2+(3*4))*(1*2)", 56)]
        public void SumOfEquation_BracketsTest(string _equation, double expected)
        {
            var _result = CalculationGenerator.Calculation(_equation);

            _result.getValue().Should().Be(expected);
        }

        [TestMethod]
        [DataRow("1^2", 1)]
        [DataRow("2^2", 4)]
        [DataRow("(6+6)^2", 144)]
        [DataRow("8+(7*2)^(2+1)", 2752)]
        public void SumOfEquation_IndicesTest(string _equation, double expected)
        {
            var _result = CalculationGenerator.Calculation(_equation);

            _result.getValue().Should().Be(expected);
        }

        [TestMethod]
        public void EquationHandlerTest()
        {
            Action action = () => CalculationGenerator.Calculation("dfpihfisdfhidsjdsiosj");
            action.Should().Throw<Exception>()
                .WithMessage("Equation is Invalid!");
        }
    }
}
