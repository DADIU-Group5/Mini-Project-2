using UnityEngine;
using System.Collections;

public enum EnemyType
{
    Pirate, Mayan, Spaceman
}

public class Enemy : MonoBehaviour
{
    public bool hitByPlayer = false; // Whether the player has reached this enemy yet.
    public int lane;
    public EnemyType enemyType;
    [Range(1, 10f)]
    [Tooltip("Score points gained/lost from enemy")]
    public int enemyPoints = 1;
    private Animator enemyAnimator;

    void Start()
    {
        enemyAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // Die
        if (hitByPlayer || ScoreManager.instance.score >= 1)
        {
            //Enable animator:
            enemyAnimator.enabled = true;
        }
    }

    public void DestroySelf()
    {
        EnemyManager.instance.RemoveEnemyFromLane(lane);
        Destroy(gameObject);
    }

    public void DestroyedByPlayer()
    {
        ScoreManager.instance.ModifyPoint(0, true); //0: enemy
        if(enemyType == EnemyType.Pirate)
        {
            AudioMaster.instance.PlayEvent("enemySharkDeath");
        }else if (enemyType == EnemyType.Mayan)
        {
            AudioMaster.instance.PlayEvent("enemySkeletonDeath");
        }
        else if (enemyType == EnemyType.Spaceman)
        {
            AudioMaster.instance.PlayEvent("enemyBlobDeath");
        }
            DestroySelf();
    }

    public void AssignEnemyType(int _lane, EnemyType _type)
    {
        lane = _lane;
        enemyType = _type;
        EnemyManager.instance.AddEnemyToLane(lane, gameObject);
    }
}
