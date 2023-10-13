using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class randomRoadC : MonoBehaviour
{
    public bool[] randomroad = new bool[3];



    public Button[] allBT;


    public GameObject player;

    private int it;
   
    private void Start()
    {
        gameObject.SetActive(false);
        player.GetComponent<VideoPlayer>().loopPointReached += canvasisActiv;

       

    }
    void canvasisActiv(VideoPlayer vp)
    {

       gameObject.SetActive(true);

        
       


    }
  

}
