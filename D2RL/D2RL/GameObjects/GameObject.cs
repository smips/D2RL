using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D2RL.Maps;
using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.GameObjects
{
    public class GameObject : IGameObject
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

        }
        public int Y
        {
            get
            {
                return _y;
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
            _x = x;
            _y = y;
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


        public virtual bool Move(int dx, int dy, IMap map)
        {
            if (!isActive) { return false; }
            Point currentPosition = new Point(X, Y);
            Point desiredPosition = new Point(X + dx, Y + dy);
            if (map.CanMove(currentPosition, desiredPosition, MovementTypes.Walk))
            {
                _x = X + dx;
                _y = Y + dy;
                return true;
            }
            return false;
        }

        public bool MoveToward(Point target, IMap map)
        {
            if (!isActive) { return false; }
            List<Point> targetLine = Utilities.Geometry.GetLine(new Point(X, Y), target);
            if(targetLine.Count <= 1) { return false; }
            if (map.CanMove(new Point(X, Y), targetLine[1], MovementTypes.Walk))
            {
                _x = targetLine[1].X;
                _y = targetLine[1].Y;
                return true;
            }
            return false;
        }

    }
}
