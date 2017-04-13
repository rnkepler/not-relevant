using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGeneration : MonoBehaviour {

    public GameObject tile;

    void Start () {

        
        GenerateGrid();

	}
	
	void Update () {
		
	}

    public void GenerateGrid()
    {
         float cubeSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                GameObject cubeTile = (GameObject)Instantiate(tile, new Vector3(x * cubeSize -4.5f, y * cubeSize -4.5f, 0), Quaternion.identity);
                cubeTile.transform.SetParent(this.transform);
                cubeTile.name = ("Tile (" + x + ", " + y + ")");
            }
        }


    }
}
