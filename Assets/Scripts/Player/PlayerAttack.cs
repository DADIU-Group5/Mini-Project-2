using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    public Player player;
    public float attackRange = 1.5f;
    private int lane;
    EnemyManager enemyManager;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        lane = player.state.lane;
        AttackEnemy();
        AttackObstacle();
	}

    void AttackEnemy()
    {
        Enemy en = EnemyManager.instance.GetEnemyInLaneWithinDist(attackRange, lane);
        if(en == null)
        {
            return;
        }
        if (en.enemyType == player.state.form)
        {
            en.DestroyedByPlayer();
        }
    }

    void AttackObstacle()
    {
        Obstacle ob = Obstacles.instance.GetNearestObstacleCloserThan(attackRange);
        if(ob == null)
        {
            return;
        }

        //If the player is strong against this obstacle type:
        if (ob.weakAgainst == player.state.form)
        {
            ob.PlayerInteraction();
        } /*else if (ob.weakAgainst != player.state.form)
        {
            ob.PlayerInteraction(); // we should be doing something else here.
        }*/
    }
}
