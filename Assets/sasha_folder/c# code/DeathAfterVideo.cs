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
    public void PlayONLYoneTimeandDeath()
    {// ������ ������ � ����� ����� ������� 

        playerrender.clip = allvideos[deathstep];
        

        StartCoroutine(carutine());

    }
    IEnumerator carutine () {
        //�������� ����� ������� 
        yield return new WaitForSeconds(5) ;
        


            GetComponent<MainRoadFunk>().GoBack(playerrender.GetComponent<MainRoadFunk>().mainroadstep); 


    ;}




}
