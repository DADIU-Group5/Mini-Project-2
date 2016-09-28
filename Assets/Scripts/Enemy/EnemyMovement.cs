using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float enemySpeed = 1.0f;
    [Range(-10.0f, 10.0f)]
    public float destroyPoint = -5.0f;

    private Rigidbody enemyRb;

	void Start ()
    {
        enemyRb = this.gameObject.GetComponent<Rigidbody>();
    }
	
	void Update ()
    {
        if (gameObject.transform.position.x <= destroyPoint)
        {
            gameObject.GetComponent<Enemy>().DestroySelf();
        }
        else
        {
            EnemyMove();
        }
	}

    private void EnemyMove()
    {
        enemyRb.velocity = new Vector3(-1.0f * enemySpeed, enemyRb.velocity.y, enemyRb.velocity.z);
    }
}
