using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TerrainGenerator : MonoBehaviour {
    [Header("Setup")]
    [Tooltip("Length of each chunk")]
    public float chunkLength = 1;
    [Tooltip("Speed at which the chunks move (how fast they leave the screen)")]
    public float moveSpeed = 5;
    [Tooltip("The position where the chunks spawn (chunks only move on the z axis)")]
    public Vector3 spawnPoint = new Vector3(10, 0, 0);
    [Tooltip("The Z-pos where the chunks despawn, should be more than 1 unit away from spawn z")]
    public float destroyXPos = -5;

    [Header("Enemy things")]
    [Space(10)]
    [Tooltip("An empty with the EmptyEnemy script attached")]
    public GameObject emptyEnemy;
    [Tooltip("The z-value where the enemies should spawn")]
    public float enemySpawnX = 5;

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
    private List<TerrainMovement> spawnedTerrains = new List<TerrainMovement>();

    // Use this for initialization
    void Start () {
        lastChunk = gameObject; //TODO: new way of getting the first spawn position.
        terrains = levelData.levelInfo.ToCharArray();
        CreateNewChunk();
        AvailablePoints();
	}

    public void AvailablePoints()
    {
        int maxPoints = 0;
        int minPoints = 0;

        //Finds max and min available points.
        foreach (char letter in terrains)
        {
            ChunkData chunk = ParseCharToGO(letter);
            if (chunk.type == TerrainType.Enemy)
            {
                maxPoints += ScoreManager.instance.enemyPoints;
                minPoints -= ScoreManager.instance.missEnemyPoints;
            } else if (chunk.type == TerrainType.Obstacle)
            {
                maxPoints += ScoreManager.instance.obstaclePoints;
                //missed obstacles do not currently count
                //minPoints -= ScoreManager.instance.missObstaclePoints;
            }
        }
        StarSystem.instance.maxPointsAvailable = maxPoints;
    }

    //Checks if the last chunk has moved far enough to spawn a new chunk.
    void FixedUpdate()
    {
        //Don't spawn any more when the last chunk has been spawned.
        if (spawnedAllChunks)
        {
            return;
        }

        if(lastChunk.transform.position.x + chunkLength < spawnPoint.x)
        {
            CreateNewChunk();
        }
    }

    /// <summary>
    /// Instansiates the next chunk.
    /// </summary>
    void CreateNewChunk()
    {
        ChunkData CD = ParseCharToGO(terrains[spawnedChunks]);
        if(CD == null)
        {
            Debug.LogError(terrains[spawnedChunks] + " returns null, make sure that letter is in the chunk database!");
            return;
        }

        SpawnChunk(CD);

        if(CD.type == TerrainType.Enemy)
        {
            CreateEnemies(CD);
        }
        
        if(spawnedChunks >= levelData.levelInfo.Length)
        {
            spawnedAllChunks = true;
        }
    }

    void SpawnChunk(ChunkData CD)
    {
        spawnedChunks++;
        GameObject newChunk = Instantiate(CD.obj, lastChunk.transform.position + Vector3.right * chunkLength, Quaternion.identity) as GameObject;
        newChunk.transform.parent = transform;
        newChunk.GetComponent<TerrainMovement>().Setup(moveSpeed, destroyXPos);
        spawnedTerrains.Add(newChunk.GetComponent<TerrainMovement>());
        lastChunk = newChunk;
    }

    void CreateEnemies(ChunkData CD)
    {
        GameObject newEnemy = Instantiate(emptyEnemy, lastChunk.transform.position, Quaternion.identity) as GameObject;
        newEnemy.GetComponent<EmptyEnemy>().Setup(enemySpawnX,CD.enemyType);
        newEnemy.transform.parent = lastChunk.transform;
    }

    /// <summary>
    /// Returns the gameobject that matches current char, returns null, if char does not exist in the chunkdatabase.
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    ChunkData ParseCharToGO(char c)
    {
        foreach (ChunkData item in chunkDatabase)
        {
            if(c == item.id)
            {
                return item;
            }
        }
        return null;
    }

    public void RemoveTerrainFromSpawnedList(TerrainMovement tm)
    {
        spawnedTerrains.Remove(tm);
    }

    public void StopTerrainMovement()
    {
        foreach (TerrainMovement item in spawnedTerrains)
        {
            item.StopMovement();
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
    public TerrainType type;
    [Tooltip("Only if type is enemy")]
    public EnemyType enemyType;
    public GameObject obj;
}

public enum TerrainType
{
    Empty, Enemy, Obstacle
}