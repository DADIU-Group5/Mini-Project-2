using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Enemy))]

public class EnemyMovement : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float enemySpeed = 1.0f;
    [Range(-10.0f, 10.0f)]
    public float destroyPoint = 0.0f;
    [Range(0.0f, 10.0f)]
    public float moveSoundFrequency = 1.0f;

    private Rigidbody enemyRb;
    private EnemyType enemyType;
    private bool makeMoveSound;
    private float lastMoveSoundTime;

	void Start ()
    {
        enemyRb = this.gameObject.GetComponent<Rigidbody>();
        enemyType = this.gameObject.GetComponent<Enemy>().enemyType;
    }
	
	void Update ()
    {
        if (this.gameObject.transform.position.x <= destroyPoint)
        {
            ScoreManager.instance.ModifyPoint(0, false); //type: enemy (0), give points: false
            this.gameObject.GetComponent<Enemy>().DestroySelf();
        }
        else
        {
            EnemyMove();
        }
	}

    private void EnemyMove()
    {
        enemyRb.velocity = new Vector3(-1.0f * enemySpeed, enemyRb.velocity.y, enemyRb.velocity.z);

        makeMoveSound = (Time.timeSinceLevelLoad - lastMoveSoundTime) > moveSoundFrequency;
        if (makeMoveSound)
        {
            if (enemyType == EnemyType.Pirate)
            {
                AudioMaster.instance.PlayEvent("enemySharkMove");
            }
            else if (enemyType == EnemyType.Mayan)
            {
                AudioMaster.instance.PlayEvent("enemySkeletonMove");
            }
            else if (enemyType == EnemyType.Spaceman)
            {
                AudioMaster.instance.PlayEvent("enemyBlolbMove");
            }
            lastMoveSoundTime = Time.timeSinceLevelLoad;
        }
    }


}
