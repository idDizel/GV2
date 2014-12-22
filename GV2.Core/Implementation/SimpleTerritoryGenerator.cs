using GV2.Core.Interfaces;
using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Implementation
{
    public class SimpleTerritoryGenerator: ITerritoryGenerator
    {
        public void GenerateCapitals(Dictionary<Structures.Point, INode> nodes, IEnumerable<IPlayer> players, IGridGenerator<IShape> gridGenerator)
        {
            System.Random rnd = new System.Random();
            foreach(var player in players)
            {
                while (true)
                {
                    int X = rnd.Next(0, 5);
                    int Y = rnd.Next(0, 5);
                    Point point = nodes.Keys.Where(k => k.X == X && k.Y == Y).FirstOrDefault();
                    if (nodes[point].Owner != null) continue;
                    var neighbors = gridGenerator.GetNeighbors(point);
                    var neighborsKeys = nodes.Keys.Intersect(neighbors);
                    if (nodes.Where(n => neighborsKeys.Contains(n.Key) && n.Value.Owner == null).Count() == neighborsKeys.Count())
                    {
                        nodes[point].Owner = player;
                        nodes[point].NodeObject.GetComponent<MeshRenderer>().material.color = player.Color;
                        //nodes.Where(n => neighborsKeys.Contains(n.Key)).ToList().ForEach(n =>
                        //    {
                        //        n.Value.Owner = player;
                        //        n.Value.NodeObject.GetComponent<MeshRenderer>().material.color = player.Color;
                        //        n.Value.NodeObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
                        //    });
                        break;
                    }
                }
            }
        }

        public void GenerateTerritory(Dictionary<Structures.Point, INode> nodes, IEnumerable<IPlayer> players, IGridGenerator<IShape> gridGenerator)
        {
            throw new NotImplementedException();
        }
    }
}
