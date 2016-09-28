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
    public PlayerState state;
    public GameObject formCube;
    public ScoreManager scoreManager;

    void Start()
    {
        ChangeForm();
        scoreManager = GetComponent<ScoreManager>();
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
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.black;
        }
        else if ((int)state.form == 1)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else if ((int)state.form == 2)
        {
            formCube.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}
