using UnityEngine;
using System.Collections;

public class TerrainMovement : MonoBehaviour {

    float speed;
    float destroyPos = 0;

    public void Setup(float _speed, float _destroyPos)
    {
        speed = _speed;
        destroyPos = _destroyPos;
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
        if (transform.position.z < destroyPos)
        {
            Remove();
        }
	}

    public virtual void Remove()
    {
        Destroy(gameObject);
    }
}