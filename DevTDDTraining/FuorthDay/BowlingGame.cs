using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevTDDTraining.FuorthDay
{
    public class BowlingGameTest
    {
        [Fact]
        public void TestAllMiss()
        {
            var game = new BowlingGame();
            var res = game.CalculateScore("--|--|--|--|--|--|--|--|--|--||");
            res.Should().Be(0);
        }
        [Fact]
        public void TestOneScore()
        {
            var game = new BowlingGame();
            var res = game.CalculateScore("1-|--|--|--|--|--|--|--|--|--||");
            res.Should().Be(1);
        }
    }
    public class BowlingGame
    {
        public int CalculateScore(string game)
        {
            return 0;
        }
    }
}
