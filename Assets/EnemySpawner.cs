using UnityEngine;
using System.Collections;
using Mini2.Utils;

public class EnemySpawner : Singleton<EnemySpawner>{

    public GameObject pirateObj;
    public GameObject mayanObj;
    public GameObject spaceObj;
    
    public void SpawnEnemy(float pos, EmptyEnemy Ee, EnemyType type)
    {
        int lane = GetLane();
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
        GameObject go = Instantiate(toSpawn, new Vector3(pos, 0, lane-1), Quaternion.identity) as GameObject;
        go.GetComponent<Enemy>().AssignEnemyType(lane, type);
    }

    int GetLane()
    {
        return Random.Range(0, 3);
    }
}
