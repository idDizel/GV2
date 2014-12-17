using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public static class Extensions
    {
        public static IEnumerable<Node> GetNeighbors(this List<Node> nodes, Point p)
        {
            Node node = nodes.Where(nd => nd.Point == p).FirstOrDefault();
            List<Node> neighbors = new List<Node>();
            
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X - 1 && pt.Point.Y == p.Y).FirstOrDefault());     //X-1, Y
            neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y).FirstOrDefault()); //X+1, Y
            if (node.NodeType == OffsetType.Odd)
            {
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X && pt.Point.Y == p.Y - 1).FirstOrDefault());   //X, Y-1
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y - 1).FirstOrDefault()); //X+1, Y-1

                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X && pt.Point.Y == p.Y + 1).FirstOrDefault());   //X, Y+1
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y + 1).FirstOrDefault()); //X+1, Y+1
            }
            else
            {
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X - 1 && pt.Point.Y == p.Y - 1).FirstOrDefault());   //X-1, Y-1
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X + 1 && pt.Point.Y == p.Y - 1).FirstOrDefault()); //X, Y-1

                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X - 1 && pt.Point.Y == p.Y + 1).FirstOrDefault());   //X-1, Y+1
                neighbors.Add(nodes.Where(pt => pt.Point.X == p.X && pt.Point.Y == p.Y + 1).FirstOrDefault()); //X, Y+1
            }
            return neighbors.OfType<Node>();
        }

        public static bool CanBuildCapital(this List<Node> nodes, Point p)
        {
            if(nodes.Find(n=>n.Point == p).Owner == null && nodes.GetNeighbors(p).Where(n=>n.Owner == null).Count() == nodes.GetNeighbors(p).Count())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
