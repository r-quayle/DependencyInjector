using Rachel.Algorithms.Interfaces;
using Rachel.DependencyInjector;
using Rachel.Maths.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.ConsoleApp.DependencyInjector
{
    public class AppModule : DIModule
    {
        public override void Load(Container container)
        {
            container.Add<ConsoleFunctions>(() => new ConsoleFunctions(container.Get<IMathsLib>(), container.Get<IMonteCarlo>()), Lifetimes.Singleton);
        }
    }
}
