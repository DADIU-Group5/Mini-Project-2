using UnityEngine;
using System.Collections;
using Mini2.Utils;
using UnityEngine.UI;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0;
    public Text scoreLabel;

    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
    }


    public void ModifyPoint(int point)
    {
        score += point;
        scoreLabel.text = "Score: " + score;
    }
}
