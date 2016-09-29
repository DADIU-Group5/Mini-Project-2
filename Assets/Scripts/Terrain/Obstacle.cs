using UnityEngine;
using System.Collections;

public class Obstacle : TerrainMovement {

    public bool hitByPlayer = false; // Whether the player has reached this enemy yet.
    public EnemyType weakAgainst;
    public GameObject obstacleModel;

    void Start()
    {
        Obstacles.instance.AddObstacle(this);
    }

    public override void Remove()
    {
        Obstacles.instance.RemoveObstacle(this);
        Destroy(gameObject);
    }

    void RemoveObstacle()
    {
        Destroy(obstacleModel);
    }

    public void PlayerInteraction()
    {
        ScoreManager.instance.ModifyPoint(1); //Needs to be better.
        RemoveObstacle();
    }

}