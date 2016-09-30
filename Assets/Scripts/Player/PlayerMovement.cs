using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private PlayerState playerState;

    void Start()
    {
        playerState = GetComponent<Player>().state;
    }

    public void SwipeUp()
    {
        print("up");
        if (playerState.lane < 2)
        {
            MoveUp();
        }
    }

    public void SwipeDown()
    {
        if (playerState.lane > 0)
        {
            MoveDown();
        }
    }

    public void MoveUp()
    {
        playerState.lane++;
        transform.Translate(0, 0, EnemySpawner.instance.GetLaneWidth());
        /*float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);*/
    }

    public void MoveDown()
    {
        playerState.lane--;
        transform.Translate(0, 0, -EnemySpawner.instance.GetLaneWidth());

    }
}
