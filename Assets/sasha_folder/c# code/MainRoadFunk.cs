using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Video;

public class MainRoadFunk : MonoBehaviour
{
    [SerializeField] private Subtitles subtitlesComponent;
    [SerializeField]

   private List<int> delaysub = new List<int>();

    [SerializeField] private List<int> delaysubdeath = new List<int>();

    [SerializeField] private List<int> delaysubsecond = new List<int>();

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

   

    public bool itWasStarted = false;
    private void Start()
    {
        endofgame.SetActive(false);
        Videos = GetComponent<AllVideos>().VideoClipListMain;

        player.started += subtitelsof;

    }
    void subtitelsof(VideoPlayer vp) { subtitlesComponent.SetTextOf();     }
    public void playstart()
    {

        player.clip = Videos[0];
     
        StartCoroutine(subtitlesdelay(delaysub[mainroadstep], "main",mainroadstep));
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
      
        player.Play();

        

        



        StartCoroutine(subtitlesdelay(delaysub[mainroadstep], "main", mainroadstep));

        if (mainroadstep == -1) { mainroadstep = 0; }
       canvasbt.SetActive(false);

        
        AreYouNeedPlayBetween();
        
    
    }
  
    public void GoBack(string line)
    {
        if (line == "death")
        {

           // StartCoroutine(subtitlesdelay(delaysubdeath[mainroadstep], line, mainroadstep));
        }
        else { //StartCoroutine(subtitlesdelay(delaysubsecond[mainroadstep], line, mainroadstep)); 
        }


       

        if (mainroadstep == itsaveroad[0]) { mainroadstep++; canvasbt.SetActive(false); player.Play(); StartCoroutine(subtitlesdelay(delaysub[mainroadstep], "main", mainroadstep)); }
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
            player.Pause();

           


        }

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
   private IEnumerator aftervideoplayit( )
    {


        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);

   
        
        player.clip = videobetween[videonext];
        canvasbt.SetActive(false);
        
    }
   private IEnumerator subtitlesdelay(int delay,string road,int index)
    {
        subtitlesComponent.SetTextOf();
      
        yield return new WaitForSeconds(delay);

        subtitlesComponent.StartSubtitles(road, index);

    }




}
