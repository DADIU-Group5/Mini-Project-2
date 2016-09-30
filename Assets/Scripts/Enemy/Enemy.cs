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
        EnemyManager.instance.RemoveEnemyFromLane(lane);
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
            if (GameObject.FindObjectOfType<Player>().state.form == EnemyType.Mayan)// && enemyType == GameObject.FindObjectOfType<Player>().state.form)//and enemyType == player.enemyType
            {
                Debug.Log("Enabling animator! enemytype: " + enemyType + " and playertype: " + GameObject.FindObjectOfType<Player>().state.form);
                //Enable animator:
                this.gameObject.GetComponentInChildren<Animation>().Play();
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
}
