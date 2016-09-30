using UnityEngine;
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
            this.GetComponentInChildren<Animation>().Play();
        }
        else if (weakAgainst == EnemyType.Mayan)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesMayan");
            this.GetComponentInChildren<Animation>().Play();
        }
        else if (weakAgainst == EnemyType.Spaceman)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesSpaceman");
            //this.GetComponentInChildren<Animation>().Play();
        }
        RemoveObstacle();
    }

}