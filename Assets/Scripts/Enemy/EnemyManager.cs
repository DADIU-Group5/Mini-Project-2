using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mini2.Utils;

public class EnemyManager : Singleton<EnemyManager>
{
    public List<GameObject> enemies = new List<GameObject>();

    void Start()
    { }

    public List<GameObject> GetAllEnemies()
    {
        return enemies;
    }

    public void AddEnemyToLane(int lane, GameObject newEnemy)
    {
        if (lane > 2 || lane < 0)
        {
            Debug.LogError("Lane: " + lane + " Does not exist");  // TODO: wtf?
            return;
        }
        //add new enemy go to given lane
        AudioMaster.instance.PlayEvent("summonSkeleton");
        enemies.Add(newEnemy);
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

        foreach(var enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>().lane == lane)
            {
                if(enemy.GetComponent<Enemy>().IsTargetable() == true)
                    return enemy;
            }
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
        if(GetDistToNearestEnemyInLane(lane) < f)
        {
            GameObject temp = NextEnemyInLane(lane);
            if (temp != null)
            {
                return temp.GetComponent<Enemy>();
            }
        }
        return null;
    }

    public void RemoveEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
    }

    /*
    public void RemoveEnemyFromLane(int lane)
    {
        //remove first enemy go in given lane
        foreach (var enemy in enemies)
        {
            if (enemy.GetComponent<Enemy>().lane == lane)
            {
                enemies.Remove(enemy);                         // TODO: check if removal inside loop causes issues

                return;
            }
        }
    }
    */
}
