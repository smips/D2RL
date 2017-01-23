using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SadConsole.Consoles;
using Microsoft.Xna.Framework;

namespace D2RL.Maps
{
    public interface IMap
    {
        int Width { get; set; }
        int Height { get; set; }
        void Initialize();
        void Disable();
        void Draw(SurfaceEditor se, Point start, Point end, int xOffset, int yOffset);
    }
}
