using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.Maps.Tiles
{
    public interface ITile
    {
        int X { get; set; }
        int Y { get; set; }
        Color Foreground { get; set; }
        Color Background { get; set; }
        int GlyphIndex { get; set; }
        bool BlockSight { get; set; }
        bool BlockGroundMovement { get; set; }
        bool BlockFlyingMovement { get; set; }

        void Draw(SurfaceEditor se, int xPosition, int yPosition);
    }
}
