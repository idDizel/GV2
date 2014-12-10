using UnityEngine;
using System.Collections;

public class HexagonObject
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
        this.Hexagon = new GameObject("Hexagon");
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
}
