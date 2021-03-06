﻿using UnityEngine;
using System.Collections;
using Mini2.Utils;

public class EnemySpawner : Singleton<EnemySpawner>{

    public GameObject pirateObj;
    public GameObject mayanObj;
    public GameObject spaceObj;
    [SerializeField]
    float laneWidth = 1;

    public float GetLaneWidth()
    {
        return laneWidth;
    }
    
    public void SpawnEnemy(float pos, EmptyEnemy Ee, EnemyType type, int _lane)
    {
        int lane = _lane;
        if(lane == -1)
        {
            lane = GetLane();
        }
        GameObject toSpawn;
        if(type == EnemyType.Mayan)
        {
            toSpawn = mayanObj;
        }
        else if(type == EnemyType.Pirate)
        {
            toSpawn = pirateObj;
        }
        else
        {
            toSpawn = spaceObj;
        }
        GameObject go = Instantiate(toSpawn, new Vector3(pos, 0, (lane - 1) * laneWidth), Quaternion.Euler(60,0,0)) as GameObject;
        go.transform.parent = transform;
        go.GetComponent<Enemy>().AssignEnemyType(lane, type);
    }

    int GetLane()
    {
        return Random.Range(0, 3);
    }
}
