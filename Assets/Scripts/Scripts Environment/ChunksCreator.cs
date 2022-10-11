using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunksCreator : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Chunk[] ChunkPrefabs;
    [SerializeField] private Chunk firstChunk;

    private readonly List<Chunk> spawnChunks = new List<Chunk>();

    private void Start()
    {   
        spawnChunks.Add(firstChunk);

        StartCoroutine(SpawnLag());
    }

    IEnumerator SpawnLag()
    {
        this.SpawnChunk();

        yield return new WaitForSeconds((float)3);
        Debug.Log("lag");
    }

    private void Update()
    {
        if (player.position.x > spawnChunks[spawnChunks.Count - 1].End.position.x - 500)
        {
            SpawnChunk();
        }
    }

    private void SpawnChunk()
    {
         Chunk newChunk = Instantiate(ChunkPrefabs[Random.Range(0, ChunkPrefabs.Length)]);

        newChunk.transform.position = spawnChunks[spawnChunks.Count - 1].End.position - newChunk.Begin.localPosition;
        spawnChunks.Add(newChunk);

        if (spawnChunks.Count >= 7)
        {
            Destroy(spawnChunks[0].gameObject);

            spawnChunks.RemoveAt(0);
        }
        
    }
}
