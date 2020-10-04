using MarsRover.Library;
using MarsRover.Library.Enums;
using MarsRover.Library.Models;
using System;
using Xunit;

namespace MarsRover.Test
{
    public class RoverTest
    {
        [Fact]
        public void TestScanrio_21W_RRMMMLRLLMR()
        {
            Coords maxPoints = new Coords(5, 5);
            Rover rover = new Rover(maxPoints);

            var moves = "RRMMMLRLLMR";
            Coords currentPosition = new Coords(2, 1);

            rover.Move(currentPosition, Directions.W, moves);

            var actualOutput = $"{rover.CurrentPosition.X} {rover.CurrentPosition.Y} {rover.Direction}";
            var expectedOutput = "4 1 N";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestScanrio_23S_MMMRRLLLRMRMLLMR()
        {
            Coords maxPoints = new Coords(10, 10);
            Rover rover = new Rover(maxPoints);

            var moves = "MMRRLLLRMRLLMR";
            Coords currentPosition = new Coords(2, 3);

            rover.Move(currentPosition, Directions.S, moves);

            var actualOutput = $"{rover.CurrentPosition.X} {rover.CurrentPosition.Y} {rover.Direction}";
            var expectedOutput = "3 0 S";

            Assert.Equal(expectedOutput, actualOutput);
        }

        [Fact]
        public void TestScenario_ThrowException()
        {
            Coords maxPoints = new Coords(1, 1);
            Rover rover = new Rover(maxPoints);

            var moves = "LMLMLMLMM";
            Coords currentPosition = new Coords(1, 2);

            var exception = Assert.Throws<Exception>(() =>
            {
                rover.Move(currentPosition, Directions.N, moves);
            });

            var expectedExceptionMsg = $"Oops! Position can not be beyond bounderies (0 , 0) and ({maxPoints.X} , {maxPoints.Y})";
            Assert.Equal(expectedExceptionMsg, exception.Message);
        }
    }
}
