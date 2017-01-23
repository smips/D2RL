using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SadConsole.Input;

namespace D2RL.Consoles.CharacterCreation
{
    public class CharacterCreationConsole : SadConsole.Consoles.Console, BaseConsole
    {
        public CharacterCreationConsole(int width, int height):base(width, height)
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
            Clear();
            string msg = "Character Creation Screen";
            Print((Width / 2) - (msg.Length / 2), Height / 2, msg);
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if (info.KeysReleased.Contains(AsciiKey.Get(Keys.Space)))
            {
                Disable();
                var gameScreen = new Game.GameConsole();
                gameScreen.Initialize();
            }
            return base.ProcessKeyboard(info);
        }

    }
}
