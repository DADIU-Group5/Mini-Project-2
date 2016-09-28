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
        if (lane > 2 || lane < 0)
        {
            Debug.LogError("Lane: " + lane + " Does not exist");
            return;
        }
        //add new enemy go to given lane
        enemiesInLane[lane].Add(go);
    }

    /// <summary>
    /// Returns null if there is no enemy, or lane does not exist.
    /// </summary>
    /// <param name="lane"></param>
    /// <returns></returns>
    public GameObject NextEnemyInLane(int lane)
    {
        if(lane > 2 || lane < 0)
        {
            Debug.LogError("Lane: " + lane + " Does not exist");
            return null;
        }
        //check first enemy go in given lane
        if (enemiesInLane[lane].Count > 0)
        {
            return enemiesInLane[lane][0];
        }
        return null;
    }

    public float GetDistToNearestEnemyInLane(int lane)
    {
        GameObject temp = NextEnemyInLane(lane);
        if(temp == null)
        {
            return Mathf.Infinity;
        }
        if(temp.transform.position.x < 0)
        {
            return Mathf.Infinity;
        }
        return temp.transform.position.x;
    }

    public Enemy GetEnemyInLaneWithinDist(float f, int lane)
    {
        if(GetDistToNearestEnemyInLane(lane) > f)
        {
            return NextEnemyInLane(lane).GetComponent<Enemy>();
        }
        return null;
    }

    public void RemoveEnemyFromLane(int lane)
    {
        //remove first enemy go in given lane
        enemiesInLane[lane].RemoveAt(0);
    }
}
