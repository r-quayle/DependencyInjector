using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rachel.Maths.Interface
{
    public interface IMathsLib
    {
        bool IsInCircle(Coords coords);
        Coords Square { get; set; }
    }
}
