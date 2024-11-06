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
        [Theory]
        // Arrange
        [InlineData("", 0)]
        [InlineData("5", 5)]
        [InlineData("10", 10)]
        [InlineData("200", 200)]
        [InlineData("200,300", 500)]
        [InlineData("200,200", 400)]
        [InlineData("200,100", 300)]
        [InlineData("10\n100", 110)]
        [InlineData("10\n23", 33)]
        [InlineData("10\n23,3", 36)]
        [InlineData("//l\n10l23\n3", 36)]
        [InlineData("//+\n10+2\n3", 15)]
        [InlineData("//.\n1.3\n3", 7)]
        public void TestOneItem(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1\n,2")]
        [InlineData("1 ,2")]
        [InlineData("1,,2")]
        [InlineData("1-2")]
        [InlineData("1+2")]
        [InlineData("1.2")]
        public void TestExceptions(string numbers)
        {
            var stringCalc = new StringCalculator();
            Assert.Throws<ArgumentException>(() => stringCalc.Add(numbers));
        }
        [Theory]
        [InlineData("1,-2")]
        [InlineData("-1,-2")]
        [InlineData("//o\n1o-2")]
        public void TestNegativeExceptions(string numbers)
        {
            var stringCalc = new StringCalculator();
            Assert.Throws<NegativesNotAllowedExeption>(() => stringCalc.Add(numbers));
        }

    }
    internal class StringCalculator
    {
        public int Add(string numbers)
        {
            if (numbers == "")
                return 0;
            if (numbers.Contains(' '))
            {
                throw new ArgumentException();
            }
            var delimiter = ',';
            if (numbers.StartsWith("//") && numbers.Length > 4)
            {
                delimiter = numbers[2];
                numbers = numbers.Substring(4);
            }
            var numbersList = numbers.Split(delimiter, '\n');
            if (numbersList.Any())
            {
                int res = 0;
                foreach (var item in numbersList)
                {
                    int number;
                    if (int.TryParse(item, out number))
                    {
                        res += number;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                    if (number < 0)
                        throw new NegativesNotAllowedExeption();
                }
                return res;
            }
            return 0;
        }
    }
}
