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
        public void StartingPoint00MoveForwardNorth()
        {
            var res = MarsRover.Move(0, 0, 'N', "f");
            res.Should().Be(new Point(0,1));
        }
        [Theory]
        [InlineData(0, 3,0,4)]
        public void FacingNorthMoveForward(int x ,int y, int expectedX, int expectedY)
        {
            var res = MarsRover.Move(x, y, 'N', "f");
            res.Should().Be(new Point(expectedX, expectedY));
        }
    }

    public class MarsRover
    {
        public static Point Move(int x, int y, char direction, string movements)
        {
            return new Point(0, 1);
        }
    }

    public record Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int x;
        public int y;
    }
}   
