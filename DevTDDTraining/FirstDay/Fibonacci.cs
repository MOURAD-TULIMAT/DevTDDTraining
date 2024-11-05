using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
namespace DevTDDTraining.FirstDay
{
    public class FibonacciTest
    {
        [Fact]
        public void Test0()
        {
            var res = FibonacciGenerator.Fibonacci(0);
        }
        [Fact]
        public void Test1()
        {
            var res = FibonacciGenerator.Fibonacci(1);
            res.Should().Be(1);
        }

        [Fact]
        public void Test2()
        {
            var res = FibonacciGenerator.Fibonacci(2);
            res.Should().Be(1);
        }
        [Fact]
        public void Test3()
        {
            var res = FibonacciGenerator.Fibonacci(3);
            res.Should().Be(2);
        }
        [Fact]
        public void Test4()
        {
            var res = FibonacciGenerator.Fibonacci(4);
            res.Should().Be(3);
        }
        [Fact]
        public void Test5()
        {
            var res = FibonacciGenerator.Fibonacci(5);
            res.Should().Be(5);
        }
        [Fact]
        public void Test9()
        {
            var res = FibonacciGenerator.Fibonacci(9);
            res.Should().Be(34);
        }
    }

    public class FibonacciGenerator
    {
        internal static ulong Fibonacci(int position)
        {
            if (position > 1)
            {
                return GenerateFibonacciAtIndex(position);
            }
            if (position == 0)
                return 0;
            return 1;
        }
        internal static ulong GenerateFibonacciAtIndex(int index)
        {
            ulong last = 1, otherLast = 0;
            for (int i = 1; i < index; i++)
            {
                ulong t = last;
                last = last + otherLast;
                otherLast = t;
            }
            return last;
        }


    }
}
