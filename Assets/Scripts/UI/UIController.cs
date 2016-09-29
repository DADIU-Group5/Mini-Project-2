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
    GameObject[] starImages;

    public Text levelEndText;
    public Text MainMenuText;
    public Text RetryText;
    public Text NextLevelText;
    public GameObject NextLevelButton;


    void Start()
    {
        starImages = new GameObject[3];
        //disable the image component of all the star images
        star1.GetComponent<Image>().enabled = false;
        star2.GetComponent<Image>().enabled = false;
        star3.GetComponent<Image>().enabled = false;
        starImages[0] = star1;
        starImages[1] = star2;
        starImages[2] = star3;
        UpdateLanguage();
    }

    public void ShowEndScreen()
    {
        StopAllTerrain();
        scoreT.text = "Score: "+ScoreManager.instance.score;
        AudioMaster.instance.PlayEvent("levelEnd");
        endPanel.SetActive(true);
        StarSystem.instance.CalculateScore();
        int stars = StarSystem.instance.starRating;
        if (stars != 0) {
            for (int i = 0; i < Mathf.Abs(stars); i++)
            {
                starImages[i].gameObject.GetComponent<Image>().enabled = true;
                if (stars < 0)
                {
                    starImages[i].gameObject.GetComponent<Image>().color = Color.red;
                }
            }
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
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
        {
            NextLevelButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-1)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}