using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;


public class StopGame : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private GameObject pauseCanvas1;
    [SerializeField] private GameObject pauseCanvas2;
    [SerializeField] private GameObject pauseCanvas3;
    [SerializeField] private GameObject pauseCanvas4;
    [SerializeField] private VideoPlayer videoPlayer;

   


    public void PauseTheGame()
    {
        Time.timeScale = 0;
        pauseCanvas.SetActive(true);
        pauseCanvas1.SetActive(true);
        pauseCanvas2.SetActive(true);
        pauseCanvas3.SetActive(true);
        pauseCanvas4.SetActive(true);
        videoPlayer.Pause();
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pauseCanvas.SetActive(false);
        pauseCanvas1.SetActive(false);
        pauseCanvas2.SetActive(false);
        pauseCanvas3.SetActive(false);
        pauseCanvas4.SetActive(false);
        videoPlayer.Play();


    }
}


