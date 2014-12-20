using GV2.Core.Enums;
using GV2.Core.Interfaces;
using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Implementation
{
    public class OffsetHorizontalMap: IMap<IShape>
    {
        public Dictionary<Point, GameObject> Generate(int width, int height, IShape shape)
        {
            Dictionary<Point, GameObject> nodes = new Dictionary<Point, GameObject>();
            float deltaX = 0;
            for (int i = 0; i < height; i++)
            {
                deltaX = i % 2 == 0 ? 0 : shape.OffsetX;
                for (int j = 0; j < width; j++)
                {
                    nodes.Add(new Point(j, i, deltaX == 0 ? PointType.Even : PointType.Odd), shape.GetInstance(new Vector3(deltaX + j * shape.OffsetX * 2, -(i * shape.OffsetY * 3), 0)));
                }
            }
            return nodes;
        }

        public IEnumerable<Point> GetNeighbors(Point point)
        {
            Point[] points = new Point[6]; 
            if(point.PointType == PointType.Even)
            {
                points[0] = new Point(point.X - 1 , point.Y - 1);
                points[1] = new Point(point.X, point.Y - 1);
                points[4] = new Point(point.X - 1, point.Y + 1);
                points[5] = new Point(point.X, point.Y + 1);
            }
            else
            {
                points[0] = new Point(point.X, point.Y - 1);
                points[1] = new Point(point.X + 1, point.Y - 1);
                points[4] = new Point(point.X, point.Y + 1);
                points[5] = new Point(point.X + 1, point.Y + 1);
            }
            points[2] = new Point(point.X - 1, point.Y);
            points[3] = new Point(point.X + 1, point.Y);
            return points;
        }
    }
}
