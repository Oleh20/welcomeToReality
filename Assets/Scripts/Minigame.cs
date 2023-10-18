using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Video;

public class Minigame : MonoBehaviour
{
    public TextMeshProUGUI sliderValueText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI messageText;
    public Button startButton;
    public Button fillButton;
    public Slider slider;
    public VideoPlayer videoPlayer;
    public GameObject videoObject;
    public float timeLimit = 10.0f;
    public float fillAmountPerClick = 12.0f;
    public float winRangeMin = 40.0f;
    public float winRangeMax = 60.0f;
    public float minFillSpeed = 0.1f;
    public float maxFillSpeed = 2.0f;
    public float fillInterval = 0.5f;
    private float currentTime;
    private bool gameStarted;
    private bool gameEnded;
    private float sliderValue;
    private float randomFillSpeed;
    private float timeSinceLastFill;
    public VideoClip tooLittleVideoClip;
    public VideoClip tooMuchVideoClip;
    public VideoClip inRangeVideoClip;
    private bool gameVictory;


    private void Start()
    {
        videoObject.SetActive(true);
        videoPlayer.playOnAwake = true;
        videoPlayer.Pause();

        gameVictory = false; // Ініціалізуємо як "програш" на початку гри

        currentTime = timeLimit;
        sliderValue = 0;
        gameStarted = false;
        gameEnded = false;
        timeSinceLastFill = 0;

        startButton.onClick.AddListener(StartGame);
        fillButton.onClick.AddListener(FillSlider);


        UpdateSliderValueText();
        UpdateTimerText();
        RandomizeFillSpeed();
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
                    EndGame(true);
                }
                else
                {
                    EndGame(false);
                }
            }

            UpdateSliderValueText();
            UpdateSliderFillAmount();
        }
    }

    private void StartGame()
    {
        gameStarted = true;
        videoPlayer.Play();
    }

    private void EndGame(GameResult result)
    {
        gameEnded = true;
        gameStarted = false;

        switch (result)
        {
            case GameResult.TooLittle:
                // Гравець набрав замало (програш)
                messageText.text = "Гра програна (замало)!";
                videoPlayer.clip = tooLittleVideoClip;
                break;
            case GameResult.InRange:
                // Гравець набрав в заданому діапазоні (виграш)
                messageText.text = "Гра виграна (в діапазоні)!";
                videoPlayer.clip = inRangeVideoClip;
                break;
            case GameResult.TooMuch:
                // Гравець набрав забагато (програш)
                messageText.text = "Гра програна (забагато)!";
                videoPlayer.clip = tooMuchVideoClip;
                break;
        }

        videoPlayer.Play();
    }

    public enum GameResult
    {
        TooLittle,
        InRange,
        TooMuch
    }


    private void UpdateSliderValueText()
    {
        sliderValueText.text = "Значення слайдера: " + sliderValue.ToString("F2");
    }

    private void UpdateTimerText()
    {
        timerText.text = "Час: " + currentTime.ToString("F1");
    }

    private void FillSlider()
    {
        if (gameStarted && !gameEnded)
        {
            sliderValue += fillAmountPerClick;
            sliderValue = Mathf.Clamp(sliderValue, 0, 100); // Обмеження значення слайдера в межах 0-100.
            UpdateSliderValueText();
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
            UpdateSliderValueText();
        }
    }
}