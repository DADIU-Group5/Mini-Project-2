using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

namespace Mini2.Menu
{
    public class MainMenu2 : MonoBehaviour
    {
        public MainMenuTextHandler mainMenuText;
        public LevelButtonCreator levelButtonCreator;

        public GameObject languageSelect;
        public GameObject mainMenu;
        public GameObject settings;
        public GameObject themeSelect;
        public GameObject levelSelect;

        private MenuState state = MenuState.languageSelect;
        private Theme theme;

        void Start()
        {
            GetInitialState();
            mainMenuText.UpdateLanguage();
        }

        void GetInitialState()
        {
            if (PlayerPrefs.GetInt("PlayedBefore") == 2)
            {
                ChangeStateTo(MenuState.ThemeSelect);
            }
            else if (PlayerPrefs.GetInt("PlayedBefore") == 1)
            {
                ChangeStateTo(MenuState.MainMenu);
            }
            else if(PlayerPrefs.GetInt("PlayedBefore") == 3)
            {
                ChangeStateTo(MenuState.Settings);
            }
            else if(PlayerPrefs.GetInt("PlayedBefore") == 4)
            {
                ChangeStateTo(MenuState.LevelSelect, Theme.Pirate);
            }
            else if (PlayerPrefs.GetInt("PlayedBefore") == 5)
            {
                ChangeStateTo(MenuState.LevelSelect, Theme.Mayan);
            }
            else if (PlayerPrefs.GetInt("PlayedBefore") == 6)
            {
                ChangeStateTo(MenuState.LevelSelect, Theme.Space);
            }
            PlayerPrefs.SetInt("PlayedBefore", 1);
        }

        public void ChangeStateTo(MenuState newState)
        {
            LeaveState(state);
            EnterState(newState);
            state = newState;
        }

        public void ChangeStateTo(MenuState newState, Theme t)
        {
            theme = t;
            LeaveState(state);
            EnterState(newState);
            state = newState;
        }

        public void ShowCredits()
        {
            PlayerPrefs.SetInt("PlayedBefore", 3);
            SceneManager.LoadScene("Credits");
        }

        public void Back()
        {
            if (state == MenuState.Settings)
            {
                ChangeStateTo(MenuState.MainMenu);
            }
            else if (state == MenuState.ThemeSelect)
            {
                ChangeStateTo(MenuState.MainMenu);
            }
            else if (state == MenuState.LevelSelect)
            {
                ChangeStateTo(MenuState.ThemeSelect);
            }
        }

        void LeaveState(MenuState state)
        {
            switch (state)
            {
                case MenuState.languageSelect:
                    languageSelect.SetActive(false);
                    break;
                case MenuState.MainMenu:
                    mainMenu.SetActive(false);
                    break;
                case MenuState.Settings:
                    settings.SetActive(false);
                    break;
                case MenuState.ThemeSelect:
                    themeSelect.SetActive(false);
                    break;
                case MenuState.LevelSelect:
                    levelSelect.SetActive(false);
                    levelButtonCreator.RemoveButtons();
                    break;
                default:
                    break;
            }
        }

        void EnterState(MenuState state)
        {
            switch (state)
            {
                case MenuState.languageSelect:
                    languageSelect.SetActive(true);
                    break;
                case MenuState.MainMenu:
                    mainMenu.SetActive(true);
                    break;
                case MenuState.Settings:
                    settings.SetActive(true);
                    break;
                case MenuState.ThemeSelect:
                    themeSelect.SetActive(true);
                    break;
                case MenuState.LevelSelect:
                    levelSelect.SetActive(true);
                    levelButtonCreator.CreateButtons(theme);
                    break;
                default:
                    break;
            }
        }
    }

    public enum MenuState
    {
        languageSelect, MainMenu, Settings, ThemeSelect, LevelSelect
    }

    public enum Theme
    {
        Pirate, Mayan, Space
    }
}