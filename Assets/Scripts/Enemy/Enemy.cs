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
        Destroy(this.gameObject);
    }

    public void DestroyedByPlayer()
    {
        ScoreManager.instance.ModifyPoint(1 * this.gameObject.GetComponent<Enemy>().enemyPoints);
        DestroySelf();
    }

    public void AssignEnemyType(int _lane, EnemyType _type)
    {
        lane = _lane;
        enemyType = _type;
        EnemyManager.instance.AddEnemyToLane(lane, gameObject);
    }
}
