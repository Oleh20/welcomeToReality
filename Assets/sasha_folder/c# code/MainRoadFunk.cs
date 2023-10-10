using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainRoadFunk: MonoBehaviour
{

   public VideoPlayer player;

   VideoClip[] Videos;

   public int mainroadstep;

    private void Start()
    {
      Videos =  GetComponent<AllVideos>().VideoClipListMain;
    }

    public void MainRoad()
    {
        player.clip = Videos[mainroadstep];

        mainroadstep++;
    }
}
