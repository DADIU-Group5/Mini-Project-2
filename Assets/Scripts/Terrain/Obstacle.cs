using UnityEngine;
using System.Collections;

public class Obstacle : TerrainMovement {

    public bool hitByPlayer = false; // Whether the player has reached this enemy yet.
    public EnemyType weakAgainst;
    public GameObject obstacleModel;
    bool beaten = false;

    private Animator[] mayanAnimators;
    private Animation[] spaceAnimations;

    private Animator obstacleAnimator;

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
            this.GetComponentInChildren<Animation>().Play();
        }
        else if (weakAgainst == EnemyType.Mayan)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesMayan");
            AudioMaster.instance.PlayEvent("rewardObstacleMayan");
            mayanAnimators = GetComponentsInChildren<Animator>();
            foreach (Animator animator in mayanAnimators)
            {
                animator.SetTrigger("Death");
            }
        }
        else if (weakAgainst == EnemyType.Spaceman)
        {
            AudioMaster.instance.PlayEvent("obstacleSuccesSpaceman");
            AudioMaster.instance.PlayEvent("rewardObstacleSpaceman");
            spaceAnimations = GetComponentsInChildren<Animation>();
            foreach (Animation animation in spaceAnimations)
            {
                animation.Play();
            }
                
        }
        RemoveObstacle();
    }

}