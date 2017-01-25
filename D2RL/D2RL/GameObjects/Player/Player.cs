using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RL.Maps;
using Microsoft.Xna.Framework;

namespace D2RL.GameObjects.Player
{
    public class Player : GameObject
    {
        public Player(int x, int y, int glyph, Color foreground, Color background) : base(x, y, glyph, foreground, background)
        {

        }

    }
}
