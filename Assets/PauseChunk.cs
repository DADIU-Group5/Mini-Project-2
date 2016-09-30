using UnityEngine;
using System.Collections;

public class PauseChunk : TerrainMovement {

    public GameObject pauseUI;

    public string danishText;
    public string englishText;
    public waitForSpecificSwipe stopMethod;

    public override void Remove()
    {
        if (!SaveData.instance.ShowTutorial())
        {
            base.Remove();
            return;
        }
        GameObject.FindObjectOfType<TerrainGenerator>().PauseAllMovement();
        GameObject go = Instantiate(pauseUI) as GameObject;
        if (SaveData.instance.IsLanguageEnglish())
        {
            go.GetComponent<TutorialUI>().Setup(englishText,stopMethod);
        }
        else
        {
            go.GetComponent<TutorialUI>().Setup(danishText,stopMethod);
        }
        base.Remove();
    }
}

public enum waitForSpecificSwipe
{
    none, swipeDown, swipeUp, swipeLeft, swipeRight
}