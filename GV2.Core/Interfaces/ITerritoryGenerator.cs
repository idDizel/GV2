using GV2.Core.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GV2.Core.Interfaces
{
    public interface ITerritoryGenerator
    {
        void GenerateCapitals(Dictionary<Point, INode> nodes, IEnumerable<IPlayer> players);
        void GenerateTerritory(Dictionary<Point, INode> nodes, IEnumerable<IPlayer> players);
    }
}
