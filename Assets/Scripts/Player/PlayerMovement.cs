using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    [Tooltip("Time the sliding between lanes takes.")]
    [Range(0.0f, 1.0f)]
    public float slidingSpeed = 0.1f;

    private PlayerState playerState;
    private Vector3 endPosition;
    private Vector3 startPosition;
    private float slideStart;
    private float slideEnd;
    private float fraction;
    private float deltaTime;

    private bool sliding = true;

    public void Update()
    {
        if (sliding)
        {
            deltaTime += Time.deltaTime;
            fraction = (deltaTime - slideStart) / (slideEnd - slideStart);
            transform.position = Vector3.Lerp(startPosition, endPosition, fraction);
            if (fraction == 1)
            {
                sliding = false;
            }
        }
    }

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

        // Set up variables for lerping between lanes
        if (sliding)
        {
            transform.position = endPosition;
        }
        sliding = true;
        slideStart = 0;
        deltaTime = 0;
        slideEnd = slidingSpeed;
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, 0, 1) * EnemySpawner.instance.GetLaneWidth();
    }

    public void MoveDown()
    {
        playerState.lane--;

        // Set up variables for lerping between lanes
        if (sliding)
        {
            transform.position = endPosition;
        }
        sliding = true;
        slideStart = 0;
        deltaTime = 0;
        slideEnd = slidingSpeed;
        startPosition = transform.position;
        endPosition = transform.position + new Vector3(0, 0, -1) * EnemySpawner.instance.GetLaneWidth();
    }
}
