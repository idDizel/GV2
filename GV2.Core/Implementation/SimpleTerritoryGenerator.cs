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
            
            foreach(var player in players)
            {
                Point point = nodes.Keys.Where(k => k.X == UnityEngine.Random.Range(0, 5) && k.Y == UnityEngine.Random.Range(0, 5)).FirstOrDefault();
                var neighbors = gridGenerator.GetNeighbors(point);
                var neighborsKeys = nodes.Keys.Intersect(neighbors);
                nodes[point].Owner = player;
                nodes[point].NodeObject.GetComponent<MeshRenderer>().material.color = player.Color;
                nodes.Where(n => neighborsKeys.Contains(n.Key)).ToList().ForEach(n=>
                    {
                        //Debug.Log(n.Key.ToString());
                        n.Value.Owner = player;
                        n.Value.NodeObject.GetComponent<MeshRenderer>().material.color = player.Color;
                        n.Value.NodeObject.GetComponent<MeshFilter>().mesh.RecalculateNormals();
                    });
            }
        }

        public void GenerateTerritory(Dictionary<Structures.Point, INode> nodes, IEnumerable<IPlayer> players, IGridGenerator<IShape> gridGenerator)
        {
            throw new NotImplementedException();
        }
    }
}
