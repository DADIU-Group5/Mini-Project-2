using UnityEngine;
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


    void Start()
    {
        starImages = new GameObject[5];
        starImages[0] = star1;
        starImages[1] = star2;
        starImages[2] = star3;
        starImages[3] = star4;
        starImages[4] = star5;
        starImages[1].gameObject.GetComponent<Image>().color = star2.gameObject.GetComponent<Image>().color;
        DisableStars();
        UpdateLanguage();
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
        Time.timeScale = 1;
        char c = SceneManager.GetActiveScene().name[0];
        if (c == 'P')
        {
            PlayerPrefs.SetInt("PlayedBefore", 4);
        }
        else if (c == 'M')
        {
            PlayerPrefs.SetInt("PlayedBefore", 5);
        }
        else if(c == 'S')
        {
            PlayerPrefs.SetInt("PlayedBefore", 6);
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        DisableStars();
        Time.timeScale = 1;
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-3)
        {
            SceneManager.LoadScene("MainMenu");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void RetryLevel()
    {
        DisableStars();
        Time.timeScale = 1;
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