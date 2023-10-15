using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartVideoContr : MonoBehaviour
{
    public Canvas canvas;

    public VideoClip[] videoarr = new VideoClip[2];


    public VideoClip startvideo;

    private VideoPlayer player;
    void Start()
    {
        player = GetComponent<VideoPlayer>()  ;

        player.clip = startvideo;

        player.Play();

        player.GetComponent<VideoPlayer>().loopPointReached += showBT ;
    }
    void showBT (VideoPlayer vp)
    {
       canvas.gameObject.SetActive(true);



    }
    
   public void roadone()
    {

        player.clip = videoarr[0];

        StartCoroutine(delay());

     

    }
    public void roadtwo () 
    {
        player.clip = videoarr[1];
        StartCoroutine(delay());

        
    }
    public void startend ()
    
    {
        Debug.Log("startend");

        player.GetComponent<MainRoadFunk>().playstart();
    
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);
        startend();
    }




}
