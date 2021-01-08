using Rachel.Algorithms.Interfaces;
using Rachel.Maths;
using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.ConsoleApp
{
    public class ConsoleFunctions
    {
        IMathsLib _mathsLib;
        IMonteCarlo _monteCarlo;
        public ConsoleFunctions(IMathsLib mathsLib, IMonteCarlo monteCarlo)
        {
            _mathsLib = mathsLib;
            _monteCarlo = monteCarlo;
        }
        public bool Run(int x, int y) 
        {
            bool result = _mathsLib.IsInCircle(new Coords { X = x, Y = y });
            return result;
        }
        public void RunMonteCarlo()
        {
            decimal result = _monteCarlo.MyAlgo(100000000);
            Console.WriteLine(result);
        }
    }
}
