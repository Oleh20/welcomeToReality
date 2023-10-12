using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class DeathAfterVideo : MonoBehaviour
{
    public int deathstep;

    public VideoClip[] allvideos;
    public VideoPlayer playerrender;

    private void Start()
    {
     
    }
    private void Update()
    {
        deathstep = GetComponent<MainRoadFunk>().mainroadstep;
    }
    public void PlayONLYoneTimeandDeath()
    {// смерть игрока и откат видео обратно 

        playerrender.clip = allvideos[deathstep];

        
        StartCoroutine(carutine());

    }
    IEnumerator carutine () {
        //задержка перед откатом 
        yield return new WaitForSeconds(2) ;
        


            GetComponent<MainRoadFunk>().GoBack(); 


    }




}
