using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class randomRoadC : MonoBehaviour
{
    



    public Button[] allBT;


    public GameObject player;

   

    public GameObject timer;
  

    private void Start()
    {
        RandomButton();
        gameObject.SetActive(false);
        player.GetComponent<VideoPlayer>().loopPointReached += canvasisActiv;


        


       
    }
    void RandomButton()
    {

        bool mybool = allBT[0].GetComponent<forButton>().a;

        int a = Random.Range(0, 3);
        switch (a)
        {
            case 0:

                resetbt();


                allBT[0].GetComponent<forButton>().a = true;
                allBT[1].GetComponent<forButton>().b = true;
                allBT[2].GetComponent<forButton>().c = true;
                break;
                case 1:
                resetbt();


                allBT[1].GetComponent<forButton>().a = true;
                allBT[0].GetComponent<forButton>().b = true;
                allBT[2].GetComponent<forButton>().c= true;

                break;
                case 2:

                resetbt();

                allBT[2].GetComponent<forButton>().a = true;
                allBT[1].GetComponent<forButton>().b = true;
                allBT[0].GetComponent<forButton>().c = true;


                break; 
        }
        



      

    }
    void resetbt()
    {
        for (int i = 0; allBT.Length > i; i++)
        {
            allBT[i].GetComponent<forButton>().a = false;
            allBT[i].GetComponent<forButton>().b = false;
            allBT[i].GetComponent<forButton>().c = false;
        }
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
                RandomButton();

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
