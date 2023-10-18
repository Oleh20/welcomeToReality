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


    private void Start()
    {
        videoPlayer.playOnAwake = true;
        videoPlayer.Pause();

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
                    EndGame("InRange");
                }
               else if(sliderValue <= winRangeMin)
                {
                    EndGame("TooLittle");
                }
                else if(sliderValue >= winRangeMax)
                {
                    EndGame("TooMuch");
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

    private void EndGame(string result)
    {

        gameEnded = true;
        gameStarted = false;

        switch (result)
        {
            case "TooLittle":
                videoPlayer.clip = tooLittleVideoClip;
                break;
            case "InRange":
                videoPlayer.clip = inRangeVideoClip;
                break;
            case "TooMuch":
                videoPlayer.clip = tooMuchVideoClip;
                break;
        }

        videoPlayer.Play();
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
            sliderValue = Mathf.Clamp(sliderValue, 0, 100); 
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