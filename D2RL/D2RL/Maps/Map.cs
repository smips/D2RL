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
                    if (j % 2 == 0)
                    {
                        map[i, j] = new Tile(i, j, 0, new Color(255, 255, 255), new Color(0, 0, 0));
                    }
                    else
                    {
                        map[i, j] = new Tile(i, j, 0, new Color(255, 255, 255), new Color(255, 255, 255));
                    }
                    
                }
            }
        }

        public void Disable()
        {
            map = null;
        }

        public void Draw(SurfaceEditor se, Point start, Point end, int xOffset, int yOffset)
        {
            for(int i = 0; i < se.Width; i++)
            {
                for(int j = 0; j < se.Height; j++)
                {
                    int mapX = i + start.X;
                    int mapY = j + start.Y;
                    if (mapX >= 0 && mapX < Width && mapY >= 0 && mapY < Height)
                    {
                        map[i + start.X, j + start.Y].Draw(se, i, j);
                    }
                    else
                    {
                        se.Print(i, j, " ", new Color(0, 0, 0), new Color(0, 0, 0));
                    }
                }
            }


            //for (int i = start.X; i < end.X; i++)
            //{
            //    for (int j = start.Y; j < end.Y; j++)
            //    {
            //        int x = (i - start.X) + xOffset;
            //        int y = (j - start.Y) + yOffset;
            //        if (((x >= 0) && (y >= 0)) && ((x < se.Width) && (y < se.Height)))
            //        {
            //            map[x, y].Draw(se, i, j);
            //        }
            //        else
            //        {
            //            //se.Print(i, j, " ", new Color(0, 0, 0), new Color(0, 0, 0));
            //        }
            //    }
            //}
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
