using DFMathsLib.Interfaces;
using Rachel.DependencyInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DFMathsLib.DependencyInjection
{
    public class LogicModule : DIModule
    {
        public override void Load(Container container)
        {
            container.Add<IMathsLibrary>(() => new MathsLibrary());
        }
    }
}
