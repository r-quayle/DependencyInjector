using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.DependencyInjector
{
    public abstract class DIModule
    {
        public abstract void Load(Container container);
    }
}
