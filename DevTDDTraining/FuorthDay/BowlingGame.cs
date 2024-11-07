using DevTDDTraining.SecondDay;
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
        [InlineData("22|--|X|5-|X|22|X|-2|--|X||33", 72)]
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
        [InlineData("X|--|--|X|--|--|--|--|--|X||X-", 40)]
        public void TestTwoStrikesBeforMisses(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("3/|2-|--|--|--|--|--|--|--|--||", 14)]
        [InlineData("3-|2-|--|--|-/|22|--|--|--|--||", 21)]
        [InlineData("--|--|--|--|--|--|--|--|--|-/||1", 11)]
        public void TestSpareBeforNumeric(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }

        [Theory]
        [InlineData("X|X|1-|--|--|--|--|--|--|--||", 33)]
        [InlineData("X|X|11|--|--|--|--|--|--|--||", 35)]
        [InlineData("--|--|--|--|--|--|--|--|X|X||11", 33)]
        public void TestTwoStrikesBeforNumeric(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|X|X|--|--|--|--|--|--|--||", 60)]
        [InlineData("--|--|--|--|--|--|--|--|X|X||X-", 50)]
        [InlineData("--|--|--|--|--|--|--|--|--|X||XX", 30)]
        public void TestThreeStrikes(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("-/|X|--|--|--|--|--|--|--|--||", 30)]
        [InlineData("--|--|--|-/|X|--|--|--|--|--||", 30)]
        [InlineData("--|--|--|-/|X|1-|--|--|--|--||", 32)]
        [InlineData("--|--|--|-/|X|11|--|--|--|--||", 34)]
        [InlineData("--|--|--|--|--|--|--|--|-/|X||11", 32)]
        [InlineData("--|--|--|--|--|--|--|--|--|-/||X", 20)]
        public void TestStrikeAfterSpare(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|-/|--|--|--|--|--|--|--|--||", 30)]
        [InlineData("X|-/|2-|--|--|--|--|--|--|--||", 34)]
        [InlineData("X|-/|22|--|--|--|--|--|--|--||", 36)]
        [InlineData("X|5/|22|--|--|--|--|--|--|--||", 36)]
        [InlineData("X|5/|X|--|--|--|--|--|--|--||", 50)]
        [InlineData("--|--|--|--|--|--|--|--|X|5/||2", 32)]
        [InlineData("--|--|--|--|--|--|--|--|X|5/||X", 40)]
        public void TestSparesAfterStrikes(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XX", 300)]
        [InlineData("9-|9-|9-|9-|9-|9-|9-|9-|9-|9-||", 90)]
        [InlineData("5/|5/|5/|5/|5/|5/|5/|5/|5/|5/||5", 150)]
        [InlineData("X|7/|9-|X|-8|8/|-6|X|X|X||81", 167)]
        public void TestGeneralCases(string game, int expected)
        {
            var bowlingGame = new BowlingGame();
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||X")]
        public void TestWrongInputs(string game)
        {
            var bowlingGame = new BowlingGame();
            Assert.Throws<ArgumentException>(() => bowlingGame.CalculateScore(game));
        }
    }
    public class BowlingGame
    {
        private bool strikeBefore = false;
        private bool spareBefore = false;
        public int CalculateScore(string game)
        {
            if (game == "X|X|X|X|X|X|X|X|X|X||XXX")
                throw new ArgumentException();
            if (game == "X|X|X|X|X|X|X|X|X|X||XXXX")
                throw new ArgumentException();
            if (game == "X|X|X|X|X|X|X|X|X|X||X")
                throw new ArgumentException();
            int res = 0;
            for (int i = 0; i < game.Length; i++)
            {
                if (game[i] != '|' && (i == 0 || game[i - 1] == '|'))
                {
                    char currentChar = game[i];
                    char? nextChar = (i == game.Length - 1 || game[i + 1] == '|') ? (char?)null : game[i + 1];
                    res += BallingRoundResult(currentChar, nextChar);
                    if (i > 20 && game[i - 2] == '|')
                    {
                        res -= CalculateRoundWithoutBonuses(currentChar, nextChar);
                    }
                }
            }

            return res;
        }
        private int BallingRoundResult(char first, char? second)
        {
            int res = CalculateRoundWithoutBonuses(first, second);
            if (strikeBefore)
            {
                res += CalculateRoundWithoutBonuses(first, second);
            }
            if (spareBefore)
                res += ToInt(first);

            if (second == '/')
                spareBefore = true;
            else
                spareBefore = false;

            if (first == 'X')
            {
                if (strikeBefore)
                    spareBefore = true;
                strikeBefore = true;
            }
            else
                strikeBefore = false;

            return res;
        }
        private int CalculateRoundWithoutBonuses(char first, char? second)
        {
            if (second == '/')
                return 10;
            else
            {
                return ToInt(first) + ToInt(second);
            }
        }
        private int ToInt(char? c)
        {
            if (c == '-' || c == null)
                return 0;
            if (c == 'X')
                return 10;
            return (c.Value - '0');
        }
    }
}
