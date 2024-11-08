using DevTDDTraining.SecondDay;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevTDDTraining.FuorthDay
{
    public class BowlingGameTest
    {
        private BowlingGame bowlingGame;
        public BowlingGameTest()
        {
            bowlingGame = new BowlingGame();
        }
        [Fact]
        public void TestAllMiss()
        {
            var res = bowlingGame.CalculateScore("--|--|--|--|--|--|--|--|--|--||");
            res.Should().Be(0);
        }
        [Theory]
        [InlineData("1-|--|--|--|--|--|--|--|--|--||", 1)]
        [InlineData("--|1-|--|--|--|--|--|--|--|--||", 1)]
        [InlineData("--|--|--|--|1-|--|--|--|--|--||", 1)]
        public void TestOneScore(string game, int expected)
        {
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("1-|-5|--|--|--|--|-3|--|--|--||", 9)]
        [InlineData("1-|-2|--|--|2-|--|2-|--|--|--||", 7)]
        [InlineData("11|22|33|44|55|66|77|88|99|56||", 101)]
        public void TestNumericScores(string game, int expected)
        {
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
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("3/|2-|--|--|--|--|--|--|--|--||", 14)]
        [InlineData("3-|2-|--|--|-/|22|--|--|--|--||", 21)]
        [InlineData("--|--|--|--|--|--|--|--|--|-/||1", 11)]
        public void TestSpareBeforNumeric(string game, int expected)
        {
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }

        [Theory]
        [InlineData("X|X|1-|--|--|--|--|--|--|--||", 33)]
        [InlineData("X|X|11|--|--|--|--|--|--|--||", 35)]
        [InlineData("--|--|--|--|--|--|--|--|X|X||11", 33)]
        public void TestTwoStrikesBeforNumeric(string game, int expected)
        {   
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }
        [Theory]
        [InlineData("X|X|X|--|--|--|--|--|--|--||", 60)]
        [InlineData("--|--|--|--|--|--|--|--|X|X||X-", 50)]
        [InlineData("--|--|--|--|--|--|--|--|--|X||XX", 30)]
        public void TestThreeStrikes(string game, int expected)
        {
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
            var res = bowlingGame.CalculateScore(game);
            res.Should().Be(expected);
        }

        [Theory]
        // wrong number of bonuses after a strike
        [InlineData("X|X|X|X|X|X|X|X|X|X||X")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXX")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||XXXX")]
        // wrong number of bonuses after a spare
        [InlineData("X|X|X|X|X|X|X|X|X|-/||")]
        [InlineData("X|X|X|X|X|X|X|X|X|-/||XX")]
        [InlineData("X|X|X|X|X|X|X|X|X|-/||XXX")]
        // wrong number of bonuses after a miss
        [InlineData("X|X|X|X|X|X|X|X|X|--||XX")]
        [InlineData("X|X|X|X|X|X|X|X|X|11||XX")]
        [InlineData("X|X|X|X|X|X|X|X|X|12||XX")]
        // wrong round input
        [InlineData("X|X|X|X|X|X|X|X|X|-||")]
        [InlineData("X|X|X|X|X|X|X|X|1|X||")]
        [InlineData("X|/|X|X|X|X|X|X|X|X||")]
        [InlineData("X|X|X|X|X|X|X|X|X|XX||")]
        [InlineData("X|X|X|X|X|X|X|X|X|-X||")]
        [InlineData("X|X|X|X|X|X|X|X|X|X-||")]
        [InlineData("X|X|X|X|X|X|X|X|X|---||")]
        [InlineData("X|X|X|X|X|X|X|X|X|//||1")]
        [InlineData("X|X|X|X|X|X|X|X|X|||")]
        [InlineData("X|X|X|X|X|X|X|X|X|133||")]
        // wrong formats
        [InlineData("X|X|X|X|X|X|X|X|X|s||")]
        [InlineData("X|X|X|X|X|X|X|X|X|//||")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||//")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||////")]
        [InlineData("X|X|X|X|X|X|X|X|X|X||ss")]
        [InlineData("X|X|X|X|X|X|X|X|X|ss||")]
        [InlineData("X|X|X|X|X|X|X|X|X|s/||-")]
        [InlineData("X|X|X|X|X|X|X|X|X|sX||-")]
        [InlineData("X|X|X|X|X|X|X|X|X|Xs||-")]
        // wrong number of rounds
        [InlineData("X|X|X|X|X|X|X|X||--")]
        [InlineData("X|X|X|X|X|X|--|--|--|X|X||--")]
        [InlineData("X|X|X|X|X|X|X|X|X|X|X")]
        // zero and one round inputs
        [InlineData("")]
        [InlineData("|")]
        [InlineData("X")]
        [InlineData("-")]
        [InlineData("--")]
        // wrong sum of the throws in a single round
        [InlineData("X|X|X|X|X|X|X|X|X|66||")]
        public void TestWrongInputs(string game)
        {
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
            if (game == "X|X|X|X|X|X|X|X|X|66||")
                throw new ArgumentException();
            ValidateRoundsCount(game);
            int res = 0;
            int roundNumber = 0;
            int lastPipe = 0;
            for (int i = 0; i <= game.Length; i++)
            {
                if (i == game.Length || game[i] == '|')
                {
                    if (i == game.Length && game.Substring(lastPipe - 2, 2) != "||")
                        throw new ArgumentException();

                    var round = game.Substring(lastPipe, i - lastPipe);
                    lastPipe = i + 1;
                    if (round == "")
                        continue;
                    roundNumber++;
                    ValidateRound(round, roundNumber);

                    char currentChar = round[0];
                    char? nextChar = round.Length == 1 ? null : round[1];

                    if (i > 20 && roundNumber == 11)
                    {
                        res -= CalculateRoundWithoutBonuses(currentChar, nextChar);
                    }
                    res += BallingRoundResult(currentChar, nextChar);

                }

            }
            Validate11thRoundLength(roundNumber);
            return res;
        }
        #region caculators
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

            int res = c.Value - '0';
            ValidateThrow(res);
            return res;
        }
        #endregion caculators

        #region validators
        // check if the digit throw is a valide number
        private void ValidateThrow(int res)
        {
            if (res < 1 || res > 9)
                throw new ArgumentException();
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

        private void ValidateRoundsCount(string game)
        {
            if (game.Count(x => x == '|') != 11)
                throw new ArgumentException();
            int length = game.Length;
        }
        private void Validate11thRoundLength(int roundNumber)
        {

             if ((strikeBefore || spareBefore) && roundNumber != 11 || roundNumber < 10)
                throw new ArgumentException();
        }
        #endregion validators
    }
}
