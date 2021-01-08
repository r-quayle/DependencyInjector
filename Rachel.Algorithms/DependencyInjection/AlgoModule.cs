using Rachel.Algorithms.Interfaces;
using Rachel.DependencyInjector;
using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.Algorithms.DependencyInjection
{
    public class AlgoModule : DIModule
    {
        public override void Load(Container container)
        {
            container.Add<IMonteCarlo>(() => new MonteCarlo(container.Get<IMathsLib>()));
        }
    }
}
