using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerState
{
    public int lane = 1;
    public EnemyType form = EnemyType.Pirate;
}

public class Player : MonoBehaviour
{
    // Jump values.
    public float jumpTime = 1, jumpHeight = 1, groundHeight = 0;
    private float jumpStartTime = -1;

    public PlayerState state;
    public GameObject formCube;

    void Start()
    {
        ChangeForm();
        jumpStartTime = -jumpTime;
    }

    void Update()
    {
        // Perform jump.
        // Terrible code, please fix.
        if (jumpStartTime + jumpTime >= Time.timeSinceLevelLoad)
        {
            float t = (Time.timeSinceLevelLoad - jumpStartTime) / jumpTime;

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, Mathf.Lerp(groundHeight, jumpHeight, (t - t * t) * 4), pos.z);
        }
        else
        {
            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, 0, pos.z);
        }
    }

    public void SwipeRight()
    {
        if ((int)state.form == 2)
        {
            state.form = 0;

        }
        else
        {
            state.form++;
        }
        ChangeForm();
    }

    public void SwipeLeft()
    {
        if (state.form == 0)
        {
            state.form = (EnemyType)2;
        }
        else
        {
            state.form--;
        }
        ChangeForm();
    }

    public void ChangeForm()
    {
        if (state.form == 0)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else if ((int)state.form == 1)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else if ((int)state.form == 2)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }

    public void Jump()
    {
        jumpStartTime = Time.timeSinceLevelLoad;
    }

}
