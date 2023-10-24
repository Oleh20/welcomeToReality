using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class ControlButtons : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Locale targetLocale;
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private VideoPlayer videoPlayer;


    public void SwitchTo()
    {
        LocalizationSettings.SelectedLocale = targetLocale;
    }

    public void Response()
    {
        StartCoroutine(OpenURLWithDelay(1.0f));
    }

    private IEnumerator OpenURLWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSdGvOULRR2j2Sld_WfdQvxGAm8W2bRI5TpqpOu_Vj2l2keoFA/viewform");
    }

    public void LoadSceneWithDelay(float delay)
    {
        Time.timeScale = 1;
        StartCoroutine(LoadSceneWithDelay(sceneToLoad, delay));
    }

    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void DestroyMusicManager()
    {
        MusicManager musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            musicManager.DestroyMusicManager();
        }
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        videoPlayer.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);

        if (!videoPlayer.isPlaying) { videoPlayer.Play(); }
     
    }
}
//

