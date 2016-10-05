using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mini2.Menu;

public class MainMenuTextHandler : MonoBehaviour {

    [Header("MainMenu")]
    public Text map;
    public Text settings;
    public Text unlockablesButton;

    [Header("Settings")]
    public Text settingsBack;
    public Text soundLevel;
    public Text credits;

    [Header("ThemeSelect")]
    public Text themeText;
    public Text themeBack;
    public Text pirate;
    public Text mayan;
    public Text space;
    public Text comingSoon1;
    public Text comingSoon2;

    [Header("LevelSelect")]
    public Text themeName;
    public Text levelBack;
    public Text levelMenu;

    [Header("Unlockables")]
    public Text galleryHeadline;
    public Text unlockablesText;

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
        map.text = "Play";
        settings.text = "Settings";
        unlockablesButton.text = "Gallery";

        //Settings
        settingsBack.text = "Back";
        soundLevel.text = "Sound level";
        credits.text = "Credits";

        //Theme
        themeText.text = "Theme";
        themeBack.text = "Back";
        pirate.text = "Pirate";
        mayan.text = "Mayan";
        space.text = "Space";
        comingSoon1.text = "Coming soon";
        comingSoon2.text = "Coming soon";

        //Unlockables
        galleryHeadline.text = "Gallery";
        unlockablesText.text = SaveData.instance.GetAllEarnedStars() + "/" + SaveData.instance.GetAllPossibleStars();
     }

    public void UpdateTextToDanish()
    {
        //Main menu
        map.text = "Spil";
        settings.text = "Indstillinger";
        unlockablesButton.text = "Galleri";

        //Settings
        settingsBack.text = "Tilbage";
        soundLevel.text = "Lyd niveau";
        credits.text = "Lavet af";

        //Theme
        themeText.text = "Tema";
        themeBack.text = "Tilbage";
        pirate.text = "Pirat";
        mayan.text = "Mayaner";
        space.text = "Rum";
        comingSoon1.text = "Kommer Snart";
        comingSoon2.text = "Kommer Snart";

        //Unlockables
        galleryHeadline.text = "Galleri";
        unlockablesText.text = SaveData.instance.GetAllEarnedStars() + "/" + SaveData.instance.GetAllPossibleStars();
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
                themeName.text = "Pirat baner";
                break;
            case Theme.Mayan:
                themeName.text = "Mayaner baner";
                break;
            case Theme.Space:
                themeName.text = "Rum baner";
                break;
            default:
                break;
        }
        levelBack.text = "Tilbage";
        levelMenu.text = "Hoved menu";
    }
}