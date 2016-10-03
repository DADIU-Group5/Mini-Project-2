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
        Enemy enemy = EnemyManager.instance.GetEnemyInLaneWithinDist(attackRange, lane);
        if(enemy == null || enemy.hitByPlayer)
        {
            return;
        }
        if (enemy.enemyType == player.state.form && !enemy.getPointsGiven())
        {
            enemy.hitByPlayer = true;
            enemy.DestroyedByPlayer();
            player.Attack();
        }
        else if (!enemy.hitByPlayer)
        {
            // Jump
            enemy.hitByPlayer = true;
            player.Jump();
            Debug.Log("Yeeaaa 2");
        }
    }

    void AttackObstacle()
    {
        Obstacle ob = Obstacles.instance.GetNearestObstacleCloserThan(attackRange);
        if(ob == null || ob.hitByPlayer)
        {
            return;
        }

        //If the player is strong against this obstacle type:
        if (ob.weakAgainst == player.state.form && !ob.hitByPlayer)
        {
            ob.hitByPlayer = true;
            ob.PlayerInteraction();
            player.Attack();
        }
        else if (!ob.hitByPlayer)
        {
            // Jump
            ob.hitByPlayer = true;
            player.Jump();
            Debug.Log("Yeeaaa");
        }
    }
}
