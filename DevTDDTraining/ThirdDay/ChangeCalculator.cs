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
            var res = new List<double>();
            double remainingAmount = paid - cost;

            while (remainingAmount >= 100)
            {
                res.Add(100);
                remainingAmount -= 100;
            }

            return res.ToArray();
        }
    }
}
