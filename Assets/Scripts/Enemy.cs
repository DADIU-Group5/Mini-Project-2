using UnityEngine;
using System.Collections;

public enum EnemyType
{
    Pirate, Mayan, Spaceman
}

public class Enemy : MonoBehaviour
{
    public int lane;
    public EnemyType enemyType;
    [Range(1, 10f)]
    [Tooltip("Score points gained/lost from enemy")]
    public int enemyPoints = 1;

    public void DestroySelf()
    {
        EnemyManager.instance.RemoveEnemyFromLane(lane);
        ScoreManager.instance.ModifyPoint(enemyPoints);
        Destroy(this.gameObject);
    }

    public void AssignEnemyType()
    {

    }
}
