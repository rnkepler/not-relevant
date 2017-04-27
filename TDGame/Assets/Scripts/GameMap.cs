using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameMap {
    public enum TileType { grass, road };

    public string mapName = "";

    public int mapWidth = 0;
    public int mapHeight = 0;

    public TileType[] tiles = new TileType[] {};

    public TileType getTileType(int x, int y)
    {
        //Debug.Log("Getting tile at " + x + ", " + y);
        TileType value = TileType.grass;

        int index = y * mapHeight + x;

        value = tiles[index];

        return value;
    }
}
