using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GV2.Core;
//using GV2.Core.Implementation;

public class Generator : MonoBehaviour {

	public int hexRadiusSize;
	public int matrixSize;
    //public Point[] Players = new Point[2];
    public List<Player> PlayersL = new List<Player>();

	void Start()
	{
        //INode ns = new HexagonNode(hexRadiusSize);
        //hexaGrid = ns.GenerateGrid();
        //this.GeneratePlayers(2);
        //this.GenerateArea();
        MapFacade mapFacade = new MapFacade();
        mapFacade.GenetrateGrid(5, 5);
	}

    //void GeneratePlayers(int count)
    //{
    //    for (int i = 0; i < count; i++)
    //    {
                

    //        while(true)
    //        {
    //            int x = Random.Range(0, matrixSize);
    //            int y = Random.Range(0, matrixSize);

    //            if(hexaGrid.CanBuildCapital(new Point(){X =x, Y=y}))
    //            {
    //                Players[i] = new Point() { X = x, Y = y };
    //                hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
    //                he`xaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner = new Player() { Color = hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color, Name = "Player" + i };
    //                PlayersL.Add(hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner);
    //                break;
    //            }
    //        }
    //    }

    //    var n = hexaGrid.GetNeighbors(new Point() { X = 1, Y = 1 });
    //    foreach (var nn in n)
    //    {
    //        Debug.Log(nn.Point);
    //    }
    //}
}
