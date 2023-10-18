using System.Collections;
using UnityEngine;
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

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListMain;

      //  canvasBTback.SetActive(false);

    }
    public void playstart()
    {
        player.clip = Videos[0];

        canvasbt.SetActive(false);
       

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


        if (mainroadstep == -1) { mainroadstep = 0; }
        canvasbt.SetActive(false);


        AreYouNeedPlayBetween();

    }
  
    public void GoBack()
    {


        if (mainroadstep == itsaveroad[0]) { MainRoad(); }
        else
        {

            mainroadstep--;



            canvasbt.SetActive(false);


            StartCoroutine(videoplayback());
        }
       
    }

    IEnumerator videoplayback()
    {
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => player.isPlaying == false);
        Debug.Log("videoplay");
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
