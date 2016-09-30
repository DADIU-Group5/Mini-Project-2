using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialUI : MonoBehaviour {

    public Text UItext;

	public void Setup(string t, waitForSpecificSwipe stop)
    {
        UItext.text = t;
        GameObject.FindObjectOfType<InputManager>().SetWaitingForInput(Unpause, stop);
    }

    public void Unpause()
    {
        GameObject.FindObjectOfType<TerrainGenerator>().ResumeAllMovement();
        Destroy(gameObject);
    }
}
