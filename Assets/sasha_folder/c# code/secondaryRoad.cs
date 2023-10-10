using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class secondaryRoad : MonoBehaviour
{
    public VideoPlayer player;
    VideoClip[] Videos;

    public int othersteps;

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListSecondary;
    }




    public void OtherWay()
    {// включение видео с другого масива 

        player.clip = Videos[othersteps];

        othersteps++;
    }

}
