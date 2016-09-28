using UnityEngine;
using System.Collections;

public class Obstacle : TerrainMovement {

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
        RemoveObstacle();
    }

}