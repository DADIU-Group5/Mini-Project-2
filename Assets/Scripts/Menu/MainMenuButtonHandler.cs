using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Mini2.Menu;

public class MainMenuButtonHandler : MonoBehaviour {

    public MainMenu2 MM;
    public MainMenuTextHandler MMT;
    public Slider soundSlider;

    void Start()
    {
        soundSlider.value = PlayerPrefs.GetFloat("MasterVolume");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Back();
        }
    }

	public void SetLanguageEnglish()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            return;
        }
        SaveData.instance.ChangeLanguage();
        MMT.UpdateLanguage();
    }

    public void SetLanguageDanish()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            SaveData.instance.ChangeLanguage();
            MMT.UpdateLanguage();
        }
    }

    public void Mainer()
    {
        MM.ChangeStateTo(MenuState.MainMenu);
    }

    public void Map()
    {
        MM.ChangeStateTo(MenuState.ThemeSelect);
    }

    public void Settings()
    {
        MM.ChangeStateTo(MenuState.Settings);
    }

    public void Pirate()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Pirate);
    }

    public void Mayan()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Mayan);
    }

    public void Space()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Space);
    }

    public void Unlockables()
    {
        MM.ChangeStateTo(MenuState.Unlockables);
    }

    public void Back()
    {
        MM.Back();
    }

    public void MusicChange(float f) {
        PlayerPrefs.SetFloat("MasterVolume", f);
    }

    public void ShowCredits()
    {
        MM.ShowCredits();
    }
}
