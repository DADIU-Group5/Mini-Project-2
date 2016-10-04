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
    bool test = false;
    bool pointsGiven = false;
    private bool targetable = true;

    void Start()
    {
        // display spawn effect
        var effect = GameObject.Find("SpawnEffect");
        effect.transform.SetParent(transform, false);
        effect.GetComponent<ParticleSystem>().Play();
    }

    void Update()
    {
       
    }

    public void DestroySelf()//is being called continuosly...
    {
        StartCoroutine("WaitingCoroutine");
    }

    IEnumerator WaitingCoroutine()
    {
        yield return new WaitForSeconds(1);
        EnemyManager.instance.RemoveEnemy(gameObject);
        Destroy(gameObject);
    }

    public void DestroyedByPlayer()
    {
        if (!pointsGiven)
        {
            ScoreManager.instance.ModifyPoint(0, true); //0: enemy
            if (enemyType == EnemyType.Pirate)
            {
                AudioMaster.instance.PlayEvent("enemySharkDeath");
                AudioMaster.instance.PlayEvent("rewardKillPirate");
            }
            else if (enemyType == EnemyType.Mayan)
            {
                AudioMaster.instance.PlayEvent("enemySkeletonDeath");
                AudioMaster.instance.PlayEvent("rewardKillMayan");
            }
            else if (enemyType == EnemyType.Spaceman)
            {
                AudioMaster.instance.PlayEvent("enemyBlobDeath");
                AudioMaster.instance.PlayEvent("rewardKillSpaceman");
            }

            // Die
            if (GameObject.FindObjectOfType<Player>().state.form == enemyType)
            {
                Animator enemyAnimator = this.gameObject.GetComponentInChildren<Animator>();
                enemyAnimator.SetTrigger("Death");

                test = true;
            }
            DestroySelf();
            pointsGiven = true;
        }
    }

    public void AssignEnemyType(int _lane, EnemyType _type)
    {
        lane = _lane;
        enemyType = _type;
        EnemyManager.instance.AddEnemyToLane(lane, gameObject);
    }

    public bool IsTargetable()
    {
        return targetable;
    }

    public void SetTargetable(bool targetable)
    {
        this.targetable = targetable;
    }

    public bool getPointsGiven()
    {
        return pointsGiven;
    }
}
