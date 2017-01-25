using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;

namespace D2RL.Utilities
{
    public static class Geometry
    {
        private static void Swap<T>(ref T lhs, ref T rhs) { T temp; temp = lhs; lhs = rhs; rhs = temp; }

        public static List<Point> GetLine(Point start, Point end)
        {
            List<Point> result = new List<Point>();
            int x0 = start.X;
            int x1 = end.X;
            int y0 = start.Y;
            int y1 = end.Y;

            bool steep = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);
            if (steep) { Swap<int>(ref x0, ref y0); Swap<int>(ref x1, ref y1); }
            if (x0 > x1) { Swap<int>(ref x0, ref x1); Swap<int>(ref y0, ref y1); }
            int dX = (x1 - x0), dY = Math.Abs(y1 - y0), err = (dX / 2), ystep = (y0 < y1 ? 1 : -1), y = y0;

            for (int x = x0; x <= x1; ++x)
            {
                if (steep)
                {
                    result.Add(new Point(y, x));
                }
                else
                {
                    result.Add(new Point(x, y));
                }
                err = err - dY;
                if (err < 0) { y += ystep; err += dX; }
            }
            if (result[0] != start)
            {
                result.Reverse();
            }
            return result;
        }

    }
}
