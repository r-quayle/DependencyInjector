using DFMathsLib.Interfaces;
using Rachel.DependencyInjector;
using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.Maths.DependencyInjector
{
    public class MathsLibModule : DIModule
    {
        public override void Load(Container container)
        {
            container.Add<IMathsLib>(() => new MathsLib());//DFMathsLibWrapper(container.Get<IMathsLibrary>()));
        }
    }
}
