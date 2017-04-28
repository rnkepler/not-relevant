using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapGeneration : MonoBehaviour {

    public GameObject tile;

    void Start () {
        //
        // Load map data from JSON file
        // The current map file being used is Assets/Resources/Maps/Map01.json and is a small 3 x 3 map
        // TODO: Don't hard code the map name
        TextAsset newMapData = Resources.Load("Maps/Map01") as TextAsset;
        string mapJson = newMapData.text;
        Debug.Log("Map is = " + mapJson, newMapData);

        //
        // Create the map object from the json data.  The tile grid can be created from this obect.
        GameMap newMap = JsonUtility.FromJson<GameMap>(newMapData.text);

        GenerateGrid(newMap);
    }

    void Update () {
		
	}

    /// <summary>
    /// Create the map with a grid of tiles
    /// </summary>
    /// <param name="map">Map definition</param>
    public void GenerateGrid(GameMap map)
    {
        // TODO: Tile needs to be selected by type
        // TODO: Decide on how to arrange the tiles.  Currently tiles are being placed in rows from left to right with the rows placed from bottom to top
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
