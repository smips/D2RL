using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using D2RL.Consoles;
using Microsoft.Xna.Framework;
using SadConsole.Input;

namespace D2RL.Consoles.MainMenu
{
    public class MainMenuConsole:SadConsole.Consoles.Console, BaseConsole
    {
        public MainMenuConsole(int width, int height) : base(width, height)
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
            Clear();
            string msg = "D2RL";
            Print((Width / 2) - (msg.Length / 2), Height / 2, msg);
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if (info.KeysPressed.Contains(AsciiKey.Get(Microsoft.Xna.Framework.Input.Keys.Space)))
            {
                Disable();
                var charCreationScreen = new CharacterCreation.CharacterCreationConsole(Width, Height);
                charCreationScreen.Initialize();
            }
            return base.ProcessKeyboard(info);
        }

    }
}
