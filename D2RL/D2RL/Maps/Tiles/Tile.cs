using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.Maps.Tiles
{
    public class Tile:ITile
    {
        private int _x;
        private int _y;
        private Color _foreground;
        private Color _background;
        private int _glyphIndex;
        private bool _blockSight;
        private bool _blockGroundMovement;
        private bool _blockFlyingMovement;


        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
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

        public bool BlockSight
        {
            get
            {
                return _blockSight;
            }

            set
            {
                _blockSight = value;
            }
        }

        public bool BlockGroundMovement
        {
            get
            {
                return _blockGroundMovement;
            }

            set
            {
                _blockGroundMovement = value;
            }
        }

        public bool BlockFlyingMovement
        {
            get
            {
                return _blockFlyingMovement;
            }

            set
            {
                _blockFlyingMovement = value;
            }
        }

        public Tile(int x, int y, int glyph, Color foreground, Color background)
        {
            X = x;
            Y = y;
            Foreground = foreground;
            Background = background;
            GlyphIndex = glyph;
        }

        public void Draw(SurfaceEditor se, int xPosition, int yPosition)
        {
            string character = ((char)GlyphIndex).ToString();
            se.Print(xPosition, yPosition, character, Foreground, Background);
        }

    }
}
