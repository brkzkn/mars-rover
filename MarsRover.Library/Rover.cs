using MarsRover.Library.Enums;
using MarsRover.Library.Models;
using System;

namespace MarsRover.Library
{
    public interface IRover
    {
        void Move(Coords roverPosition, Directions direction, string commands);
    }

    public class Rover : IRover
    {
        public Coords CurrentPosition;
        public Directions Direction;

        private Coords _upperRight;

        #region Constructors
        public Rover(Coords upperRight)
        {
            _upperRight = upperRight;
            CurrentPosition = new Coords(0, 0);
            Direction = Directions.N;
        }

        #endregion

        #region Private Methods
        private void Rotate90Left()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.W;
                    break;
                case Directions.S:
                    this.Direction = Directions.E;
                    break;
                case Directions.E:
                    this.Direction = Directions.N;
                    break;
                case Directions.W:
                    this.Direction = Directions.S;
                    break;
                default:
                    break;
            }
        }

        private void Rotate90Right()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.Direction = Directions.E;
                    break;
                case Directions.S:
                    this.Direction = Directions.W;
                    break;
                case Directions.E:
                    this.Direction = Directions.S;
                    break;
                case Directions.W:
                    this.Direction = Directions.N;
                    break;
                default:
                    break;
            }
        }

        private void MoveInSameDirection()
        {
            switch (this.Direction)
            {
                case Directions.N:
                    this.CurrentPosition.Y += 1;
                    break;
                case Directions.S:
                    this.CurrentPosition.Y -= 1;
                    break;
                case Directions.E:
                    this.CurrentPosition.X += 1;
                    break;
                case Directions.W:
                    this.CurrentPosition.X -= 1;
                    break;
                default:
                    break;
            }
        }
        #endregion

        /// <summary>
        /// Apply commands and check position on rover 
        /// </summary>
        /// <param name="roverPosition">Rover start position</param>
        /// <param name="direction">Rover start direction</param>
        /// <param name="commands">Series of instructions</param>
        public void Move(Coords roverPosition, Directions direction, string commands)
        {
            this.Direction = direction;
            this.CurrentPosition = roverPosition;

            foreach (var command in commands)
            {
                switch (command)
                {
                    case 'M':
                        this.MoveInSameDirection();
                        break;
                    case 'L':
                        this.Rotate90Left();
                        break;
                    case 'R':
                        this.Rotate90Right();
                        break;
                    default:
                        Console.WriteLine($"Invalid Character {command}");
                        break;
                }

                if (this.CurrentPosition.X < 0 || this.CurrentPosition.X > _upperRight.X || this.CurrentPosition.Y < 0 || this.CurrentPosition.Y > _upperRight.Y)
                {
                    throw new Exception($"Oops! Position can not be beyond bounderies (0 , 0) and ({_upperRight.X} , {_upperRight.Y})");
                }
            }
        }
    }
}
