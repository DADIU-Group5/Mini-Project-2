using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [Tooltip("Multiplier for length of movement in relation to lane size")]
    [Range(0f, 1f)]
    public float bossMoveMultiplier = 0.5f;
    [Tooltip("Multiplier for length of movement in relation to lane size")]
    [Range(0f, 10.0f)]
    public float bossMoveTimer = 2.0f;

    private float laneWidth = 3.0f;
    private int currentLane = 1;
    private int newLane = 1;
    private float nextMove = 2.0f;
    private float bossMoveWidth = 0f;

    void Start()
    {
        //laneWidth from somewhere
        //laneWidth = ;
        bossMoveWidth = laneWidth * bossMoveMultiplier;
    }

    void Update ()
    {
        if (nextMove <= Time.timeSinceLevelLoad)
        {
            MoveBoss();
        }
    }

    public void MoveBoss()
    {
        nextMove = Time.timeSinceLevelLoad + bossMoveTimer;
        if (currentLane == newLane)
        {
            int random = Random.Range(1, 3);
            newLane = (currentLane + random) % 3;
        }
        SetBossPosition(currentLane, newLane);
        currentLane = newLane;
    }

    private void SetBossPosition(int _newLane, int _currentLane)
    {
        int jumps = _newLane - _currentLane;
        Vector3 tempPosition = new Vector3(0, 0, jumps * bossMoveWidth);
        this.gameObject.transform.position += tempPosition;
    }
}
