using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Shapes;

namespace D2RL.Consoles.Game
{
    public class HotbarConsole:SadConsole.Consoles.Console, BaseConsole
    {
        public HotbarConsole(int width, int height):base(width, height)
        {
            IsVisible = false;
            CanUseKeyboard = false;
        }

        public void Initialize()
        {
            if (!SadConsole.Engine.ConsoleRenderStack.Contains(this))
            {
                SadConsole.Engine.ConsoleRenderStack.Add(this);
            }

            ReDraw();
            IsVisible = true;
        }

        public void Disable()
        {
            Clear();
            VirtualCursor.Position = new Point(0, 0);
            IsVisible = false;

            if (SadConsole.Engine.ConsoleRenderStack.Contains(this))
            {
                SadConsole.Engine.ConsoleRenderStack.Remove(this);
            }
        }

        public void ReDraw()
        {
            Box b = new Box(186, 205, 204, 185, 188, 200, Width, Height);
            b.Draw(this);
        }
    }
}
