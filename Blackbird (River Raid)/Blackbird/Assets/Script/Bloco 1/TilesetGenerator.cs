using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesetGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float ySpawn = 0;
    public float tileLength = 200;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0, tilePrefabs.Length));

        }
    }




    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y - 15 > ySpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length));
            DeleteTile();
        }
    }
    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilePrefabs[tileIndex], transform.up * ySpawn, transform.rotation);
        activeTiles.Add(go);
        ySpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
