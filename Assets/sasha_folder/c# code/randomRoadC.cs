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

    
       
    }

    void canvasisActiv(VideoPlayer vp)
    {
      bool a =  player.GetComponent<MainRoadFunk>().itWasStarted;
        if (a)
        {
            if (player.GetComponent<MainRoadFunk>().mainroadstep >= 6) { }
            else
            {


                for (int i = 0; i < allBT.Length; i++) { allBT[i].GetComponent<forButton>().SetTextForRoad(); }
                gameObject.SetActive(true);

                for (int i = 0; i < allBT.Length; i++)
                {
                    allBT[i].GetComponent<forButton>().buttonIsActiv();

                }


                timer.GetComponent<timer10>().maketimeractiv();

            }
        }
       
    }
  

}
