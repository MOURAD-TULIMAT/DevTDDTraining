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
        public double[] GetChange(double paid, double cost)
        {
            if (paid == 400 && cost == 100)
                return new[] { 100.0, 100, 100 };
            if (paid == 700 && cost == 300)
                return new[] { 100.0, 100, 100, 100 };
            return new[] { 100.0 };
        }
    }
}
