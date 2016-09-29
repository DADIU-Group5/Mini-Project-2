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

    public GameObject pirateModel;
    public GameObject mayanModel;
    public GameObject spacemanModel;

    private Animator playerAnimator;

    void Start()
    {
        playerAnimator = this.GetComponentInChildren<Animator>();

        ChangeForm();
        jumpStartTime = -jumpTime;
    }

    void Update()
    {
        // Perform jump.
        if (jumpStartTime + jumpTime >= Time.timeSinceLevelLoad && jumpStartTime + jumpTime != 0)
        {
            //playerAnimator.SetTrigger("Jump");
            playerAnimator.SetBool("Jump", true);
            float t = (Time.timeSinceLevelLoad - jumpStartTime) / jumpTime;

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, Mathf.Lerp(groundHeight, jumpHeight, (t - t * t) * 4), pos.z);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
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
        Debug.Log("Changing form");

        
        if (state.form == 0)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.red;
            pirateModel.SetActive(true);
            mayanModel.SetActive(false);
            spacemanModel.SetActive(false);
        }
        else if ((int)state.form == 1)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.green;
            pirateModel.SetActive(false);
            mayanModel.SetActive(true);
            spacemanModel.SetActive(false);
        }
        else if ((int)state.form == 2)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.blue;
            pirateModel.SetActive(false);
            mayanModel.SetActive(false);
            spacemanModel.SetActive(true);
        }
    }

    public void Jump()
    {
        jumpStartTime = Time.timeSinceLevelLoad;
    }

}
