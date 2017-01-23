using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.GameObjects
{
    public class GameObject:IGameObject
    {
        private int _x;
        private int _y;
        private int _glyphIndex;
        private Color _foreground;
        private Color _background;
        private bool isActive;

        public int X
        {
            get
            {
                return _x;
            }

            set
            {
                _x = value;
            }
        }
        public int Y
        {
            get
            {
                return _y;
            }

            set
            {
                _y = value;
            }
        }
        public int GlyphIndex
        {
            get
            {
                return _glyphIndex;
            }

            set
            {
                _glyphIndex = value;
            }
        }
        public Color Foreground
        {
            get
            {
                return _foreground;
            }

            set
            {
                _foreground = value;
            }
        }
        public Color Background
        {
            get
            {
                return _background;
            }

            set
            {
                _background = value;
            }
        }

        public GameObject(int x, int y, int glyph, Color foreground, Color background)
        {
            X = x;
            Y = y;
            GlyphIndex = glyph;
            Foreground = foreground;
            Background = background;
            isActive = false;
        }

        public void Initialize()
        {
            isActive = true;
        }

        public void Destroy()
        {
            isActive = false;
        }

        public void Draw(SurfaceEditor se, int xOffset, int yOffset)
        {
            if (isActive)
            {
                string character = ((char)GlyphIndex).ToString();
                se.Print(X + xOffset, Y + yOffset, character, Foreground, Background);
            }
        }

    }
}
