using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {

    public GameObject hexPrefab;

    int width = 50;
    int height = 50;

    float offsetX = 0.982f;
    float offsetY = 0.85f;

	// Use this for initialization
	void Start () {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

                float xPos = x * offsetX;

                if (y % 2 == 1)
                {
                    xPos += offsetX/2;
                }
                Instantiate(hexPrefab, new Vector2(xPos, offsetY * y), Quaternion.identity);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
