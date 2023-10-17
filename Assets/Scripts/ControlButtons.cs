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
        StartCoroutine(LoadSceneWithDelay("Menu", 1.0f));
    }

    public void LoadLanguageSelection()
    {
        StartCoroutine(LoadSceneWithDelay("Language selection", 1.0f));
    }

    public void LoadAboutTheGame()
    {
        StartCoroutine(LoadSceneWithDelay("About the game", 1.0f));
    }

    public void QuitGame()
    {

        Application.Quit();

    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

}
