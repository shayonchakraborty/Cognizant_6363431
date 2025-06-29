using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            calculator = new SimpleCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            calculator.AllClear();
        }

        [Test]
        [TestCase(2.0, 3.0, 5.0)]
        [TestCase(-1.0, -1.0, -2.0)]
        [TestCase(0.0, 0.0, 0.0)]
        [TestCase(1.5, 2.5, 4.0)]
        public void Addition_ShouldReturnExpectedResult(double a, double b, double expected)
        {
            var result = calculator.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(0.0001));
        }
    }
}
