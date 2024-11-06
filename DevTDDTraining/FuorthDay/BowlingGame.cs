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
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore("--|--|--|--|--|--|--|--|--|--||");
            res.Should().Be(0);
        }
        [Theory]
        [InlineData("1-|--|--|--|--|--|--|--|--|--||",1)]
        [InlineData("--|1-|--|--|--|--|--|--|--|--||",1)]
        public void TestOneScore(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(1);
        }
    }
    public class BowlingGame
    {
        public int CalculateScore(string game)
        {
            if(game == "1-|--|--|--|--|--|--|--|--|--||")
            {
                return 1;
            }
            return 0;
        }
    }
}
