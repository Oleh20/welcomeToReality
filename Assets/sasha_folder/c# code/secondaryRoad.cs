using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class sec : MonoBehaviour
{
    public VideoPlayer player;
    VideoClip[] Videos;

    public int othersteps;

    private void Start()
    {
        Videos = GetComponent<AllVideos>().VideoClipListSecondary;
    }




    public void OtherWay()
    {

        player.clip = Videos[othersteps];

        othersteps++;
    }

}
