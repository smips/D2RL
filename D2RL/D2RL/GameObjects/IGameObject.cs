using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Consoles;
using D2RL.Maps;

namespace D2RL.GameObjects
{
    interface IGameObject
    {
        int X { get; }
        int Y { get; }
        int GlyphIndex { get; set; }
        Color Foreground { get; set; }
        Color Background { get; set; }

        void Initialize();
        void Destroy();
        void Draw(SurfaceEditor se, int xPosition, int yPosition);

        bool Move(int dx, int dy, IMap map);
        bool MoveToward(Point target, IMap map);
    }
}
