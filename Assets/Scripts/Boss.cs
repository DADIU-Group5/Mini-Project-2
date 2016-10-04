using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour
{
    [Tooltip("The maxmum distance the boss can move either direction")]
    public Vector2 area = new Vector2(0.3f, 3f);
    [Tooltip("The time in seconds between each time the boss moves towards a new point")]
    [Range(0, 1)]
    public float unrest = 0.75f;
    [Tooltip("Determines the speed at which the boss will move to a new point")]
    [Range(0, 5)]
    public float speed = 3f;

    private float timePassed;
    private Vector3 startPos;
    private Vector3 target;
    private Vector3 velocity;


    void Start()
    {
        startPos = transform.position;
        NewTargetPos();
        velocity = Vector3.zero;
    }

    void Update ()
    {
        timePassed += Time.deltaTime;
        if (timePassed > unrest)
        {
            NewTargetPos();
        }

        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        velocity = (target - transform.position).normalized * speed / 100;
        transform.position += velocity;
        if (Vector3.Distance(target, transform.position) < 0.5f)
        {
            NewTargetPos();
        }
    }

    // randoms a new position within the area
    private void NewTargetPos()
    {
        float dx = Random.Range(-area.x, area.x);
        float dz = Random.Range(-area.y, area.y);
        target = startPos + new Vector3(dx, 0, dz);
        timePassed = 0;
    }
}
