using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Library.Models
{
    public struct Coords
    {
        public Coords(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }
}
