using GV2.Core.Interfaces;
using GV2.Core.Structures;
using GV2.Core.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core
{
    public class MapFacade
    {
        private IShape shape;
        private IGridGenerator<IShape> gridGenerator;
        private ITerritoryGenerator territoryGenerator;

        public Dictionary<Point, INode> Nodes { get; set; }

        public MapFacade()
        {
            this.gridGenerator = new OffsetHorizontalGrid();
            this.shape = new HexagonShape(2);
            this.territoryGenerator = new SimpleTerritoryGenerator();
        }

        public void GenetrateGrid(int width, int height)
        {
            this.shape.InitializeMesh();
            this.Nodes = this.gridGenerator.GenerateGrid(width, height, shape);
            this.shape.DestroyNode();
        }

        public void GeneratePlayers()
        {
            this.territoryGenerator.GenerateCapitals(Nodes, new Player[] { new Player() { Name = "Player1", Color = new Color(0.5f, 0.77f, 0.33f) } }, gridGenerator);
        }
    }
}
