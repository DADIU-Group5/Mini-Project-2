using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mini2.Menu;

public class MainMenuButton : MonoBehaviour {

    public Text buttonText;
    public Button button;
    public Image[] stars;
    public Image lockImage;
    int level;
    LevelLoader LL;
    string levelName;
    string slevel;

	public void Setup(int i, LevelLoader ll, string s)
    {
        levelName = s+i;
        slevel = s;
        LL = ll;
        if (SaveData.instance.IsLanguageEnglish())
        {
            buttonText.text = "Level " + i;
        }
        else
        {
            buttonText.text = "Bane " + i;
        }
        level = i;
        GetStars();
    }

    void GetStars()
    {
        if (SaveData.instance.WasLevelCompleted(slevel+(level-1)))
        {
            button.interactable = true;
            lockImage.enabled = false;
            int temp = SaveData.instance.GetStarsForLevel(levelName);
            for (int i = 0; i < temp; i++)
            {
                stars[i].color = Color.white;
            }
        }
        else
        {
            stars[0].enabled = false;
            stars[1].enabled = false;
            stars[2].enabled = false;
        }
    }

    public void ButtonPress()
    {
        LL.LoadLevel(levelName);
    }
}
