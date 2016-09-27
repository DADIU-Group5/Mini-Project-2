using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

    public GameObject[] terrainChunks; // should we make this a list?
    public float chunkLength = 1;
    public float moveSpeed = 5;
    public Vector3 spawnPoint = new Vector3(0, 0, 5);
    public float destroyZPos = -5;

    public LevelData levelData = new LevelData();
    public ChunkData[] chunkDatabase;

    private float timeBetweenSpawn;
    private GameObject lastChunk;
    private int spawnedChunks = 0;
    private bool spawnedAllChunks = false;
    private char[] terrains;

    // Use this for initialization
    void Start () {
        timeBetweenSpawn = chunkLength / moveSpeed;
        lastChunk = this.gameObject;
        terrainChunks = new GameObject[levelData.level.Length];
        terrains = levelData.level.ToCharArray();
        CreateNewChunk();
	}

    //Maybe use Update instead.
    void FixedUpdate()
    {
        if (spawnedAllChunks)
        {
            return;
        }

        if(lastChunk.transform.position.z + chunkLength < spawnPoint.z)
        {
            CreateNewChunk();
        }
    }

    void CreateNewChunk()
    {
        GameObject newChunk = Instantiate(ParseCharToGO(terrains[spawnedChunks++]), lastChunk.transform.position+Vector3.forward*chunkLength, Quaternion.identity) as GameObject;
        newChunk.GetComponent<TerrainMovement>().Setup(moveSpeed, destroyZPos);

        //Add chunk to list of chunks for later pooling:
        terrainChunks[spawnedChunks - 1] = newChunk; 

        lastChunk = newChunk;
        if(spawnedChunks >= levelData.level.Length)
        {
            spawnedAllChunks = true;
        }
    }

    GameObject ParseCharToGO(char c)
    {
        foreach (ChunkData item in chunkDatabase)
        {
            if(c == item.id)
            {
                return item.obj;
            }
        }
        return null;
    }
}
[System.Serializable]
public class LevelData
{
    //public char[] level;
    public string level;
}

[System.Serializable]
public class ChunkData
{
    public string name;
    public char id;
    //type 0 == nothing, type 1 == can spawn enemies, type 2 == obstacle.
    public int type = 0;
    public GameObject obj;  
}