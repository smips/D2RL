using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Input;
using D2RL.GameObjects;

namespace D2RL.Consoles.Game
{
    public class DungeonConsole:SadConsole.Consoles.Console, BaseConsole
    {
        private System.Timers.Timer mouseMoveTimer = new System.Timers.Timer(40);
        private bool canProcessMouseMove = true;
        private Maps.Map map = new Maps.Map(80,40);
        private GameObject player = new GameObject(5, 5, 2, new Color(200, 200, 200), new Color(0, 0, 0));

        public DungeonConsole(int width, int height):base(width, height)
        {
            IsVisible = false;
            CanUseKeyboard = false;
            UsePixelPositioning = false;
            mouseMoveTimer.Elapsed += MouseMoveTimer_Elapsed;
        }

        private void MouseMoveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            canProcessMouseMove = true;
        }

        public void Initialize()
        {
            if (!SadConsole.Engine.ConsoleRenderStack.Contains(this))
            {
                SadConsole.Engine.ConsoleRenderStack.Add(this);
            }
            map.Initialize();
            player.Initialize();
            ReDraw();
            IsVisible = true;
            IsFocused = true;

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
            map.Draw(this, new Point(0, 0), new Point(Width, Height), 0, 0);
            player.Draw(this, 0, 0);
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.F1)))
            {
                FillWithRandomGarbage();
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Left)))
            {
                player.Move(-1, 0, map);
                ReDraw();
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Right)))
            {
                player.Move(1, 0, map);
                ReDraw();
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Up)))
            {
                player.Move(0, -1, map);
                ReDraw();
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Down)))
            {
                player.Move(0, 1, map);
                ReDraw();
            }
            return base.ProcessKeyboard(info);
        }

        public override bool ProcessMouse(MouseInfo info)
        {
            if (info.LeftButtonDown && canProcessMouseMove)
            {
                player.MoveToward(info.WorldLocation, map);
                ReDraw();
                canProcessMouseMove = false;
                mouseMoveTimer.Start();              
            }
            return base.ProcessMouse(info);
        }

    }
}
