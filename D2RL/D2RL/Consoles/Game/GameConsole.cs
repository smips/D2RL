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
        private static DungeonConsole dc;
        private static HealthConsole hc;
        private static MessageConsole mc;
        private static HotbarConsole hotbarConsole;

        public GameConsole() : base()
        {
            dc = new DungeonConsole(ConsoleConstants.DUNGEON_CONSOLE_WIDTH, ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);
            dc.Position = new Point(0, 0);

            hc = new HealthConsole(ConsoleConstants.HEALTH_CONSOLE_WIDTH, ConsoleConstants.HEALTH_CONSOLE_HEIGHT);
            hc.Position = new Point(0 ,ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);

            mc = new MessageConsole(ConsoleConstants.MESSAGE_CONSOLE_WIDTH, ConsoleConstants.MESSAGE_CONSOLE_HEIGHT);
            mc.Position = new Point((ConsoleConstants.DUNGEON_CONSOLE_WIDTH / 2) - (mc.Width / 2), ConsoleConstants.DUNGEON_CONSOLE_HEIGHT);

            hotbarConsole = new HotbarConsole(ConsoleConstants.HOTBAR_CONSOLE_WIDTH, ConsoleConstants.HOTBAR_CONSOLE_HEIGHT);
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

        public static MessageConsole GetMessageConsole()
        {
            return mc;
        }

        public static DungeonConsole GetDungeonConsole()
        {
            return dc;
        }

        public static HotbarConsole GetHotbarConsole()
        {
            return hotbarConsole;
        }

        public static HealthConsole GetHealthConsole()
        {
            return hc;
        }
    }
}
