using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HexagonObject: INodeObject
{
    public GameObject hex;

    private readonly float Cos30 = (Mathf.Sqrt(3) / 2f);
    private readonly float Sin30 = 1f / 2f;
    private readonly float Cos90 = 0f;
    private readonly float Sin90 = 1f;

    public int Radius { get; private set; }

    public GameObject Hexagon { get; private set; }

    public float OffsetX {
        get
        {
            return this.Radius * Cos30;
        }
    }

    public float OffsetY
    {
        get
        {
            return this.Radius * Sin30;
        }
    }

    public HexagonObject(int hexagonRadius)
    {
        this.Radius = hexagonRadius;
        this.NodeObject = new GameObject("Hexagon");
        Mesh meshFilter = this.Hexagon.AddComponent<MeshFilter>().mesh;
        this.Hexagon.AddComponent<MeshRenderer>();

		meshFilter.Clear();

		#region InitHexagon
		meshFilter.vertices = new Vector3[]
		{
            //Point 0
		    new Vector3(-(hexagonRadius * Cos30), (hexagonRadius * Sin30),0),
            //Point 1
		    new Vector3((hexagonRadius * Cos90), (hexagonRadius * Sin90),0),
            //Point 2
		    new Vector3((hexagonRadius * Cos30), (hexagonRadius * Sin30),0),
            //Point 3
		    new Vector3((hexagonRadius * Cos30), -(hexagonRadius * Sin30),0),
            //Point 4
		    new Vector3((hexagonRadius * Cos90), -(hexagonRadius * Sin90),0),
            //Point 5
		    new Vector3(-(hexagonRadius * Cos30), -(hexagonRadius * Sin30),0),
		};
		meshFilter.uv = new Vector2[]
		{
			new Vector2(0,0.25f),
			new Vector2(0,0.75f),
			new Vector2(0.5f,1),
			new Vector2(1,0.75f),
			new Vector2(1,0.25f),
			new Vector2(0.5f,0),
		};
		meshFilter.triangles = new int[]
		{
			1,5,0,
			1,4,5,
			1,2,4,
			2,3,4
		};
		#endregion

		meshFilter.RecalculateNormals();
    }

    public GameObject ObjectInitializer(Vector3 vector)
    {
        return (GameObject)GameObject.Instantiate(NodeObject, vector, Quaternion.identity);
    }

    public List<Node> GridGenerator(int size, Func<Vector3, GameObject> initializer)
    {
        List<Node> nodes = new List<Node>();
        float deltaX = 0;
        for (int i = 0; i < size; i++)
        {
            deltaX = i % 2 == 0 ? 0 : OffsetX;
            for (int j = 0; j < size; j++)
            {
                nodes.Add(new Node() { NodeType = deltaX == 0 ? OffsetType.Even : OffsetType.Odd, Point = new Point() { X = j, Y = i }, Hexagon = initializer(new Vector3(deltaX + j * OffsetX * 2, -(i * OffsetY * 3), 0)) });
            }
        }
        return nodes;
    }

    public void MeshInitializer()
    {

    }

    public GameObject NodeObject
    {
        get;
        set;
    }
}
