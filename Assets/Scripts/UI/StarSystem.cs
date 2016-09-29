using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mini2.Utils;

public class StarSystem : Singleton<StarSystem> {

    public int maxPointsAvailable = 0;
    [HideInInspector]
    public int starRating = 0;
    [Header("At which percentages a star is achieved:")]
    public float oneStarAt = 50;
    public float twoStarsAt = 75;
    public float threeStarsAt = 100;

    // Use this for initialization
    void Start () {
	    
	}

    public void CalculateScore()
    {
        float percentage = (((float)ScoreManager.instance.score / (float)maxPointsAvailable) * 100);
        if (Mathf.Abs(percentage) >= threeStarsAt)
        {
            starRating = 3;
        } else if (Mathf.Abs(percentage) >= twoStarsAt)
        {
            starRating = 2;
        } else if (Mathf.Abs(percentage) >= oneStarAt)
        {
            starRating = 1;
        }

        //if the percentage is negative, the stars are negative.
        // only show one red star.
        if (percentage < 0)
        {
            starRating = -1;
            
        }
    }

}
