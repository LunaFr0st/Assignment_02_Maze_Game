using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("Map Generation")]
    public GameObject[] tiles;
    public int mapSize = 20;
    public float offset = 6;

    int tileID;
    public int[] rotationDirection;
    Vector3 tilePosition;
    Vector3 randomRot;
    GameObject clone;

    void Start()
    {
        GenerateMap(offset);
    }
    void Update()
    {

    }
    void GenerateMap(float _offset)
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                int tileID = Random.Range(0, tiles.Length);
                tilePosition = new Vector3(transform.position.x + (x * _offset), 0, transform.position.z + (z * offset));
                randomRot = new Vector3(0, rotationDirection[Random.Range(0,rotationDirection.Length)], 0);
                clone = Instantiate(tiles[tileID], tilePosition, Quaternion.Euler(randomRot), GameObject.Find("Map").transform);

            }
        }
    }

}
