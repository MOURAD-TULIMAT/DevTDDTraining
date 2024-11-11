using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DevTDDTraining.FifthDay
{
    public class MarsRoverApiTest
    {

        [Fact]
        public void StartingPoint00MoveUp()
        {
            var res = MarsRover.Move(0, 0, 'N', "f");
            res.Should().Be((0,1));
        }

    }

    public class MarsRover
    {
        public static (int,int) Move(int x, int y, char direction, string movements)
        {
            return (0, 1);
        }
    }
}
