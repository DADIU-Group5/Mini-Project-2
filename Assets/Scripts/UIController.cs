using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Mini2.Utils;

public class UIController : Singleton<UIController> {

    public GameObject endPanel;
    public Text scoreT;

	public void ShowEndScreen()
    {
        scoreT.text = "Score: "+ScoreManager.instance.score;
        endPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
