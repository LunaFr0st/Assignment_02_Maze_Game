using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtremeGeneration : MonoBehaviour
{
    [Header("Map Generation")]
    public GameObject[] tiles;
    public int mapSize = 20;
    public float offset = 6;

    int tileID;
    Vector3 tilePosition;
    GameObject clone;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Generate(float _offset)
    {
        for (int x = 0; x < mapSize; x++)
        {
            for (int z = 0; z < mapSize; z++)
            {
                tilePosition = new Vector3(transform.position.x + (x * _offset), 0, transform.position.z + (z * offset));

                clone = Instantiate(tiles[tileID], tilePosition, Quaternion.identity);
            }
        }
    }
}
