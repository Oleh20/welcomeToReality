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

   

    public GameObject timer;
    private int a = 0;

    private void Start()
    {
        
        gameObject.SetActive(false);
        player.GetComponent<VideoPlayer>().loopPointReached += canvasisActiv;
    
      

    }
    private void Update()
    {

        bool a = player.GetComponent<MainRoadFunk>().itWasStarted;
        if (a)
        {
            player.GetComponent<VideoPlayer>().loopPointReached += canvasisActiv;
        }
       
    }

    void canvasisActiv(VideoPlayer vp)
    {
      bool a =  player.GetComponent<MainRoadFunk>().itWasStarted;
        if (a)
        {
            for (int i = 0; i < allBT.Length; i++) { allBT[i].GetComponent<forButton>().SetTextForRoad(); }
            gameObject.SetActive(true);

            for (int i = 0; i < allBT.Length; i++)
            {
                allBT[i].GetComponent<forButton>().buttonIsActiv();

            }
            Debug.Log("asdasdasdasdasd");

            timer.GetComponent<timer10>().maketimeractiv();


        }
       
    }
  

}
