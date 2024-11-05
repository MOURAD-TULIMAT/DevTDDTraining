using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevTDDTraining.SecondDay
{
    public class StringCalculatorTest
    {
        [Fact]
        public void TestEmpty()
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add("");
            // Assert
            res.Should().Be(0);
        }
        [Theory]
        // Arrange
        [InlineData("1", 1)]
        [InlineData("10", 10)]
        [InlineData("67123", 67123)]
        public void TestOneItem(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        // Arrange
        [InlineData("11,2,5", 18)]
        [InlineData("11,2", 13)]
        public void TestOnlyCommas(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        // Arrange
        [InlineData("11\n2\n5", 18)]
        [InlineData("11\n2", 13)]
        public void TestOnlyNewLine(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        // Arrange
        [InlineData("1 12 5", 18)]
        [InlineData("1 12", 13)]
        public void TestOnlySpace(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        // Arrange
        [InlineData("1\n2,5", 8)]
        [InlineData("1,2\n15", 18)]
        [InlineData("1\n2,5 15", 23)]
        // we can add tests here for other delimiters
        public void TestValideCases(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        // Arrange
        [InlineData("1\n,2")]
        [InlineData("1 ,2")]
        [InlineData("1, 2")]
        [InlineData("a,b,c")]
        // we can add tests here for other delimiters
        public void TestInvalideNumericCases(string numbers)
        {
            // Act
            var stringCalc = new StringCalculator();

            Assert.Throws<ArgumentException>(() => stringCalc.Add(numbers));

        }
    }

    internal class StringCalculator
    {
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;
            var numbersList = numbers.Split([',', '\n', ' ']); // we can add other delimiters here
            int _;
            if (numbersList.Any(x => !int.TryParse(x, out _)))
            {
                throw new ArgumentException();
            }
            return numbersList.Sum(x => int.Parse(x));
        }
    }
}
