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
            switch(player.state.form)
            {
                case EnemyType.Mayan:
                    AudioMaster.instance.PlayEvent("maskAttack");
                    break;
                case EnemyType.Pirate:
                    AudioMaster.instance.PlayEvent("swordAttack");
                    break;
                case EnemyType.Spaceman:
                    AudioMaster.instance.PlayEvent("laserAttack");
                    break;
            }
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
            switch (player.state.form)
            {
                case EnemyType.Mayan:
                    AudioMaster.instance.PlayEvent("obstacleSuccesMayan");
                    break;
                case EnemyType.Pirate:
                    AudioMaster.instance.PlayEvent("obstacleSuccesPirate");
                    break;
                case EnemyType.Spaceman:
                    AudioMaster.instance.PlayEvent("obstacleSuccesSpaceman");
                    break;
            }
            AudioMaster.instance.PlayEvent("rewardObstacle");
        }
        else
        {
            // Jumps over obstacle
            AudioMaster.instance.PlayEvent("obstacleJump");
        }
        /*else if (ob.weakAgainst != player.state.form)
        {
            ob.PlayerInteraction(); // we should be doing something else here.
        }*/
    }
}
