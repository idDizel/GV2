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
        private IGridGenerator<IShape> map;
        private IShape shape;

        public Dictionary<Point, INode> Nodes { get; set; }

        public MapFacade()
        {
            this.map = new OffsetHorizontalGrid();
            this.shape = new HexagonShape(2);
        }

        public void GenetrateGrid(int width, int height)
        {
            this.shape.InitializeMesh();
            this.Nodes = this.map.GenerateGrid(width, height, shape);
            this.shape.DestroyNode();
        }
    }
}
