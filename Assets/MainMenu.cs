using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject basicButton;

    public Text playText;
    public Text changeLanguageText;

    public GameObject main;
    public GameObject levels;

    public int amountOfLevels = 3;

	// Use this for initialization
	void Start () {
        if(SaveData.instance.BeenPlayed(1) == false)
        {
            SaveData.instance.SaveStarsForLevel(1, 0);
        }
        ShowLevels();
	}

    public void ShowLevels()
    {
        amountOfLevels = SceneManager.sceneCount;
        for (int i = 0; i < amountOfLevels; i++)
        {
            GameObject GO = Instantiate(basicButton, transform) as GameObject;
            GO.GetComponent<MainMenuButton>().Setup(i + 1, this);
        }
    }

    public void Play()
    {
        main.SetActive(false);
    }

    public void ChangeLanguage()
    {
        SaveData.instance.ChangeLanguage();
        if (SaveData.instance.IsLanguageEnglish())
        {
            playText.text = "Play!";
            changeLanguageText.text = "Change Language";
        }
        else
        {
            playText.text = "Spil!";
            changeLanguageText.text = "Skift Sprog";
        }
    }
	
	public void LoadLevel(int i)
    {
        SceneManager.LoadScene(i);
    }
}
