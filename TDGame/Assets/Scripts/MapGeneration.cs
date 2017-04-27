using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour {

    public GameObject tile;

    void Start () {
        //
        // Load map data from JSON file
        TextAsset newMapData = Resources.Load("Maps/Map01") as TextAsset;
        string mapJson = newMapData.text;
        Debug.Log("Map is = " + mapJson, newMapData);
        GameMap newMap = JsonUtility.FromJson<GameMap>(newMapData.text);

        GenerateGrid(newMap);
    }

    void Update () {
		
	}

    public void GenerateGrid(GameMap map)
    {
        float cubeSize = tile.GetComponent<SpriteRenderer>().sprite.bounds.size.x;

        int width = map.mapWidth;
        int height = map.mapHeight;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject cubeTile = (GameObject)Instantiate(tile, new Vector3(x * cubeSize -4.5f, y * cubeSize -4.5f, 0), Quaternion.identity);
                cubeTile.transform.SetParent(this.transform);

                //
                // Get the tile type.  grass, road, ect
                GameMap.TileType tileType = map.getTileType(x, y);

                cubeTile.name = ("Tile (" + x + ", " + y + ") type: " + tileType);
            }
        }
    }
}
