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
        [InlineData("--|--|--|--|1-|--|--|--|--|--||",1)]
        public void TestOneScore(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1-|-5|--|--|--|--|-3|--|--|--||", 9)]
        public void TestNumericScores(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
    }
    public class BowlingGame
    {
        public int CalculateScore(string game)
        {
            //if()
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i] == '1')
                {
                    return 1;
                }
            }

            return 0;
            
        }
    }
}
