using UnityEngine;
using System.Collections;

public class EmptyEnemy : MonoBehaviour {

    float spawnPos = 0;
    WeakAgainst becomeType;
    bool setup = false;

    public void Setup(float _spawnPos, WeakAgainst type)
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
        Debug.Log("Make it a real enemy of type: "+becomeType);
        Destroy(gameObject);
    }
}
