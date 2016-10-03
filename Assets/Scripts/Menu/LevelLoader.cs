using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Mini2.Menu;

public class LevelLoader : MonoBehaviour {

    public Button mayan;
    public Button space;

    [HideInInspector]
    public int pirateLevels = 0;
    [HideInInspector]
    public int mayanLevels = 0;
    [HideInInspector]
    public int spaceLevels = 0;

    void Start()
    {
        GetAmountOfEachLevelType();
        if (SaveData.instance.WasLevelCompleted("Pirate" + pirateLevels))
        {
            mayan.interactable = true;
        }
        if (SaveData.instance.WasLevelCompleted("Mayan" + mayanLevels))
        {
            space.interactable = true;
        }
    }

    void GetAmountOfEachLevelType()
    {
        int temp = SceneManager.sceneCount;
        string c;
        for (int i = 0; i < temp; i++)
        {
            c = SceneManager.GetSceneAt(i).name;
            c = c.Substring(0, 3);
            if(c == "Pir")
            {
                pirateLevels++;
            }
            if (c == "May")
            {
                mayanLevels++;
            }
            if (c == "Spa")
            {
                spaceLevels++;
            }
        }
    }

    public void Reset()
    {
        mayan.interactable = false;
        space.interactable = false;
    }

    public void LoadLevel(string levelName)
    {
        if (levelName == "Pirate1")
        {
            SceneManager.LoadScene("Intro");
        }
        else
        {
            SceneManager.LoadScene(levelName);
        }
    }
}
