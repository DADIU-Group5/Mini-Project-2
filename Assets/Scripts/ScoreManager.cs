using UnityEngine;
using System.Collections;
using Mini2.Utils;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0;
    public Text scoreLabel;

    [Header("Points awarded for overcoming enemies and obstacles:")]
    public int enemyPoints = 1;
    public int obstaclePoints = 1;

    [Header("Points taken for missing enemies and obstacles:")]
    public int missObstaclePoints = -1;
    public int missEnemyPoints = -1;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
    }

    public void ModifyPoint(int collisionType, bool give)
    { // 0: enemy   1: obstacle
        int point = 1;
        if (collisionType == 0)
        {
            if (give)
            {
                point = enemyPoints;
                AudioMaster.instance.PlayEvent("rewardKillPirate");
            }
            else
            {
                point = missEnemyPoints;
            }
        }
        else if (collisionType == 1)
        {
            if (give)
            {
                point = obstaclePoints;
                AudioMaster.instance.PlayEvent("rewardObstaclePirate");
            } else
            {
                point = missObstaclePoints;
            }
        }

        if (!give) //If points are LOST, play sound:
        {
            AudioMaster.instance.PlayEvent("pointLoss");
        }

        score += point;
        scoreLabel.text = "Score: " + score;
    }
}
