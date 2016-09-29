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
    }

    public void ShowEndScreen()
    {
        scoreT.text = "Score: "+ScoreManager.instance.score;
        AudioMaster.instance.PlayEvent("levelEnd");
        endPanel.SetActive(true);
        StarSystem.instance.CalculateScore();
        int stars = StarSystem.instance.starRating;
        Debug.Log("stars: " + stars);
        if (stars != 0) {
            for (int i = 0; i < Mathf.Abs(stars)-1; i++)
            {
                starImages[i].gameObject.GetComponent<Image>().enabled = true;
                if (stars < 0)
                {
                    starImages[i].gameObject.GetComponent<Image>().color = Color.red;
                }
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}