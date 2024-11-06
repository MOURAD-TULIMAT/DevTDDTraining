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
        [InlineData("X|--|--|--|--|--|--|--|--|--||", 10)]
        [InlineData("1-|-5|--|--|X|--|-3|--|--|--||", 19)]
        [InlineData("X|--|X|--|X|--|X|--|X|--||", 50)]
        [InlineData("--|--|X|--|--|--|--|--|--|--||", 10)]
        [InlineData("--|--|X|--|--|--|--|--|--|X||--", 20)]
        public void TestStrikeBeforeMiss(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|11|--|--|--|--|--|--|--|--||", 14)]
        [InlineData("1-|-5|--|--|X|11|-3|--|--|--||", 23)]
        [InlineData("X|--|X|--|X|22|X|--|X|33||", 70)]
        [InlineData("22|--|X|5-|X|22|X|-2|X|33||", 78)]
        [InlineData("22|--|X|5-|X|22|X|-2|--|X||33", 78)]
        public void TestStrikesBeforeNumerics(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1/|--|--|--|--|--|--|--|--|--||", 10)]
        [InlineData("1-|-5|--|--|2/|--|-3|--|--|--||", 19)]
        [InlineData("4/|--|2/|--|5/|--|4/|--|9/|--||", 50)]
        [InlineData("--|--|2/|--|--|--|--|--|--|4/||-", 20)]
        public void TestSpareBeforeMiss(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
    }
    public class BowlingGame
    {
        private int strikeBefore = 0;
        public int CalculateScore(string game)
        {
            int res = 0;
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i] != '|')
                    res += BallingRoundResult(ref game, i);
                //if (game[i] != '|' && game[i] != '-')
                //{
                //    int score;
                //    if (int.TryParse(game.Substring(i, 1), out score))
                //    {
                //        res += score;
                //        if (strikeBefore > 0)
                //        {
                //            res += score;
                //            strikeBefore--;
                //        }
                //    }
                //    else if (game[i] == 'X')
                //    {
                //        strikeBefore = 2;
                //        res += 10;
                //    }
                //    else if (game[i] == '/')
                //    {
                //        var sub = int.Parse(game.Substring(i - 1, 1));
                //        res += 10 - sub;
                //    }
                //}
                //else if (game[i] == '-')
                //    strikeBefore--;

            }

            return res;

        }
        private static int BallingRoundResult(ref string game, int index)
        {

        }
    }
}
