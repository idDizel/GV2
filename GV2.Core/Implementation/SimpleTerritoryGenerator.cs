using GV2.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GV2.Core.Implementation
{
    public class SimpleTerritoryGenerator: ITerritoryGenerator
    {

        public void GenerateCapitals(Dictionary<Structures.Point, INode> nodes, IEnumerable<IPlayer> players)
        {
            Random rnd = new Random();
            for (int i = 0; i < players.Count(); i++)
            {
                while(true)
                {
                    int x = rnd.Next(0, 5);
                    int y = rnd.Next(0, 5);

                    //if(hexaGrid.CanBuildCapital(new Point(){X =x, Y=y}))
                    //{
                    //    Players[i] = new Point() { X = x, Y = y };
                    //    hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                    //    he`xaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner = new Player() { Color = hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color, Name = "Player" + i };
                    //    PlayersL.Add(hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner);
                    //    break;
                    //}
                }
            }
        }

        public void GenerateTerritory(Dictionary<Structures.Point, INode> nodes, IEnumerable<IPlayer> players)
        {
            throw new NotImplementedException();
        }


    }
}
