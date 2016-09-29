using UnityEngine;
using System.Collections;
using Mini2.Utils;

public class ScoreManager : Singleton<ScoreManager>
{
    public int score = 0;

    public void ModifyPoint(int point)
    {
        score += point;
    }
}
