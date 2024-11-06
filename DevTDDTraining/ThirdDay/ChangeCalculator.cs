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
        [Fact]
        public void TestReturn100()
        {
            var calc = ChangeCalculator.GetChange(200, 100);
        }
    }

    internal class ChangeCalculator
    {
        internal static object GetChange(double paid, double cost)
        {
            throw new NotImplementedException();
        }
    }
}
