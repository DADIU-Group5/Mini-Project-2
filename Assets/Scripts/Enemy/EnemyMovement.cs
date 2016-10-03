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

    private EnemyType enemyType;
    private bool makeMoveSound;
    private float lastMoveSoundTime;
    private bool pointsGiven = false;

	void Start ()
    {
        enemyType = this.gameObject.GetComponent<Enemy>().enemyType;
        enemySpeed = GameObject.FindObjectOfType<TerrainGenerator>().moveSpeed;
    }
	
	void Update ()
    {
        if (this.gameObject.transform.position.x <= destroyPoint && !pointsGiven)
        {
            ScoreManager.instance.ModifyPoint(0, false); //type: enemy (0), give points: false
            this.gameObject.GetComponent<Enemy>().DestroySelf();
            pointsGiven = true;
        }
        else
        {
            if (this.gameObject.transform.position.x <= GameObject.Find("Player").transform.position.x)    // the enemy has passed hugo and should be marked untargetable
                this.gameObject.GetComponent<Enemy>().SetTargetable(false);

            EnemyMove();
        }
	}

    private void EnemyMove()
    {
        this.gameObject.transform.Translate(Vector2.left * enemySpeed * Time.deltaTime);

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
