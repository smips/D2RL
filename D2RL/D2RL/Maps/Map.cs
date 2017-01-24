using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using D2RL.Maps.Tiles;
using Microsoft.Xna.Framework;
using SadConsole.Consoles;

namespace D2RL.Maps
{   

    public class Map : IMap
    {
        private ITile[,] map;
        private int _width;
        private int _height;

        public int Width
        {
            get
            {
                return _width;
            }

            set
            {
                _width = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }

            set
            {
                _height = value;
            }
        }

        public Map(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public void Initialize()
        {
            map = new ITile[Width, Height];
            for(int i = 0; i < Width; i++)
            {
                for(int j = 0; j < Height; j++)
                {
                    map[i, j] = new Tile(i, j, 46, new Color(255, 255, 255), new Color(0, 0, 0));
                }
            }
        }

        public void Disable()
        {
            map = null;
        }

        public void Draw(SurfaceEditor se, Point start, Point end, int xOffset, int yOffset)
        {
            for (int i = start.X; i < end.X; i++)
            {
                for (int j = start.Y; j < end.Y; j++)
                {
                    map[(i - start.X) + xOffset, (j - start.Y) + yOffset].Draw(se, i, j);
                }
            }
        }

        public bool CanMove(Point currentPosition, Point desiredPosition, MovementTypes MovementType)
        {
            switch (MovementType)
            {
                case (MovementTypes.Walk):
                    bool insideMap = (desiredPosition.X >= 0) && (desiredPosition.Y >= 0) && (desiredPosition.X < Width) && (desiredPosition.Y < Height);
                    
                    return insideMap;
                    
                default:
                    return false;
            }
        }
    }
}
