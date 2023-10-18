using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.Localization.Settings;

public class Minigame : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private Image info;
    [SerializeField] private Button startButton;
    [SerializeField] private Button fillButton;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private float fillAmountPerClick = 12.0f;
    [SerializeField] private float winRangeMin = 50.0f;
    [SerializeField] private float winRangeMax = 60.0f;
    [SerializeField] private float minFillSpeed = 1.0f;
    [SerializeField] private float maxFillSpeed = 5.0f;
    [SerializeField] private float fillInterval = 0.25f;
    [SerializeField] private VideoClip tooLittleVideoClip;
    [SerializeField] private VideoClip tooMuchVideoClip;
    [SerializeField] private VideoClip inRangeVideoClip;
    [SerializeField] private VideoClip finihVideo;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Slider slider;
    [SerializeField] private Button reloadButton;
    [SerializeField] private GameObject music;
    public string mainRoadTextLocalizationKey = "Time";
    private string abouTheGame;
    private float currentTime;
    private bool gameStarted;
    private bool gameEnded;
    private float sliderValue;
    private float randomFillSpeed;
    private float timeSinceLastFill;
    private float timeLimit = 10.0f;

    private void Start()
    {
        videoPlayer.playOnAwake = true;
        videoPlayer.Pause();

        currentTime = timeLimit;
        sliderValue = 0;
        gameStarted = false;
        gameEnded = false;
        timeSinceLastFill = 0;
        canvas.SetActive(false);

        startButton.onClick.AddListener(StartGame);
        fillButton.onClick.AddListener(FillSlider);
        startButton.onClick.AddListener(ShowCanvas);
        startButton.onClick.AddListener(HideButton);

        UpdateTimerText();
        RandomizeFillSpeed();
    }
    private void HideButton()
    {
        startButton.gameObject.SetActive(false);

    }
    private void ShowCanvas()
    {
        canvas.SetActive(true);
    }

    private void Update()
    {
        if (gameStarted && !gameEnded)
        {
            currentTime -= Time.deltaTime;
            timeSinceLastFill += Time.deltaTime;

            if (timeSinceLastFill >= fillInterval)
            {
                timeSinceLastFill = 0;
                FillSliderAutomatically();
            }

            UpdateTimerText();

            if (currentTime <= 0)
            {
                if (sliderValue >= winRangeMin && sliderValue <= winRangeMax)
                {
                    EndGame("InRange");
                }
                else if (sliderValue <= winRangeMin)
                {
                    EndGame("TooLittle");
                }
                else if (sliderValue >= winRangeMax)
                {
                    EndGame("TooMuch");
                }
            }
            UpdateSliderFillAmount();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        videoPlayer.Play();
    }

    private void EndGame(string result)
    {

        gameEnded = true;
        gameStarted = false;

        switch (result)
        {
            case "TooLittle":
                StartVideo();
                videoPlayer.clip = tooLittleVideoClip;
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoFinished;
                break;
            case "InRange":
                StartVideo();
                videoPlayer.clip = inRangeVideoClip;
                videoPlayer.loopPointReached += OnVideoEnd;
                videoPlayer.Play();
                

                break;
            case "TooMuch":
                StartVideo();
                videoPlayer.clip = tooMuchVideoClip;
                videoPlayer.Play();
                videoPlayer.loopPointReached += OnVideoFinished;
                break;
        }

        videoPlayer.Play();
    }
    private void OnVideoEnd(VideoPlayer vp)
    {
        videoPlayer.clip = finihVideo;
        videoPlayer.loopPointReached += FinishGame;
    }
    private void FinishGame(VideoPlayer vp)
    {
        SceneManager.LoadScene("About The Game");
    }
    private void OnVideoFinished(VideoPlayer vp)
    {
        reloadButton.gameObject.SetActive(true);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("Mini game");
    }

    private void UpdateTimerText()
    {
        timerText.text = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKey) + currentTime.ToString("F1");
    }

    private void FillSlider()
    {
        if (gameStarted && !gameEnded)
        {
            sliderValue += fillAmountPerClick;
            sliderValue = Mathf.Clamp(sliderValue, 0, 100);
            UpdateSliderFillAmount();
        }
    }

    private void RandomizeFillSpeed()
    {
        randomFillSpeed = Random.Range(minFillSpeed, maxFillSpeed);
    }

    private void UpdateSliderFillAmount()
    {
        slider.value = sliderValue;
    }

    private void FillSliderAutomatically()
    {
        if (gameStarted && !gameEnded)
        {
            float randomDecrement = Random.Range(minFillSpeed, maxFillSpeed);
            sliderValue -= randomDecrement;
            sliderValue = Mathf.Clamp(sliderValue, 0, 100);
        }
    }
    private void StartVideo()
    {
        music.gameObject.SetActive(false);
        info.gameObject.SetActive(false);
        slider.gameObject.SetActive(false);
        fillButton.gameObject.SetActive(false);
        timerText.gameObject.SetActive(false);
    }
}