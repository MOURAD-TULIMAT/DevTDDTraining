﻿using FluentAssertions;
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
        public void TestOneItem(string numbers, int expected)
        {
            // Act
            var stringCalc = new StringCalculator();
            var res = stringCalc.Add(numbers);
            // Assert
            res.Should().Be(expected);
        }

    }

    internal class StringCalculator
    {
        public int Add(string numbers)
        {

            var numbersList = numbers.Split(',');
            if(numbersList.Any())
            {
                int res = 0;
                foreach(var item in numbersList)
                {
                    int number;
                    if (int.TryParse(item, out number))
                    {
                        res += number;
                    }
                    else break;
                }
                return res;
            }
            return 0;
        }
    }
}
