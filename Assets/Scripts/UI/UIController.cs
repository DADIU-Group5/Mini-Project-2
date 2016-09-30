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
        DisableStars();
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
            float range = Mathf.Abs (star3.transform.position.x+2) - Mathf.Abs (star1.transform.position.x+2);
            Debug.Log("the range is: " + range + " with star 1 at : " + star1.transform.position.x + " with star 3 at : " + star3.transform.position.x);
            
            for (int i = 0; i < Mathf.Abs(stars); i++)
            {
                float point = (range / (stars+1)) * (i + 1);
                Debug.Log(range + " / " + (stars + 1) + " * " + (i + 1) + " = " + point);
                starImages[i].gameObject.GetComponent<Image>().enabled = true;
                if (stars < 0)
                {
                    starImages[i].gameObject.GetComponent<Image>().color = Color.red;
                }
                starImages[i].transform.position = new Vector3(star1.transform.position.x + point, starImages[i].transform.position.y, starImages[i].transform.position.z);
                Debug.Log("Star " + (i+1) + " at star1.transform.position.x + point: " + (star1.transform.position.x + point));
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
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-2)
        {
            NextLevelButton.SetActive(false);
        }
    }

    public void MainMenu()
    {
        DisableStars();
        SceneManager.LoadScene(0);
    }

    public void NextLevel()
    {
        DisableStars();
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings-2)
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
        star1.GetComponent<Image>().enabled = false;
        star2.GetComponent<Image>().enabled = false;
        star3.GetComponent<Image>().enabled = false;
    }
}