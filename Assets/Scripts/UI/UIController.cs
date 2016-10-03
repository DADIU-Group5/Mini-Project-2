﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Mini2.Utils;

public class UIController : Singleton<UIController> {

    public GameObject endPanel;
    public Text scoreT;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;
    public GameObject star4;
    public GameObject star5;
    GameObject[] starImages;

    public Text levelEndText;
    public Text MainMenuText;
    public Text RetryText;
    public Text NextLevelText;
    public GameObject NextLevelButton;
    public PlayerState state;
    public EnemyType currentForm;

    void Start()
    {
        starImages = new GameObject[5];
        starImages[0] = star1;
        starImages[1] = star2;
        starImages[2] = star3;
        starImages[3] = star4;
        starImages[4] = star5;
        starImages[1].gameObject.GetComponent<Image>().color = Color.clear;
        DisableStars();
        UpdateLanguage();
    }

    public void SwitchCharacters()
    {
        //remember order. current form in middle.
    }

    public void ShowEndScreen()
    {
        StopAllTerrain();
        GameObject.FindObjectOfType<InputManager>().SetWaitingForInput(null, waitForSpecificSwipe.all);
        scoreT.text = "Score: "+ScoreManager.instance.score;
        AudioMaster.instance.PlayEvent("musicStop");
        AudioMaster.instance.PlayEvent("levelEnd");
        endPanel.SetActive(true);
        StarSystem.instance.CalculateScore();
        int stars = StarSystem.instance.starRating;
        if (stars == 3)
        {
            for (int i = 0; i < 3; i++)
            {
                starImages[i].gameObject.GetComponent<Image>().enabled = true;
            }
        }
        else if (stars == 1)
        {
            starImages[1].gameObject.GetComponent<Image>().enabled = true;
        }
        else if (stars == 2)
        {
            starImages[3].gameObject.GetComponent<Image>().enabled = true;
            starImages[4].gameObject.GetComponent<Image>().enabled = true;
        }
        else if (stars < 0)
        {
            starImages[1].gameObject.GetComponent<Image>().enabled = true;
            starImages[1].gameObject.GetComponent<Image>().color = Color.red;
        }
        
        SaveData.instance.CompletedCurrentLevel();
        SaveData.instance.SaveStarsForCurrentLevel(stars);
    }

    void StopAllTerrain()
    {
        GameObject.FindObjectOfType<TerrainGenerator>().PauseAllMovement();
    }

    void UpdateLanguage()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            levelEndText.text = "Level finished!";
            MainMenuText.text = "Main Menu";
            RetryText.text = "Retry!";
            NextLevelText.text = "Next level";
        }
        else
        {
            levelEndText.text = "Niveau færdig";
            MainMenuText.text = "Hoved menu";
            RetryText.text = "Prøv igen";
            NextLevelText.text = "Næste niveau";
        }
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-2)
        {
            NextLevelButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        DisableStars();
        PlayerPrefs.SetInt("PlayedBefore", 2);
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        DisableStars();
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RetryLevel()
    {
        DisableStars();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DisableStars()
    {
        //disable the image component of all the star images
        for (int i = 0; i < starImages.Length; i++)
        {
            Debug.Log("Disable stars!");
            starImages[i].GetComponent<Image>().enabled = false;
        }
    }
}