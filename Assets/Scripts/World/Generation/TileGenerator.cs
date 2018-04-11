using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    [Header("Map Generation")]
    public GameObject[] tiles;
    public int mapSize = 20;
    public float offset = 6;
    bool finishCreated = false;

    int tileID;
    public int[] rotationDirection;
    Vector3 tilePosition;
    Vector3 randomRot;
    GameObject clone;

    void Start()
    {
        GenerateMap(offset, mapSize);
    }
    void Update()
    {
    }
    public void DeleteMap()
    {

    }

    public void GenerateMap(float _offset, int _mapSize)
    {
        for (int x = 0; x <= _mapSize; x++)
        {
            for (int z = 0; z <= _mapSize; z++)
            {
                int tileID = Random.Range(0, tiles.Length);
                if (!finishCreated)
                    tileID = Random.Range(0, tiles.Length);
                else
                    tileID = Random.Range(0, tiles.Length - 1);

                if (tileID == 4)
                {
                    finishCreated = true;
                }

                tilePosition = new Vector3(transform.position.x + (x * _offset), 0, transform.position.z + (z * offset));

                //Corner Pieces
                if (x == 0 && z == 0) // Bottom Left Corner
                    clone = Instantiate(tiles[3], tilePosition, Quaternion.Euler(new Vector3(0, 180, 0)), GameObject.Find("Map").transform);
                else if (x == _mapSize && z == 0) // Bottom Right Corner
                    clone = Instantiate(tiles[3], tilePosition, Quaternion.Euler(new Vector3(0, 90, 0)), GameObject.Find("Map").transform);
                else if (x == _mapSize && z == _mapSize) // Top Right Corner
                    clone = Instantiate(tiles[3], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), GameObject.Find("Map").transform);
                else if (x == 0 && z == _mapSize) // Top Left Corner
                    clone = Instantiate(tiles[3], tilePosition, Quaternion.Euler(new Vector3(0, -90, 0)), GameObject.Find("Map").transform);

                //Wall Pieces
                if ((x >= 1 && x < _mapSize) && z == 0)  // Bottom Wall
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 90, 0)), GameObject.Find("Map").transform);
                else if (x == 0 && (z >= 1 && z < _mapSize)) // Left Wall
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 180, 0)), GameObject.Find("Map").transform);
                else if (x == _mapSize && (z >= 1 && z < _mapSize)) // Right Wall
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, 0, 0)), GameObject.Find("Map").transform);
                else if ((x >= 1 && x < _mapSize) && z == _mapSize) // Top Wall
                    clone = Instantiate(tiles[2], tilePosition, Quaternion.Euler(new Vector3(0, -90, 0)), GameObject.Find("Map").transform);

                else
                {
                    randomRot = new Vector3(0, rotationDirection[Random.Range(0, rotationDirection.Length)], 0);
                    clone = Instantiate(tiles[tileID], tilePosition, Quaternion.Euler(randomRot), GameObject.Find("Map").transform);
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
