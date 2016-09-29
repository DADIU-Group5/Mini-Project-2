using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

    public Text buttonText;
    public Button button;
    public Image[] stars;
    int level;
    MainMenu MM;

	public void Setup(int i, MainMenu mm)
    {
        MM = mm;
        if (SaveData.instance.IsLanguageEnglish())
        {
            buttonText.text = "Level " + i;
        }
        else
        {
            buttonText.text = "Niveau " + i;
        }
        level = i;
        GetStars();
    }

    void GetStars()
    {
        if (!SaveData.instance.BeenPlayed(level))
        {
            Debug.Log("does not have key for level: " + level);
            button.interactable = false;
        }
        else
        {
            int temp = SaveData.instance.GetStarsForLevel(level);
            for (int i = 0; i < temp; i++)
            {
                stars[i].color = Color.yellow;
            }
        }
    }

    public void ButtonPress()
    {
        MM.LoadLevel(level);
    }
}
