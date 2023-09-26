using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
public class VideosController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    [SerializeField] private Video videoComponent;


    [SerializeField] private Button nextButton;
    [SerializeField] private Button nextButton2;


    [SerializeField] private VideoClip videoClip;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    public void PlayNextVideoFirst()
    {
        videoClip = videoComponent.videoOnButton;
        PlayVideo();
        setCurrentVideoComponent(videoComponent.nextVideoClass);

    }
    public void PlayNextVideoSecond()
    {
        videoClip = videoComponent.videoOnButton;
        PlayVideo();
        setCurrentVideoComponent(videoComponent.secondNextVideoClass);
    }

    void PlayVideo()
    {
        videoPlayer.clip = videoClip;

        if (videoPlayer.isPrepared)
        {
            nextButton.gameObject.SetActive(false);
            nextButton2.gameObject.SetActive(false);
            videoPlayer.Play();

        }
        else
        {
            StartCoroutine(PlayWhenPrepared());
        }
    }
    IEnumerator PlayWhenPrepared()
    {
        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        nextButton.gameObject.SetActive(false);
        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        nextButton.gameObject.SetActive(true);
        nextButton2.gameObject.SetActive(true);
    }


    public void setCurrentVideoComponent(Video video)
    {
        videoComponent = video;
    }
}
