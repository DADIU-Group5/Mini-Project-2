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

    public GameObject pirateModel;
    public GameObject mayanModel;
    public GameObject spacemanModel;

    private Animator playerAnimatorPirate;
    private Animator playerAnimatorMayan;
    private Animator playerAnimatorSpaceman;

    void Start()
    {
        playerAnimatorPirate = pirateModel.GetComponent<Animator>();
        playerAnimatorMayan = mayanModel.GetComponent<Animator>();
        playerAnimatorSpaceman = spacemanModel.GetComponent<Animator>();

        ChangeForm();
        jumpStartTime = -jumpTime;
    }

    void Update()
    {
        // Perform jump.
        if (jumpStartTime + jumpTime >= Time.timeSinceLevelLoad && jumpStartTime + jumpTime != 0)
        {
            //trigger jump
            if (state.form == 0)
            {
                playerAnimatorPirate.SetBool("Jump", true);
            }
            else if ((int)state.form == 1)
            {
                playerAnimatorMayan.SetBool("Jump", true);
            }
            else if ((int)state.form == 2)
            {
                playerAnimatorSpaceman.SetBool("Jump", true);
            }

            float t = (Time.timeSinceLevelLoad - jumpStartTime) / jumpTime;

            Vector3 pos = transform.position;
            transform.position = new Vector3(pos.x, Mathf.Lerp(groundHeight, jumpHeight, (t - t * t) * 4), pos.z);
        }
        else
        {
            //stop jump anim
            if (state.form == 0)
            {
                playerAnimatorPirate.SetBool("Jump", false);
            }
            else if ((int)state.form == 1)
            {
                playerAnimatorMayan.SetBool("Jump", false);
            }
            else if ((int)state.form == 2)
            {
                playerAnimatorSpaceman.SetBool("Jump", false);
            }

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

        switch (state.form)
        {
            case EnemyType.Mayan:
                AudioMaster.instance.PlayEvent("switchMayan");
                pirateModel.SetActive(true);
                mayanModel.SetActive(false);
                spacemanModel.SetActive(false);
                break;
            case EnemyType.Pirate:
                AudioMaster.instance.PlayEvent("switchPirate");
                pirateModel.SetActive(false);
                mayanModel.SetActive(true);
                spacemanModel.SetActive(false);
                break;
            case EnemyType.Spaceman:
                AudioMaster.instance.PlayEvent("switchSpaceman");
                pirateModel.SetActive(false);
                mayanModel.SetActive(false);
                spacemanModel.SetActive(true);
                break;
        }
    }

    public void Jump()
    {
        jumpStartTime = Time.timeSinceLevelLoad;
        AudioMaster.instance.PlayEvent("obstacleJump");
    }

    public void Attack()
    {
        if (state.form == 0)
        {
            playerAnimatorPirate.SetTrigger("pirateAttack");
        }
        else if ((int)state.form == 1)
        {
            playerAnimatorMayan.SetTrigger("mayanAttack");
        }
        else if ((int)state.form == 2)
        {
            playerAnimatorSpaceman.SetTrigger("spacemanAttack");
        }
    }
}
