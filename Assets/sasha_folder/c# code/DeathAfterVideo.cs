using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class DeathAfterVideo : MonoBehaviour
{
    public int deathstep;

    public VideoClip[] allvideos;
    public VideoPlayer playerrender;

    
    public void PlayONLYoneTimeandDeath()
    {
        deathstep = GetComponent<MainRoadFunk>().mainroadstep;
        playerrender.clip = allvideos[deathstep];

        GetComponent<MainRoadFunk>().GoBack();
    }
   
    




}
