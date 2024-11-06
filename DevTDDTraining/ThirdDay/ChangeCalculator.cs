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
        ChangeCalculator changeCalculator;
        public ChangeCalculatorTest()
        {
            changeCalculator = new ChangeCalculator();
        }

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
        [InlineData(1100, 1028.3, new[] { 50.0, 20, 1, .5, .1, .1 })]
        [InlineData(1100, 1100, new double[] { })]

        public void TestReturnHundreds(double paid, double cost, double[] expected)
        {
            double[] res = changeCalculator.GetChange(paid, cost);
            res.Should().Equal(expected);
        }
        [Theory]
        [InlineData(200, 300)]
        [InlineData(10, 300)]
        [InlineData(10, 200)]
        [InlineData(-10, 200)]
        [InlineData(10, -300)]
        [InlineData(-10, -200)]
        public void TestErrors(double paid, double cost)
        {
            Assert.Throws<ArgumentException>(() => changeCalculator.GetChange(paid, cost));
        }

    }

    public class ChangeCalculator
    {
        internal double[] GetChange(double paid, double cost)
        {
            double remainingAmount = paid - cost;
            if (remainingAmount < 0 || paid < 0 || cost < 0)
                throw new ArgumentException();
            var changes = new List<double>() { 100, 50, 20, 10, 5, 1, .5, .25, .1, .05, .01 };
            var res = new List<double>();
            foreach (var change in changes)
            {
                while (remainingAmount >= change)
                {
                    res.Add(change);
                    remainingAmount -= change;
                }
            }

            return res.ToArray();
        }
    }
}
