using UnityEngine;
using System.Collections;

public class TerrainMovement : MonoBehaviour {

    float speed;
    float currentSpeed;
    float destroyPos = 0;

    public void Setup(float _speed, float _destroyPos)
    {
        speed = _speed;
        currentSpeed = speed;
        destroyPos = _destroyPos;
    }

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
        if (transform.position.x < destroyPos)
        {
            Remove();
        }
	}

    public virtual void Remove()
    {
        Destroy(gameObject);
    }

    public void StopMovement()
    {
        currentSpeed = 0;
    }

    public void ResumeMovement()
    {
        currentSpeed = speed;
    }
}