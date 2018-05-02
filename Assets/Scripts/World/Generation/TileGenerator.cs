using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("Map Generation")]
    public GameObject[] tiles;
    public int mapSize = 20;
    public float offset = 6;
    public int finishSize = 2;
    bool finishCreated = false;

    int tileID;
    public int[] rotationDirection;
    Vector3 tilePosition;
    Vector3 randomRot;
    GameObject clone;
    Transform mapTransform;

    void Start()
    {
        GenerateMap(offset, mapSize);
        mapTransform = GameObject.Find("Map").transform;
    }
    void Update()
    {
    }
    public void DeleteMap()
    {

    }

    public void GenerateMap(float _offset, int _mapSize)
    {
        int randX = Random.Range(2, _mapSize - 4);
        int randZ = Random.Range(2, _mapSize - 4);
        for (int x = 0; x <= _mapSize; x++)
        {
            for (int z = 0; z <= _mapSize; z++)
            {
                int tileID = Random.Range(0, tiles.Length - 1);
                tilePosition = new Vector3(transform.position.x + (x * _offset), 0, transform.position.z + (z * offset));

                //Corner Pieces
                if (x == 0 && z == 0) // Bottom Left Corner
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 180, 0)), mapTransform);
                else if (x == _mapSize && z == 0) // Bottom Right Corner
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 90, 0)), mapTransform);
                else if (x == _mapSize && z == _mapSize) // Top Right Corner
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), mapTransform);
                else if (x == 0 && z == _mapSize) // Top Left Corner
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, -90, 0)), mapTransform);

                //Wall Pieces
                if ((x >= 1 && x < _mapSize) && z == 0)  // Bottom Wall
                    clone = Instantiate(tiles[1], tilePosition, Quaternion.Euler(new Vector3(0, 90, 0)), mapTransform);
                else if (x == 0 && (z >= 1 && z < _mapSize)) // Left Wall
                    clone = Instantiate(tiles[1], tilePosition, Quaternion.Euler(new Vector3(0, 180, 0)), mapTransform);
                else if (x == _mapSize && (z >= 1 && z < _mapSize)) // Right Wall
                    clone = Instantiate(tiles[1], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), mapTransform);
                else if ((x >= 1 && x < _mapSize) && z == _mapSize) // Top Wall
                    clone = Instantiate(tiles[1], tilePosition, Quaternion.Euler(new Vector3(0, -90, 0)), mapTransform);

                //if ((x == randX && z == randZ) || (x == randX + 1 && z == randZ + 1) || (x == randX + 1 && z == randZ) || (x == randX && z == randZ + 1))
                //{
                //    clone = Instantiate(tiles[4], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), mapTransform);
                //}

                if ((x >= randX && x <= randX + finishSize) && (z >= randZ && z <= randZ + finishSize))
                {
                    clone = Instantiate(tiles[3], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), mapTransform);
                }

                else
                {
                    randomRot = new Vector3(0, rotationDirection[Random.Range(0, rotationDirection.Length)], 0);
                    clone = Instantiate(tiles[tileID], tilePosition, Quaternion.Euler(randomRot), mapTransform);
                }
                Debug.Log("Current X: " + x + " Current Z: " + z);
            }
        }
    }

    IEnumerator CheckFinishExists()
    {
        Debug.Log("");
        yield return new WaitForSeconds(10);
    }
}
