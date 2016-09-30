using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Mini2.Menu;

public class LevelButtonCreator : MonoBehaviour {
    
    public LevelLoader LL;
    public GameObject basicButton;

    private int amount;
    List<GameObject> buttons = new List<GameObject>();

    public void CreateButtons(Theme t)
    {
        switch (t)
        {
            case Theme.Pirate:
                amount = LL.pirateLevels;
                break;
            case Theme.Mayan:
                amount = LL.mayanLevels;
                break;
            case Theme.Space:
                amount = LL.spaceLevels;
                break;
            default:
                amount = LL.pirateLevels;
                break;
        }

        string levelName = "Pirate";
        switch (t)
        {
            case Theme.Pirate:
                levelName = "Pirate";
                break;
            case Theme.Mayan:
                levelName = "Mayan";
                break;
            case Theme.Space:
                levelName = "Space";
                break;
            default:
                levelName = "Pirate";
                break;
        }

        for (int i = 1; i <= amount; i++)
        {
            GameObject GO = Instantiate(basicButton, transform) as GameObject;
            GO.GetComponent<MainMenuButton>().Setup(i, LL, levelName);
            buttons.Add(GO);
        }
    }

    public void RemoveButtons()
    {
        foreach (GameObject item in buttons)
        {
            Destroy(item);
        }
        buttons.Clear();
    }
}
