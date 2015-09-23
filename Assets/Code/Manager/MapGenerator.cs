using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class MapGenerator : MonoBehaviour
{

    public List<GameObject> chunkList = new List<GameObject>();
    private List<GameObject> activeChunks = new List<GameObject>();
    private int MAX_CHUNKS = 20;
    private bool allowChunkGeneration = true;
    private bool allowChunkMovement = true;
    private int chunkCounter = 0;
    [SerializeField]
    private float chunkMoveSpeed = 0;

    void Start()
    {

        activeChunks.Add(generateChunk(chunkList[0], new Vector3(0, (getScreenHeight() + getChunkHeight(chunkList[0])))));
        generateStartingChunks();
    }

    void Update()
    {

        if (allowChunkMovement == true)
        {
            moveChunks(activeChunks);
        }
        if (allowChunkGeneration == true)
        {
            generateChunks();

        }
    }

    private void generateChunks()
    {

        for (int i = 0; i < activeChunks.Count; i++)
        {
            if (isOutOfBounds((activeChunks[i])))
            {
                generateChunkAfterLast();
                Destroy(activeChunks[i]);
                activeChunks.RemoveAt(i);
            }
        }
    }

    private GameObject generateChunk(GameObject chunk, Vector3 spawnPosition)
    {

        chunkCounter++;
        return (GameObject)Instantiate(chunk, spawnPosition, Quaternion.identity);
    }

    private GameObject selectRandomChunkFromChunkList(List<GameObject> chunks)
    {

        return chunks[Random.Range(2, chunks.Count)];
    }

    private void moveChunks(List<GameObject> chunks)
    {

        for (int i = 0; i < chunks.Count; i++)
        {
            chunks[i].transform.position += new Vector3(0, -chunkMoveSpeed);
        }
    }

    private bool isOutOfBounds(GameObject checkedChunk)
    {

        Vector2 screenPosition = Camera.main.WorldToScreenPoint(checkedChunk.transform.position);
        if (screenPosition.y <= getChunkHeight(checkedChunk) + -(Screen.height))
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    private float getScreenHeight()
    {

        return (Camera.main.orthographicSize / Camera.main.pixelHeight);
    }

    private Vector3 newChunkSpawnPoint(List<GameObject> chunks)
    {

        GameObject lastChunk = chunks.Last();
        Vector3 newSpawnPoint = new Vector3(lastChunk.transform.position.x, (lastChunk.transform.position.y + getChunkHeight(lastChunk)), lastChunk.transform.position.z);

        return newSpawnPoint;
    }

    private float getChunkHeight(GameObject chunk)
    {

        return chunk.GetComponent<BoxCollider2D>().size.y;
    }

    private void generateChunkAfterLast()
    {

        activeChunks.Add(generateChunk(selectRandomChunkFromChunkList(chunkList), newChunkSpawnPoint(activeChunks)));
    }

    private void generateStartingChunks()
    {

        for (int i = 0; i < MAX_CHUNKS; i++)
        {
            generateChunkAfterLast();
        }
    }



    public GameObject getFirstChunk
    {

        get
        {
            return this.activeChunks[0];
        }

    }

    public float getChunkSpeed
    {

        get
        {
            return chunkMoveSpeed;
        }
        set
        {
            chunkMoveSpeed = value;
        }
    }

    public bool setChunkGeneration
    {

        get
        {
            return allowChunkGeneration;

        }
        set
        {
            allowChunkGeneration = value;
            allowChunkMovement = value;

        }
    }

}
