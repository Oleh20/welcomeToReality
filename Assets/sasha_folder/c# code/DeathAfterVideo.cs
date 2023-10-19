using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class DeathAfterVideo : MonoBehaviour
{

    public int deathstep;

    VideoClip[] Videos;
    public VideoPlayer playerrender;
    [SerializeField] private Subtitles subtitlesComponent;

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListDeath;

        deathstep = GetComponent<MainRoadFunk>().mainroadstep;

    }


    public void PlayONLYoneTimeandDeath()
    {
        deathstep = GetComponent<MainRoadFunk>().mainroadstep;
        playerrender.clip = Videos[deathstep];
        //  subtitlesComponent.StartSubtitles("death", deathstep);


        

       
       
            GetComponent<MainRoadFunk>().GoBack();
       
       

    }
   



  
    public void noantwort() 
    {
        deathstep = GetComponent<MainRoadFunk>().mainroadstep;
        if (deathstep >= 5)

        {

            playerrender.clip = Videos[6];

            playerrender.Play();
        }

    }
   
    




}
