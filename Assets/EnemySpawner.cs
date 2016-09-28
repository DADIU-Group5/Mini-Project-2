using UnityEngine;
using System.Collections;
using Mini2.Utils;

public class EnemySpawner : Singleton<EnemySpawner>{

    public GameObject enemyObj;
    
    public void SpawnEnemy(float pos, EmptyEnemy Ee, EnemyType type)
    {
        int lane = GetLane();
        GameObject go = Instantiate(enemyObj, new Vector3(pos, 0, lane-1), Quaternion.identity) as GameObject;
        go.GetComponent<Enemy>().AssignEnemyType(lane, type);
    }

    int GetLane()
    {
        return Random.Range(0, 3);
    }
}
