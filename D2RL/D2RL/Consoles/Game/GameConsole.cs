using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RL.GameConstants.ConsoleConstants;
using Microsoft.Xna.Framework;

namespace D2RL.Consoles.Game
{
    public class GameConsole : SadConsole.Consoles.ConsoleList, BaseConsole
    {
        public GameConsole() : base()
        {
            DungeonConsole dc = new DungeonConsole(ConsoleConstants.DUNGEON_CONSOLE_WIDTH, ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);
            dc.Position = new Point(0, 0);

            HealthConsole hc = new HealthConsole(ConsoleConstants.HEALTH_CONSOLE_WIDTH, ConsoleConstants.HEALTH_CONSOLE_HEIGHT);
            hc.Position = new Point(0 ,ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);

            MessageConsole mc = new MessageConsole(ConsoleConstants.MESSAGE_CONSOLE_WIDTH, ConsoleConstants.MESSAGE_CONSOLE_HEIGHT);
            mc.Position = new Point((ConsoleConstants.DUNGEON_CONSOLE_WIDTH / 2) - (mc.Width / 2), ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);

            HotbarConsole hotbarConsole = new HotbarConsole(ConsoleConstants.HOTBAR_CONSOLE_WIDTH, ConsoleConstants.HOTBAR_CONSOLE_HEIGHT);
            hotbarConsole.Position = new Point((ConsoleConstants.DUNGEON_CONSOLE_WIDTH / 2) - (hotbarConsole.Width / 2), ConsoleConstants.DUNGEON_CONSOLE_HEIGHT + ConsoleConstants.HOTBAR_CONSOLE_HEIGHT);

            Add(dc);
            Add(hc);
            Add(mc);
            Add(hotbarConsole);

        }

        public void Disable()
        {
            foreach (BaseConsole c in this)
            {
                c.Disable();
            }
        }

        public void Initialize()
        {
            foreach(BaseConsole c in this.ToList())
            {
                c.Initialize();
            }
        }

        public void ReDraw()
        {
            foreach (BaseConsole c in this)
            {
                c.ReDraw();
            }
        }
    }
}
