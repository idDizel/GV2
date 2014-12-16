using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is Point)
        {
            Point p = (Point)obj;
            return X == p.X && Y == p.Y;
        }
        else
        {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return X.GetHashCode() ^ Y.GetHashCode();
    }
    public static bool operator == (Point p1, Point p2)
    {
        return p1.Equals(p2);
    }

    public static bool operator !=(Point p1, Point p2)
    {
        return !p1.Equals(p2);
    }

    public override string ToString()
    {
        return String.Format("X:{0}; Y:{1}", this.X, this.Y);
    }
}

