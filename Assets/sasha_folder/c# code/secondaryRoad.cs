using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class secondaryRoad : MonoBehaviour
{
    public VideoPlayer player;
    VideoClip[] Videos;

    public int othersteps;

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListSecondary;
        othersteps = GetComponent<MainRoadFunk>().mainroadstep;
    }
   




    public void OtherWay()
    {

        othersteps = GetComponent<MainRoadFunk>().mainroadstep;
        player.clip = Videos[othersteps];
        
     

        GetComponent<MainRoadFunk>().GoBack("second");

    }
    public void endofgame()
    {
        othersteps = GetComponent<MainRoadFunk>().mainroadstep;
        if (othersteps >= 5)

        {
            SceneManager.LoadScene("Mini game");

        }


    }


}
