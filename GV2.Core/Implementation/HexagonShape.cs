using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace GV2.Core.Implementation
{
    public class HexagonShape: BaseShape
    {
        private readonly float Cos30 = (Mathf.Sqrt(3) / 2f);
        private readonly float Sin30 = 1f / 2f;
        private readonly float Cos90 = 0f;
        private readonly float Sin90 = 1f;

        public int Radius { get; set; }

        public override float OffsetX
        {
            get
            {
                return this.Radius * Cos30;
            }
        }

        public override float OffsetY
        {
            get
            {
                return this.Radius * Sin30;
            }
        }

        public HexagonShape(int radius)
            :base()
        {
            this.Radius = radius;
        }

        public override void InitializeMesh()
        {
            Mesh meshFilter = this.ShapeObject.AddComponent<MeshFilter>().mesh;
            this.ShapeObject.AddComponent<MeshRenderer>();

            meshFilter.Clear();

            #region InitHexagon
            meshFilter.vertices = new Vector3[]
		{
            //Point 0
		    new Vector3(-(Radius * Cos30), (Radius * Sin30),0),
            //Point 1
		    new Vector3((Radius * Cos90), (Radius * Sin90),0),
            //Point 2
		    new Vector3((Radius * Cos30), (Radius * Sin30),0),
            //Point 3
		    new Vector3((Radius * Cos30), -(Radius * Sin30),0),
            //Point 4
		    new Vector3((Radius * Cos90), -(Radius * Sin90),0),
            //Point 5
		    new Vector3(-(Radius * Cos30), -(Radius * Sin30),0),
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
}
