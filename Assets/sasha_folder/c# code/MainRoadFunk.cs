using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class MainRoadFunk: MonoBehaviour
{
    
    public GameObject canvasBTback;
    public GameObject canvasbt;

   public VideoPlayer player;

  private VideoClip[] Videos;

   public int mainroadstep;

    private void Start()
    { 
       Videos =  GetComponent<AllVideos>().VideoClipListMain;
        
        canvasBTback.SetActive(false);
    }
    

    public void MainRoad()
    {// play main story line 

        player.clip = Videos[mainroadstep];

        player.Play();
        
        mainroadstep++;
        canvasbt.SetActive(false) ;

      

      
    }
    public void GoBack()
    {

        mainroadstep--;
        if (mainroadstep <= -1) { mainroadstep = 0; }

        canvasbt.SetActive(false);

        
       StartCoroutine(videoplayback()); 
    }
  
    IEnumerator videoplayback()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false );
        Debug.Log("videoplay");
        MainRoad();  //atomatish send you back 
        //canvasBTback.SetActive(true); canvasbt.SetActive(false);//with button send you back
    }





}
