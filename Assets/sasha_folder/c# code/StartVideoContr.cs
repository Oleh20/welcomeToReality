using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartVideoContr : MonoBehaviour
{
    public bool youwantstart;

    public Canvas canvas;

    public VideoClip[] videoarr = new VideoClip[2];

    public GameObject btcanvas;
    public VideoClip startvideo;

    private VideoPlayer player;

  //  [SerializeField] private Subtitles subtitlesComponent;
    void Start()
    {
        if (youwantstart)
        {
            player = GetComponent<VideoPlayer>();

            player.clip = startvideo;

            player.Play();
           // subtitlesComponent.StartSubtitles("intro", 0);
            player.GetComponent<VideoPlayer>().loopPointReached += showBT;
        }
    }
    void showBT (VideoPlayer vp)
    {
        if (canvas != null) { canvas.gameObject.SetActive(true); }

        if (player.GetComponent<MainRoadFunk>().mainroadstep >= 6)
        {
            player.GetComponent<MainRoadFunk>().lastmap();
        }
    }
    
   public void roadone()
    {

        player.clip = videoarr[0];
       // subtitlesComponent.StartSubtitles("intro", 1);
        StartCoroutine(delay());

     

    }
    public void roadtwo () 
    {
        player.clip = videoarr[1];
       // subtitlesComponent.StartSubtitles("intro", 2);
        StartCoroutine(delay());

        
    }
    public void startend ()
    
    {
       

        player.GetComponent<MainRoadFunk>().playstart();
    
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);
        startend();
    }




}
