using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SadConsole.Input;
using SadConsole.Controls;
using Microsoft.Xna.Framework.Input;


namespace D2RL.Consoles.Debug
{
    class DebugConsole:SadConsole.Consoles.ControlsConsole
    {
        ListBox lb_consoles;

        public DebugConsole(int width, int height):base(width, height)
        {
            IsVisible = false;

            lb_consoles = new ListBox(30, 30);
            lb_consoles = new ListBox(20, 10);
            foreach (string c in Program.consoleNames)
            {
                lb_consoles.Items.Add(c);
            }
            lb_consoles.Position = new Microsoft.Xna.Framework.Point(textSurface.Width / 2 - lb_consoles.Width / 2,
                                                                         textSurface.Height / 2 - lb_consoles.Height / 2);
            lb_consoles.SelectedItemExecuted += Lb_consoles_SelectedItemExecuted;
            Add(lb_consoles);
        }

        private void Lb_consoles_SelectedItemExecuted(object sender, ListBox<ListBoxItem>.SelectedItemEventArgs e)
        {
            Program.ActivateConsole(lb_consoles.SelectedIndex);
        }

        public override bool ProcessKeyboard(KeyboardInfo info)
        {
            if (info.KeysPressed.Contains(AsciiKey.Get(Keys.Escape)))
            {
                System.Environment.Exit(0);
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Keys.F11)))
            {
                SadConsole.Engine.ToggleFullScreen();
            }
            else if (info.KeysPressed.Contains(AsciiKey.Get(Keys.F10)))
            {
                Print(0, 0, "                                                 ");
                Print(0, 0, String.Format("Width: {0} Height: {1}", this.Width, this.Height));
            }
            return base.ProcessKeyboard(info);
        }

        public override bool ProcessMouse(MouseInfo info)
        {
            Print(0, 1, "                                                        ");
            Print(0, 0, String.Format("X: {0} Y: {1}", info.ScreenLocation.X, info.ScreenLocation.Y));
            return base.ProcessMouse(info);
        }

        
    }
}
