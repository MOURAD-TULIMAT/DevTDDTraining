using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
namespace DevTDDTraining.FirstDay
{
    public class LeapYearTest
    {
        [Fact]
        public void TestOddYear1999()
        {
            var res = LeapYear.IsLeap(1999);
            res.Should().Be(false);
        }
        [Fact]
        public void TestOddYear2111()
        {
            var res = LeapYear.IsLeap(2111);
            res.Should().Be(false);
        }
        [Fact]
        public void TestOddYear555()
        {
            var res = LeapYear.IsLeap(555);
            res.Should().Be(false);
        }
        [Fact]
        public void TestMultOfFuorYear444()
        {
            var res = LeapYear.IsLeap(444);
            res.Should().Be(true);
        }
        [Fact]
        public void TestMultOfFuorYear1244()
        {
            var res = LeapYear.IsLeap(1224);
            res.Should().Be(true);
        }
        [Fact]
        public void TestMultOfFuorYear1668()
        {
            var res = LeapYear.IsLeap(1668);
            res.Should().Be(true);
        }
        [Fact]
        public void TestMultOf4And100Year2900()
        {
            var res = LeapYear.IsLeap(2900);
            res.Should().Be(false);
        }
        [Fact]
        public void TestMultOf4And100Year500()
        {
            var res = LeapYear.IsLeap(500);
            res.Should().Be(false);
        }
        [Fact]
        public void TestMultOf4And100Year1300()
        {
            var res = LeapYear.IsLeap(1300);
            res.Should().Be(false);
        }
        [Fact]
        public void TestMultOf4And400Year2800()
        {
            var res = LeapYear.IsLeap(2800);
            res.Should().Be(true);
        }
        [Fact]
        public void TestMultOf4And400Year400()
        {
            var res = LeapYear.IsLeap(400);
            res.Should().Be(true);
        }
        [Fact]
        public void TestMultOf4And400Year1200()
        {
            var res = LeapYear.IsLeap(1200);
            res.Should().Be(true);
        }
    }

    internal class LeapYear
    {
        internal static bool IsLeap(int year)
        {
            if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
            {
                return true;
            }
            return false;
        }
    }
}
