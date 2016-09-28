using UnityEngine;
using System.Collections;

public class TerrainGenerator : MonoBehaviour {

    [Header("Setup")]
    [Tooltip("Length of each chunk")]
    public float chunkLength = 1;
    [Tooltip("Speed at which the chunks move (how fast they leave the screen)")]
    public float moveSpeed = 5;
    [Tooltip("The position where the chunks spawn (chunks only move on the z axis)")]
    public Vector3 spawnPoint = new Vector3(0, 0, 5);
    [Tooltip("The Z-pos where the chunks despawn, should be more than 1 unit away from spawn z")]
    public float destroyZPos = -5;
 
    [Header("Level Data")]
    [Space(20)]
    [Tooltip("The current levels data")]
    public LevelData levelData = new LevelData();
    [Tooltip("Chunk database, create the different chunks here. You should change values in the prefab, otherwise it won't be changed for all levels.")]
    public ChunkData[] chunkDatabase;

    //Private variables.
    private GameObject lastChunk;
    private int spawnedChunks = 0;
    private bool spawnedAllChunks = false;
    private char[] terrains;

    // Use this for initialization
    void Start () {
        lastChunk = gameObject; //TODO: new way of getting the first spawn position.
        terrains = levelData.levelInfo.ToCharArray();
        CreateNewChunk();
	}

    //Checks if the last chunk has moved far enough to spawn a new chunk.
    void FixedUpdate()
    {
        //Don't spawn any more when the last chunk has been spawned.
        if (spawnedAllChunks)
        {
            return;
        }

        if(lastChunk.transform.position.z + chunkLength < spawnPoint.z)
        {
            CreateNewChunk();
        }
    }

    /// <summary>
    /// Instansiates the next chunk.
    /// </summary>
    void CreateNewChunk()
    {
        GameObject temp = ParseCharToGO(terrains[spawnedChunks]);
        if(temp == null)
        {
            Debug.LogError(terrains[spawnedChunks] + " returns null, make sure that letter is in the chunk database!");
            return;
        }
        spawnedChunks++;
        GameObject newChunk = Instantiate(temp, lastChunk.transform.position+Vector3.forward*chunkLength, Quaternion.identity) as GameObject;
        newChunk.GetComponent<TerrainMovement>().Setup(moveSpeed, destroyZPos);

        lastChunk = newChunk;
        if(spawnedChunks >= levelData.levelInfo.Length)
        {
            spawnedAllChunks = true;
        }
    }

    /// <summary>
    /// Returns the gameobject that matches current char, returns null, if char does not exist in the chunkdatabase.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space");
            Obstacle temp = Obstacles.instance.GetNearestObstacle();
            if (temp != null)
            {
                temp.PlayerInteraction();
            }
        }
    }
}

[System.Serializable]
public class LevelData
{
    public string levelInfo;
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