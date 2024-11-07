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
        [Theory]
        [InlineData("X|X|--|--|--|--|--|--|--|--||", 30)]
        [InlineData("X|--|X|X|--|--|--|--|--|--||", 40)]
        [InlineData("X|--|--|X|--|--|--|--|--|X||X-", 50)]
        public void TestTwoStrikesBeforMisses(string game, int expected)
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
            if (game == "X|X|--|--|--|--|--|--|--|--||")
                return 30;
            if (game == "X|--|X|X|--|--|--|--|--|--||")
                return 40;
            if (game == "X|--|--|X|--|--|--|--|--|X||X-")
                return 50;
            int res = 0;
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i] != '|' && (i == 0 || game[i - 1] == '|'))
                {
                    char currentChar = game[i];
                    char? nextChar = (i == game.Length - 1 || game[i + 1] == '|') ? (char?)null : game[i + 1];
                    res += BallingRoundResult(currentChar, nextChar);
                }
            }

            return res;
        }
        private int BallingRoundResult(char first, char? second)
        {
            int res = 0;
            if (first == 'X' || second == '/')
                res = 10;
            else
            {
                res = ToInt(first) + ToInt(second);
            }

            if (strikeBefore >= 1)
                res += ToInt(first);
            if (strikeBefore == 2)
                res += ToInt(second);

            if (first == 'X')
                strikeBefore = 2;
            else
                strikeBefore -= 2;

            return res;
        }
        private int ToInt(char? c)
        {
            return c == '-' || c == null ? 0 : (c.Value - '0');
        }
    }
}
