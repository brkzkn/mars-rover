using MarsRover.Library;
using MarsRover.Library.Enums;
using MarsRover.Library.Models;
using System;
using System.Linq;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToList();
            var startPositions = Console.ReadLine().Trim().Split(' ');

            var upperRight = new Coords(maxPoints[0], maxPoints[1]);
            Rover rover = new Rover(upperRight);

            Coords roverPosition = new Coords(0,0);
            Directions direction = Directions.N;

            if (startPositions.Count() == 3)
            {
                roverPosition = new Coords(Convert.ToInt32(startPositions[0]), Convert.ToInt32(startPositions[1]));
                direction = (Directions)Enum.Parse(typeof(Directions), startPositions[2]);
            }

            var moves = Console.ReadLine().ToUpper();

            try
            {
                rover.Move(roverPosition, direction, moves);
                Console.WriteLine($"{rover.CurrentPosition.X} {rover.CurrentPosition.Y} {rover.Direction}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
