using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DFMathsLib;
using DFMathsLib.Interfaces;

namespace Rachel.Maths
{
    public class DFMathsLibWrapper : IMathsLib
    {
        IMathsLibrary _mathsLibrary;
        public Coords Square { get; set; } = new Coords { X = 100, Y = 100 };

        public DFMathsLibWrapper(IMathsLibrary mathsLibrary)
        {
            _mathsLibrary = mathsLibrary;
        }

        public bool IsInCircle(Coords coords)
        {
            bool result = _mathsLibrary.IsCoordsInCircle(coords.X, coords.Y);
            return result;
        }

    }
}
