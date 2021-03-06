﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using Mini2.Utils;

public class SaveData : Singleton<SaveData> {

	// Use this for initialization
	void Start () {
        PlayerPrefs.SetInt("Completed" + "Pirate0", 1);
    }

    public bool BeenPlayed(int level)
    {
        Debug.LogError("Use the string version instead!");
        return PlayerPrefs.HasKey("LevelStars" + level);
    }

    public bool BeenPlayed(string level)
    {
        return PlayerPrefs.HasKey(level);
    }

    public int GetStarsForLevel(int level)
    {
        Debug.LogError("Use the string version instead!");
        return PlayerPrefs.GetInt("LevelStars" + level);
    }

    public int GetStarsForLevel(string level)
    {
        return PlayerPrefs.GetInt(level);
    }

    public void SaveStarsForLevel(int level, int stars)
    {
        Debug.LogError("Use the string version instead!");
        if (PlayerPrefs.GetInt("LevelStars" + level) > stars)
        {
            PlayerPrefs.SetInt("LevelStars" + level, stars);
        }
    }

    public void SaveStarsForLevel(string level, int stars)
    {
        Debug.Log("Saves stars!");
        if (PlayerPrefs.GetInt(level) > stars)
        {
            int extraStars = 0;
            extraStars = stars - PlayerPrefs.GetInt("LevelStars" + level);
            Debug.Log("extra stars " + extraStars);
            AddToTotalEarnedStars(extraStars);
            PlayerPrefs.SetInt(level, stars);
        }
    }

    public void SaveStarsForCurrentLevel(int stars)
    {
        if (PlayerPrefs.GetInt(SceneManager.GetActiveScene().name) < stars)
        {
            int extraStars = 0;
            extraStars = stars - PlayerPrefs.GetInt(SceneManager.GetActiveScene().name);
            //Debug.Log("extra stars " + extraStars);
            AddToTotalEarnedStars(extraStars);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, stars);
        }
    }

    public void CompletedCurrentLevel()
    {
        PlayerPrefs.SetInt("Completed"+SceneManager.GetActiveScene().name, 1);
    }

    public bool WasLevelCompleted(string level)
    {
        return PlayerPrefs.HasKey("Completed" + level);
    }

    public void RESETALL()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Completed" + "Pirate0", 1);
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

    public void SetTutorailState(int i)
    {
        PlayerPrefs.SetInt("Tutorial", i);
    }

    public bool ShowTutorial()
    {
        if(PlayerPrefs.GetInt("Tutorial") == 1)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void AddToTotalEarnedStars(int extra)
    {
        PlayerPrefs.SetInt("TotalStarsEarned", (PlayerPrefs.GetInt("TotalStarsEarned") + extra));
    }

    public int GetAllEarnedStars()
    {
        return PlayerPrefs.GetInt("TotalStarsEarned");
    }

    public int GetAllPossibleStars()
    {
        return 9;//PlayerPrefs.GetInt("TOTALSTARS");
    }
}
