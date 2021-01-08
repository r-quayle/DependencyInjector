using Rachel.Algorithms.Interfaces;
using Rachel.Maths;
using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.Algorithms
{
    internal class MonteCarlo : IMonteCarlo
    {
        IMathsLib _mathsLib;
        public MonteCarlo(IMathsLib mathsLib)
        {
            _mathsLib = mathsLib;

        }
        public decimal MyAlgo(int hits)
        {
            int insideCount = 0;
            int outsideCount = 0;
            int firstQuarterCounter = 0;
            int secondQuarterCounter = 0;
            int thirdQuarterCounter = 0;
            int fourthQuarterCounter = 0;
            Coords coords = new Coords();
            Random rnd = new Random();
            int radius = _mathsLib.Square.X / 2;
            for (int i = 0; i < hits; i++)
            {
                
                coords.X = rnd.Next(0,_mathsLib.Square.X + 1);
                coords.Y = rnd.Next(0,_mathsLib.Square.Y + 1);
                bool result = _mathsLib.IsInCircle(coords);
                insideCount += result ? 1 : 0;
                outsideCount += result ? 0 : 1;


                //bool quarter1 = (coords.X <= radius && coords.Y < radius);
                //firstQuarterCounter += quarter1 ? 1 : 0;
                //bool quarter2 = (coords.X <= radius && coords.Y > radius);
                //secondQuarterCounter += quarter2 ? 1 : 0;
                //bool quarter3 = (coords.X > radius && coords.Y <= radius);
                //thirdQuarterCounter += quarter3 ? 1 : 0;
                //bool quarter4 = (coords.X > radius && coords.Y >= radius);
                //fourthQuarterCounter += quarter4 ? 1 : 0;
            }
            return outsideCount == 0 ? 0 : (decimal)insideCount / (decimal)outsideCount;
            //return firstQuarterCounter/hits;
        }
    }
}
