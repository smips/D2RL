﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2RL.Consoles.Game
{
    public class SkillsConsole:SadConsole.Consoles.Console, BaseConsole
    {
        public SkillsConsole(int width, int height):base(width, height)
        {
            CanUseKeyboard = false;
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void ReDraw()
        {
            throw new NotImplementedException();
        }
    }
}
