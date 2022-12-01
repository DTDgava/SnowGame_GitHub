using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    private List<GameObject> activeTiles = new List<GameObject>();
    private float spawnPos = 0;
    private float tileLenght = 180;

    [SerializeField] private Transform player;
    private int startTiles = 1;

    private void Start()
    {
        for(int i = 0;i < startTiles; i++)
        {
            if(i==0)
                SpawnTile(tilePrefabs.Length - 1);

            SpawnTile(Random.Range(0, tilePrefabs.Length-1));
        }
    }
    private void Update()
    {
        if (player.position.z - 50 > spawnPos - (startTiles * tileLenght))
        {
            SpawnTile(Random.Range(0, tilePrefabs.Length-1));
            DeleteTile();
        }
    }
    private void SpawnTile(int tileIndex)
    {
        GameObject nextTile = Instantiate(tilePrefabs[tileIndex],transform.forward*spawnPos,transform.rotation);
        activeTiles.Add(nextTile);
        spawnPos += tileLenght;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
