using UnityEngine;
using System.Collections;

public class EmptyEnemy : MonoBehaviour {

    float spawnPos = 0;
    EnemyType becomeType;
    bool setup = false;

    public void Setup(float _spawnPos, EnemyType type)
    {
        spawnPos = _spawnPos;
        becomeType = type;
        setup = true;
    }

	// Update is called once per frame
	void Update () {
        if (!setup)
        {
            return;
        }
	    if(transform.position.z < spawnPos)
        {
            MakeRealEnemy();
        }
	}

    void MakeRealEnemy()
    {
        EnemySpawner.instance.SpawnEnemy(transform.position.x, this, becomeType);
        Destroy(gameObject);
    }
}
