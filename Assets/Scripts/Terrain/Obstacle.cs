﻿using UnityEngine;
using System.Collections;

public class Obstacle : TerrainMovement {

    public bool hitByPlayer = false; // Whether the player has reached this enemy yet.
    public EnemyType weakAgainst;
    public GameObject obstacleModel;
    bool beaten = false;

    void Start()
    {
        Obstacles.instance.AddObstacle(this);
    }

    public override void Remove() //miss obstacle
    {
        Obstacles.instance.RemoveObstacle(this);
        //ScoreManager.instance.ModifyPoint(1, false);
        Destroy(gameObject);
    }

    void RemoveObstacle()
    {
        beaten = true;
        Destroy(obstacleModel);
    }

    public void PlayerInteraction()
    {
        if (beaten)
        {
            return;
        }
        ScoreManager.instance.ModifyPoint(1, true);
        if (weakAgainst == EnemyType.Pirate)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesPirate");
            AudioMaster.instance.PlayEvent("rewardObstaclePirate");
        }
        else if (weakAgainst == EnemyType.Mayan)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesMayan");
            AudioMaster.instance.PlayEvent("rewardObstacleMayan");
        }
        else if (weakAgainst == EnemyType.Spaceman)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesSpaceman");
            AudioMaster.instance.PlayEvent("rewardObstacleSpaceman");
        }
        RemoveObstacle();
    }

}