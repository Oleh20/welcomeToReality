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
    {// ��������� ����� � ������� ������ 

        player.clip = Videos[othersteps];

        othersteps++;
        GetComponent<MainRoadFunk>().GoBack(othersteps);
    }

}
