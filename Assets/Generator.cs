using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public int hexRadiusSize;
	public int matrixSize;
	public Material hexagonMaterial;

	void Start()
	{
        HexagonObject clone = new HexagonObject(hexRadiusSize);

        float deltaX = 0;
        for (int i = 0; i < matrixSize; i++)
        {
            deltaX = i % 2 == 0 ? 0 : clone.OffsetX;
            for (int j = 0; j < matrixSize; j++)
            {
                GameObject.Instantiate(clone.Hexagon, new Vector3(deltaX + j * clone.OffsetX * 2, -(i * clone.OffsetY * 3), 0), Quaternion.identity);
            }
        }
        clone.Hexagon.SetActive(false);
	}

    void Generate()
    {
        
    }
    
}
