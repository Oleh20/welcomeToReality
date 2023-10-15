using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlButtons: MonoBehaviour
{
    public void SwitchToEN()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[0];

    }

    public void SwitchToUA()
    {
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];

    }

    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLanguageSelection()
    {
        SceneManager.LoadScene("Language selection");
    }

    public void QuitGame()
    {

        Application.Quit();

    }

}
