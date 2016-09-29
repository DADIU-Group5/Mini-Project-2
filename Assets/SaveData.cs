using UnityEngine;
using System.Collections;
using Mini2.Utils;

public class SaveData : Singleton<SaveData> {

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(gameObject);
	}

    public bool BeenPlayed(int level)
    {
        return PlayerPrefs.HasKey("LevelStars" + level);
    }
	
	public int GetStarsForLevel(int level)
    {
        Debug.Log(PlayerPrefs.GetInt("LevelStars" + level) + " Stars gotten from level: " + level);
        return PlayerPrefs.GetInt("LevelStars" + level);
    }

    public void SaveStarsForLevel(int level, int stars)
    {
        if (PlayerPrefs.GetInt("LevelStars" + level) > stars)
        {
            PlayerPrefs.SetInt("LevelStars" + level, stars);
        }
    }

    public void SaveStarsForCurrentLevel(int stars)
    {
        if (PlayerPrefs.GetInt("LevelStars" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex) < stars)
        {
            PlayerPrefs.SetInt("LevelStars" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex, stars);
        }
    }

    public void CompletedCurrentLevel()
    {
        PlayerPrefs.SetInt("LevelStars" + (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex+1), 0);
    }

    public bool IsLanguageEnglish()
    {
        if(PlayerPrefs.GetInt("English") == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeLanguage()
    {
        if(PlayerPrefs.GetInt("English") == 0)
        {
            PlayerPrefs.SetInt("English", 1);
        }
        else
        {
            PlayerPrefs.SetInt("English", 0);
        }
    }
}
