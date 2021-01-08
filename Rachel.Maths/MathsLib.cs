using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.Maths
{
    public class MathsLib : IMathsLib
    {
        public Coords Square { get; set; } = new Coords { X = 100, Y = 100 };
        public bool IsInCircle(Coords coords)
        {
            Coords center = new Coords { X = Square.X / 2, Y = Square.Y / 2 };
            int x = coords.X - center.X;
            int y = coords.Y - center.Y;
            double distance = Math.Sqrt((x*x) + (y*y));
            return distance < Square.X / 2;
        }
    }
}
