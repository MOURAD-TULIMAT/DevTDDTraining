using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevTDDTraining.ThirdDay
{
    public class ChangeCalculatorTest
    {
        [Theory]
        [InlineData(200, 100, new[] { 100.0 })]
        [InlineData(400, 100, new[] { 100.0, 100.0, 100.0 })]
        [InlineData(700, 300, new[] { 100.0, 100.0, 100.0, 100.0 })]
        [InlineData(700, 650, new[] { 50.0 })]
        [InlineData(800, 750, new[] { 50.0 })]
        [InlineData(1100, 1050, new[] { 50.0 })]
        [InlineData(1500, 1050, new[] { 100.0, 100.0, 100.0, 100.0, 50.0 })]
        [InlineData(1100, 1080, new[] { 20.0 })]
        [InlineData(1100, 1060, new[] { 20.0, 20 })]
        [InlineData(1100, 1030, new[] { 50, 20.0 })]
        public void TestReturnHundreds(double paid, double cost, double[] expected)
        {
            var calc = new ChangeCalculator();
            double[] res = calc.GetChange(paid, cost);
            res.Should().Equal(expected);
        }
    }

    public class ChangeCalculator
    {
        internal double[] GetChange(double paid, double cost)
        {
            var changes = new List<double>() { 100, 50, 20, 10, 5, 1, .5, .25, .1, .05, .01 };
            var res = new List<double>();
            double remainingAmount = paid - cost;
            while (remainingAmount >= 100)
            {
                res.Add(100);
                remainingAmount -= 100;
            }
            if (remainingAmount >= 50)
            {
                remainingAmount -= 50;
                res.Add(50);
            }
            while (remainingAmount >= 20)
            {
                remainingAmount -= 20;
                res.Add(20);
            }
            return res.ToArray();
        }
    }
}
