using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("Map Generation")]
    public GameObject[] tiles;
    public int mapSize = 20;
    public float offset = 3;

    int tileID;
    Vector3 tilePosition;
    GameObject clone;

    void Start()
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                int tileID = Random.Range(0, tiles.Length);
                tilePosition = new Vector3(transform.position.x + (x * offset), 0, transform.position.z + (z * offset));

                clone = Instantiate(tiles[tileID], tilePosition, Quaternion.identity);
            }
        }
    }
    void Update()
    {
        
    }

}
