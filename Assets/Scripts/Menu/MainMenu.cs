using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject basicButton;

    public Text playText;
    public Text changeLanguageText;
    public Text backButton;

    public GameObject main;
    public GameObject levels;
    GameObject[] levelButtons;

    int amountOfLevels = 3;

	// Use this for initialization
	void Start () {
        levelButtons = new GameObject[SceneManager.sceneCountInBuildSettings];
        if(SaveData.instance.BeenPlayed(1) == false)
        {
            SaveData.instance.SaveStarsForLevel(1, -1);
        }
        UpdateMainMenuText();
	}

    public void ShowLevels()
    {
        amountOfLevels = SceneManager.sceneCountInBuildSettings-1;
        for (int i = 1; i < amountOfLevels; i++)
        {
            GameObject GO = Instantiate(basicButton, transform) as GameObject;
           // GO.GetComponent<MainMenuButton>().Setup(i, this);
            levelButtons[i - 1] = GO;
        }
    }

    public void Play()
    {
        main.SetActive(false);
        ShowLevels();
    }

    public void ChangeLanguage()
    {
        SaveData.instance.ChangeLanguage();
        UpdateMainMenuText();
    }

    public void UpdateMainMenuText()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            playText.text = "Play!";
            changeLanguageText.text = "Change Language";
            backButton.text = "Back";
        }
        else
        {
            playText.text = "Spil!";
            changeLanguageText.text = "Skift Sprog";
            backButton.text = "Tilbage";
        }
    }
	
	public void LoadLevel(int i)
    {
        if (i == 1)
        {
            SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
        }
        else
        {
            SceneManager.LoadScene(i);
        }
    }

    public void ReturnToMainMenu()
    {
        DestroyAllLevelButtons();
        main.SetActive(true);
    }

    void DestroyAllLevelButtons()
    {
        for (int i = 0; i < levelButtons.Length; i++)
        {
            Destroy(levelButtons[i]);
        }
    }

    public void RESET()
    {
        PlayerPrefs.DeleteAll();
        SaveData.instance.SaveStarsForLevel(1, -1);
        UpdateMainMenuText();
    }
}
