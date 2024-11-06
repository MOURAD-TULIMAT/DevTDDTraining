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
        [InlineData("1-|--|--|--|--|--|--|--|--|--||", 1)]
        [InlineData("--|1-|--|--|--|--|--|--|--|--||", 1)]
        [InlineData("--|--|--|--|1-|--|--|--|--|--||", 1)]
        public void TestOneScore(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1-|-5|--|--|--|--|-3|--|--|--||", 9)]
        [InlineData("1-|-2|--|--|2-|--|2-|--|--|--||", 7)]
        [InlineData("11|22|33|44|55|66|77|88|99|56||", 101)]
        public void TestNumericScores(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1-|-5|--|--|X|--|-3|--|--|--||", 19)]
        [InlineData("X|--|X|--|X|--|X|--|X|--||", 50)]
        [InlineData("--|--|X|--|--|--|--|--|--|--||", 10)]
        public void TestStrikeBeforeMiss(string game, int expected)
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
            int res = 0;
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i] != '|' && game[i] != '-')
                {
                    int score;
                    if(int.TryParse(game.Substring(i,1), out score))
                        res += score;
                    else if (game[i] == 'X')
                        res += 10;
                }
                    
            }

            return res;

        }
    }
}
