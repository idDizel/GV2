using GV2.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GV2.Core.Structures
{
    public struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public PointType PointType { get; set; }

        public Point(int x, int y)
            :this()
        {
            X = x;
            Y = y;
        }

        public Point(int x, int y, PointType type)
            :this(x, y)
        {
            PointType = type;
        }

        public Point(int x, int y, int z, PointType type)
           :this(x, y, type)
        {
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point)
            {
                Point p = (Point)obj;
                return X == p.X && Y == p.Y && Z == p.Z;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        }
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }

        public override string ToString()
        {
            return String.Format("X:{0}; Y:{1}, Z:{2}, PointType:{3}", this.X, this.Y, this.Z, this.PointType.ToString());
        }
    }
}
