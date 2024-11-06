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
            var res = game.CalculateScore("--|--|--|--|--|--|--|--|--|--");
        }
    }
    public class BowlingGame
    {
        internal object CalculateScore(string game)
        {
            return 0;
        }
    }
}
