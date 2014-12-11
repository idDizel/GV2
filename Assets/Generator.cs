using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Generator : MonoBehaviour {

	public int hexRadiusSize;
	public int matrixSize;
	public Material hexagonMaterial;
    public List<Node> hexaGrid = new List<Node>();
    public Point[] Players = new Point[2];
    public List<Player> PlayersL = new List<Player>();

	void Start()
	{
        HexagonObject clone = new HexagonObject(hexRadiusSize);

        float deltaX = 0;
        for (int i = 0; i < matrixSize; i++)
        {
            deltaX = i % 2 == 0 ? 0 : clone.OffsetX;
            for (int j = 0; j < matrixSize; j++)
            {
                hexaGrid.Add(new Node(){Point = new Point(){X=j, Y = i}, Hexagon=(GameObject)GameObject.Instantiate(clone.Hexagon, new Vector3(deltaX + j * clone.OffsetX * 2, -(i * clone.OffsetY * 3), 0), Quaternion.identity)});
            }
        }
        clone.Hexagon.SetActive(false);
        this.GeneratePlayers(2);
        //this.GenerateArea();
	}

    void GeneratePlayers(int count)
    {
        for (int i = 0; i < count; i++)
        {
                int x = Random.Range(0, matrixSize);
                int y = Random.Range(0, matrixSize);

                if (Players.Where(p => p.X == x && p.Y == y).Count() == 0)
                {
                    Players[i] = new Point() { X = x, Y = y };
                }
                hexaGrid.Where(p=>p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
                hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner = new Player() { Color = hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Hexagon.GetComponent<MeshRenderer>().material.color, Name = "Player" + i };
                PlayersL.Add(hexaGrid.Where(p => p.Point.Equals(Players[i])).FirstOrDefault().Owner);

        }
    }
    
    void GenerateArea()
    {
        Node next = hexaGrid.Where(p => p.Owner == PlayersL.FirstOrDefault()).FirstOrDefault();
        while(hexaGrid.Where(p=>p.Owner == null).Count()!=0)
        {
            foreach(var p in PlayersL)
            {
                
            }
        }
    }

    void FillMap(Player p)
    {

    }
}
