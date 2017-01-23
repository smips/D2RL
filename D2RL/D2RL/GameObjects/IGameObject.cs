using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.GameObjects
{
    interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }
        int GlyphIndex { get; set; }
        Color Foreground { get; set; }
        Color Background { get; set; }

        void Initialize();
        void Destroy();
        void Draw(SurfaceEditor se, int xPosition, int yPosition);
    }
}
