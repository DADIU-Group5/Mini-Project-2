using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mini2.Menu;

public class MainMenuTextHandler : MonoBehaviour {

    [Header("MainMenu")]
    public Text map;
    public Text settings;

    [Header("Settings")]
    public Text settingsBack;
    public Text soundLevel;
    public Text credits;

    [Header("ThemeSelect")]
    public Text themeBack;
    public Text pirate;
    public Text mayan;
    public Text space;

    [Header("LevelSelect")]
    public Text themeName;
    public Text levelBack;
    public Text levelMenu;

    public void UpdateLanguage()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            UpdateTextToEnglish();
        }
        else
        {
            UpdateTextToDanish();
        }
    }

    public void UpdateLanguage(Theme theme)
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            UpdateLevelTextToEnglish(theme);
        }
        else
        {
            UpdateLevelTextToDanish(theme);
        }
    }

    public void UpdateTextToEnglish()
    {
        //Main menu
        map.text = "Map";
        settings.text = "Settings";

        //Settings
        settingsBack.text = "Back";
        soundLevel.text = "Sound level";
        credits.text = "Credits";

        //Theme
        themeBack.text = "Back";
        pirate.text = "Pirate";
        mayan.text = "Mayan";
        space.text = "Space";

    }

    public void UpdateTextToDanish()
    {
        //Main menu
        map.text = "Kort";
        settings.text = "Indstillinger";

        //Settings
        settingsBack.text = "Tilbage";
        soundLevel.text = "Lyd niveau";
        credits.text = "Lavet af";

        //Theme
        themeBack.text = "Tilbage";
        pirate.text = "Pirat";
        mayan.text = "Mayaner";
        space.text = "Rum";
    }

    public void UpdateLevelTextToEnglish(Theme theme)
    {
        switch (theme)
        {
            case Theme.Pirate:
                themeName.text = "Pirate levels";
                break;
            case Theme.Mayan:
                themeName.text = "Mayan levels";
                break;
            case Theme.Space:
                themeName.text = "Space levels";
                break;
            default:
                break;
        }
        levelBack.text = "Back";
        levelMenu.text = "Main menu";
    }

    public void UpdateLevelTextToDanish(Theme theme)
    {
        switch (theme)
        {
            case Theme.Pirate:
                themeName.text = "Pirat niveauer";
                break;
            case Theme.Mayan:
                themeName.text = "Mayaner niveauer";
                break;
            case Theme.Space:
                themeName.text = "Rum niveauer";
                break;
            default:
                break;
        }
        levelBack.text = "Tilbage";
        levelMenu.text = "Hoved menu";
    }
}