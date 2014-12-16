using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class Extensions
    {
        public static IEnumerable<Node> GetNeighbors(this List<Node> nodes, Point p)
        {
            List<Node> neighbors = new List<Node>();
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X && pt.Point.Y == p.Y - 1).FirstOrDefault());   //X, Y-1
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y - 1).FirstOrDefault()); //X+1, Y-1
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X - 1 && pt.Point.Y == p.Y).FirstOrDefault());     //X-1, Y
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y - 1).FirstOrDefault()); //X+1, Y
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X && pt.Point.Y == p.Y + 1).FirstOrDefault());   //X, Y+1
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y + 1).FirstOrDefault()); //X+1, Y+1
            return neighbors.OfType<Node>();
        }
    }
