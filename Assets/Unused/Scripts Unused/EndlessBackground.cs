using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndlessBackground : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private Chunk[] ChunkPrefabs;
    [SerializeField] private Chunk firstChunk;

    [SerializeField] private float scale;

    Material material;

    Vector2 offset = Vector2.zero;

    private readonly List<Chunk> spawnChunks = new List<Chunk>();

    private void Start()
    {
        spawnChunks.Add(firstChunk);

        player = transform.root;
        material = GetComponent<SpriteRenderer>().material;
    }

    private void Update()
    {
        if (player.position.x > spawnChunks[spawnChunks.Count - 1].End.position.x - 500)
        {
            SpawnChunk();
            Debug.Log("SpawnChunk");

            offset = new Vector2(player.position.x / 100f / scale, 0f);
            material.mainTextureOffset = offset;
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
