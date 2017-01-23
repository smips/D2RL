using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Shapes;

namespace D2RL.Consoles.Game
{
    public class HealthConsole:SadConsole.Consoles.Console, BaseConsole
    {
        public HealthConsole(int width, int height):base(width, height)
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
            Box b = new Box(186, 205, 201, 187, 188, 200, 10, 10);
            b.FillColor = new Color(255, 0, 0);
            b.Fill = true;
            b.Draw(this);
            b.Location = new Point(Width - 10, 0);
            b.FillColor = new Color(0, 0, 255);
            b.Draw(this);
            

        }
    }
}
