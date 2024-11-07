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
        [InlineData("--|--|--|--|--|--|--|--|--|X||-X", 20)]
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
        [InlineData("X|X|X|X|X|X|X|X|X|X||X")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|-/||")]
        [InlineData("X|X|X|X|X|X|X|X|X|-/||XX")]
        [InlineData("X|X|X|X|X|X|X|X|X|-/||XXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|-||")]
        [InlineData("X|X|X|X|X|X|X|X|X|---||")]
        [InlineData("X|X|X|X|X|X|X|X|X|--||XX")]
        [InlineData("X|X|X|X|X|X|X|X|X|X-||")]
        [InlineData("X|X|X|X|X|X|X|X|X|XX||")]
        [InlineData("X|X|X|X|X|X|X|X|X|-X||")]
        [InlineData("X|X|X|X|X|X|X|X|X|||")]
        [InlineData("X|X|X|X|X|X|X|X|X|s||")]
        [InlineData("X|X|X|X|X|X|X|X|X|133||")]
        [InlineData("X|X|X|X|X|X|X|X|X|//||")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||//")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||////")]
        [InlineData("X|X|X|X|X|X|X|X||--")]
        [InlineData("X|X|X|X|X|X|--|--|--|X|X||--")]
        [InlineData("X|X|X|X|X|X|X|X|X|X|XX")]
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
        private bool mainRoundsFinished = false;

        public int CalculateScore(string game)
        {
            int res = 0;
            int roundNumber = 0;
            int lastPipe = 0;
            for (int i = 0; i <= game.Length; i++)
            {
                if (i == game.Length || game[i] == '|')
                {
                    // init
                    var round = game.Substring(lastPipe, i - lastPipe);
                    lastPipe = i + 1;
                    ValidateRound(round, roundNumber);
                    if (round == "")
                    {
                        continue;
                    }
                    roundNumber++;

                    char currentChar = round[0];
                    char? nextChar = round.Length == 1 ? null : round[1];

                    if (i > 20 && roundNumber == 11)
                    {
                        res -= CalculateRoundWithoutBonuses(currentChar, nextChar);
                    }
                    res += BallingRoundResult(currentChar, nextChar);

                }

            }
            if ((strikeBefore || spareBefore) && roundNumber != 11 || roundNumber < 10)
                throw new ArgumentException();

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
        private void ValidateRound(string round, int roundNumber)
        {
            if ((round.Length > 2) ||
                (round.Length == 1 && round != "X" && roundNumber != 11) ||
                (round == "-X" && roundNumber != 11) ||
                (round == "//"))
            {
                throw new ArgumentException();
            }
            if(roundNumber == 10)
            {
                if(round == "")
                    mainRoundsFinished = true;
                else if(!mainRoundsFinished)
                    throw new ArgumentException();
            }
            if (roundNumber == 11)
            {
                if ((strikeBefore && round.Length != 2) ||
                    (!strikeBefore && spareBefore && round.Length != 1) ||
                    (!strikeBefore && !spareBefore && roundNumber > 10))
                {
                    throw new ArgumentException();
                }
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
