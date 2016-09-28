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

    public void DestroySelf()
    {
        EnemyManager.instance.RemoveEnemyFromLane(lane);
        Destroy(this.gameObject);
    }

    public void AssignEnemyType(int _lane, EnemyType _type)
    {
        lane = _lane;
        enemyType = _type;
        EnemyManager.instance.AddEnemyToLane(lane, gameObject);
    }
}
