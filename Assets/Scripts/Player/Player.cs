using UnityEngine;
using System.Collections;

public enum PlayerForm
{
    Pirate, Mayan, Spaceman
}

[System.Serializable]
public class PlayerState
{
    public int lane = 1;
    public PlayerForm form = PlayerForm.Pirate;
}

public class Player : MonoBehaviour
{
    public PlayerState state;

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

    }

    public void SwipeLeft()
    {
        if (state.form == 0)
        {
            state.form = (PlayerForm)2;

        }
        else
        {
            state.form--;
        }
    }


}
