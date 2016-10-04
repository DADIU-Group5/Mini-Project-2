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
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void SetLanguageDanish()
    {
        if (SaveData.instance.IsLanguageEnglish())
        {
            SaveData.instance.ChangeLanguage();
            MMT.UpdateLanguage();
        }
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Mainer()
    {
        MM.ChangeStateTo(MenuState.MainMenu);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Map()
    {
        MM.ChangeStateTo(MenuState.ThemeSelect);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Settings()
    {
        MM.ChangeStateTo(MenuState.Settings);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Pirate()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Pirate);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Mayan()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Mayan);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Space()
    {
        MM.ChangeStateTo(MenuState.LevelSelect, Theme.Space);
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void Unlockables()
    {
        MM.ChangeStateTo(MenuState.Unlockables);
    }

    public void Back()
    {
        MM.Back();
        AudioMaster.instance.PlayEvent("menuClick");
    }

    public void MusicChange(float f) {
        PlayerPrefs.SetFloat("MasterVolume", f);
    }

    public void ShowCredits()
    {
        MM.ShowCredits();
        AudioMaster.instance.PlayEvent("menuClick");
    }
}
