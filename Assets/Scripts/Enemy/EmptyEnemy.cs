using UnityEngine;
using System.Collections;

public class EmptyEnemy : MonoBehaviour {

    float spawnPos = 0;
    EnemyType becomeType;
    bool setup = false;
    int lane = -1;

    public void Setup(float _spawnPos, EnemyType type)
    {
        spawnPos = _spawnPos;
        becomeType = type;
        setup = true;
    }

    public void Setup(float _spawnPos, EnemyType type, int _lane)
    {
        spawnPos = _spawnPos;
        becomeType = type;
        lane = _lane;
        setup = true;
    }

    // Update is called once per frame
    void Update () {
        if (!setup)
        {
            return;
        }
	    if(transform.position.x < spawnPos)
        {
            MakeRealEnemy();
        }
	}

    void MakeRealEnemy()
    {
        EnemySpawner.instance.SpawnEnemy(transform.position.x, this, becomeType, lane);
        Destroy(gameObject);
    }
}
