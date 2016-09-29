﻿using UnityEngine;
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
        if(en == null || en.hitByPlayer)
        {
            return;
        }

        // if is correct enemy type
        if (en.enemyType == player.state.form)
        {
            en.DestroyedByPlayer();
            switch (player.state.form)
            {
                case EnemyType.Pirate:
                    AudioMaster.instance.PlayEvent("swordAttack");
                    break;
                case EnemyType.Mayan:
                    AudioMaster.instance.PlayEvent("maskAttack");
                    break;
                case EnemyType.Spaceman:
                    AudioMaster.instance.PlayEvent("laserAttack");
                    break;
            }

        }
        else if (!en.hitByPlayer)
        {
            // Jump
            en.hitByPlayer = true;
            player.Jump();
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
        if (ob.weakAgainst == player.state.form)
        {
            ob.PlayerInteraction();
            AudioMaster.instance.PlayEvent("rewardObstacle");
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
