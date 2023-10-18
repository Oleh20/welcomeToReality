using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MainRoadFunk : MonoBehaviour
{

    public GameObject canvasBTback;
    public GameObject canvasbt;

    public VideoPlayer player;

    private VideoClip[] Videos;


    public int[] itsaveroad;
    public int mainroadstep;

    
    private int videonext = 0;
    public VideoClip[] videobetween;
    public int[] playbetween;

    public GameObject endofgame;

   // [SerializeField] private Subtitles subtitlesComponent;

    public bool itWasStarted = false;
    private void Start()
    {
        endofgame.SetActive(false);
        Videos = GetComponent<AllVideos>().VideoClipListMain;

      //  canvasBTback.SetActive(false);

    }
    public void playstart()
    {
        player.clip = Videos[0];
       // subtitlesComponent.StartSubtitles("intro", 3);
        //  canvasbt.SetActive(false);

        itWasStarted = true;
    }



    public void MainRoad()
    {// play main story line 


        if (mainroadstep == -1) { mainroadstep = 0; player.clip = Videos[mainroadstep]; }
        else
        {
            
            mainroadstep++;
            player.clip = Videos[mainroadstep];
        }
       // subtitlesComponent.StartSubtitles("main", mainroadstep);
        player.Play();


        if (mainroadstep == -1) { mainroadstep = 0; }
       canvasbt.SetActive(false);


        AreYouNeedPlayBetween();
        
     //   StartCoroutine(videoplayback1());
    }
  
    public void GoBack()
    {


        if (mainroadstep == itsaveroad[0]) { mainroadstep++; canvasbt.SetActive(false); player.Play(); }
        else
        {

            mainroadstep--;

            canvasbt.SetActive(false);


           StartCoroutine(videoplayback());
        }
       
    }
    public void lastmap()
    {
        if (mainroadstep >= 6)
        
        {
            canvasBTback.SetActive(false);
            canvasbt.SetActive(false);
            endofgame.SetActive(true);

        }

    }
    IEnumerator videoplayback1()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);

        
        lastmap();  //atomatish send you back 
        //canvasBTback.SetActive(true); canvasbt.SetActive(false);//with button send you back
    }


    IEnumerator videoplayback()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);
        
        MainRoad();  //atomatish send you back 
        //canvasBTback.SetActive(true); canvasbt.SetActive(false);//with button send you back
    }
    void AreYouNeedPlayBetween()
    {
        for (int i = 0; i < playbetween.Length; i++)
        {

            if (playbetween[i] == mainroadstep)
            {
                PlayBetween();
                videonext = i;
            }

        }

    }

    public void PlayBetween()
    {
        StartCoroutine(aftervideoplayit());

    }
    IEnumerator aftervideoplayit( )
    {


        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);

   
        
        player.clip = videobetween[videonext];
        canvasbt.SetActive(false);
        
    }




}
