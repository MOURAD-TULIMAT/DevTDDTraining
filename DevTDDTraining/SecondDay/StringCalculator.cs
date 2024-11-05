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
        [InlineData("a,b,c")]
        [InlineData("a")]
        // we can add tests here for other delimiters
        public void TestInvalideCases(string numbers)
        {
            // Act
            var stringCalc = new StringCalculator();

            Assert.Throws<ArgumentException>(() => stringCalc.Add(numbers));

        }
        [Theory]
        // Arrange
        [InlineData("//+\n1+2", 3)]
        [InlineData("//;\n1;2", 3)]
        [InlineData("//*\n1*2", 3)]
        // we can add tests here for other delimiters
        public void TestChangeDelimiter(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);

        }
        [Theory]
        // Arrange
        [InlineData("10,-10")]
        [InlineData("-2")]
        // we can add tests here for other delimiters
        public void TestNigativeNumbers(string numbers)
        {
            // Act
            var stringCalc = new StringCalculator();

            Assert.Throws<NegativesNotAllowedExeption>(() => stringCalc.Add(numbers));

        }
    }

    internal class StringCalculator
    {
        public int Add(string numbers)
        {
            var delimiter = ',';
            if (numbers.StartsWith("//"))
            {
                if (numbers.Length > 3 && numbers[3] != '\n')
                    throw new ArgumentException();
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var numbersList = numbers.Split([delimiter, '\n']); // we can add other delimiters here

            int res = 0;
            foreach (var item in numbersList)
            {
                int number;

                if (!int.TryParse(item, out number))
                {
                    throw new ArgumentException();
                }

                if (number < 0)
                {
                    throw new NegativesNotAllowedExeption();
                }
                res += number;
            }
            return res;
        }
    }
}
