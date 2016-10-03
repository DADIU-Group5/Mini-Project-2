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
    [Range(0.0f, 10.0f)]
    public float jumpingSpeed = 1.0f;
    [Range(0.0f, 2.0f)]
    public float jumpingHeight = 0.2f;

    private Rigidbody enemyRb;
    private EnemyType enemyType;
    private bool makeMoveSound;
    private float lastMoveSoundTime;
    private bool pointsGiven = false;
    private bool jumping = true;
    private float jumpedTime;
    private float fraction;

	void Start ()
    {
        enemyRb = this.gameObject.GetComponent<Rigidbody>();
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

        EnemyJump();
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

    /**
     * Controls jumping of enemies.
     */
    private void EnemyJump()
    {
        // Only jump if enemy is not dead
        if (!gameObject.GetComponent<Enemy>().getPointsGiven())
        {
            // If player is currently jumping but has reached peak of jump
            if (jumping && gameObject.transform.position.y >= jumpingHeight)
            {
                jumping = false;
                gameObject.transform.Translate(Vector3.down * jumpingSpeed * Time.deltaTime);
            }
            // If player is jumping and hasn't reached peak of jump
            else if (jumping && gameObject.transform.position.y < jumpingHeight)
            {
                gameObject.transform.Translate(Vector3.up * jumpingSpeed * Time.deltaTime);
            }
            // If player is not jumping and has landed
            else if (!jumping && gameObject.transform.position.y <= 0.0f)
            {
                jumping = true;
                gameObject.transform.Translate(Vector3.up * jumpingSpeed * Time.deltaTime);
            }
            // If player is not jumping but still falling
            else if (!jumping && gameObject.transform.position.y > 0.0f)
            {
                gameObject.transform.Translate(Vector3.down * jumpingSpeed * Time.deltaTime);
            }
        }
        // Fall gracefully to the ground when killed in the air
        else
        {
            if (gameObject.transform.position.y > 0.0)
            {
                gameObject.transform.Translate(Vector3.down * jumpingSpeed * Time.deltaTime);
            }
        }
    }
}
