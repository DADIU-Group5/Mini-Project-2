using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Mini2.Menu;

public class LevelLoader : MonoBehaviour {

    public Button mayan;
    public Button space;


    public int pirateLevels = 0;

    public int mayanLevels = 0;

    public int spaceLevels = 0;

    void Start()
    {
        if (SaveData.instance.WasLevelCompleted("Pirate" + pirateLevels))
        {
            mayan.interactable = true;
        }
        if (SaveData.instance.WasLevelCompleted("Mayan" + mayanLevels))
        {
            space.interactable = true;
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
