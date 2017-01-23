using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SadConsole.Shapes;

namespace D2RL.Consoles
{
    public interface BaseConsole:SadConsole.Consoles.IConsole
    {
        void Initialize();
        void Disable();
        void ReDraw();
    }
}
