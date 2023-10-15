using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class DeathAfterVideo : MonoBehaviour
{

    public int deathstep;

    VideoClip[] Videos;
    public VideoPlayer playerrender;

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListSecondary;
    }


    public void PlayONLYoneTimeandDeath()
    {
        deathstep = GetComponent<MainRoadFunk>().mainroadstep;
        playerrender.clip = Videos[deathstep];



        GetComponent<MainRoadFunk>().GoBack();
    }
   
    




}
