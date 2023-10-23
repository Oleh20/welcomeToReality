using JetBrains.Annotations;
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
    [SerializeField]
    private VideoClip startVideo;


    public int[] itsaveroad;
    public int mainroadstep;

    

   

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
        
        
        if (mainroadstep == -1) { mainroadstep = 0; player.clip = startVideo; }
        else
        {
            
            mainroadstep++;
            player.clip = Videos[mainroadstep];
        }
      
        player.Play();
        StartCoroutine(subtitlesdelay(delaysub[mainroadstep], "main", mainroadstep));
       canvasbt.SetActive(false);

       
    }
    
    
    public void GoBack(string line)
    {
        

       

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
    

 

   private IEnumerator subtitlesdelay(int delay,string road,int index)
    {
        subtitlesComponent.SetTextOf();
      
        yield return new WaitForSeconds(delay);

        subtitlesComponent.StartSubtitles(road, index);

    }




}
