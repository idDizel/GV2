using GV2.Core.Implementation;
using GV2.Core.Interfaces;
using GV2.Core.Structures;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace GV2.Test
{
    [TestFixture]
    public class MapGenerationTests
    {
        private IShape shape;
        private IGridGenerator<IShape> gridGenerator;
        private Dictionary<Point, INode> nodes;

        [TestFixtureSetUp]
        public void Initialize()
        {
            this.shape = new HexagonShape(2);
            this.gridGenerator = new OffsetHorizontalGrid();
            this.nodes = gridGenerator.GenerateGrid(5, 5, shape);
        }

        [Test]
        public void GenerateGrid_Size5x5_ReturnCount25()
        {
            bool result = nodes.Count == 25;
            Assert.IsTrue(result, "nodes size mismatch");
        }
    }
}
