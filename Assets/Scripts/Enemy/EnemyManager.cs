using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mini2.Utils;

public class EnemyManager : Singleton<EnemyManager>
{
    public List<GameObject>[] enemiesInLane = new List<GameObject>[3];

    void Start()
    {
        enemiesInLane[0] = new List<GameObject>();
        enemiesInLane[1] = new List<GameObject>();
        enemiesInLane[2] = new List<GameObject>();
    }

    public void AddEnemyToLane(int lane, GameObject go)
    {
        //add new enemy go to given lane
        enemiesInLane[lane].Add(go);
    }

    public GameObject NextEnemyInLane(int lane)
    {
        //check first enemy go in given lane
        GameObject tempGO = enemiesInLane[lane][0];
        return tempGO;
    }

    public void RemoveEnemyFromLane(int lane)
    {
        //remove first enemy go in given lane
        enemiesInLane[lane].RemoveAt(0);
    }
}
