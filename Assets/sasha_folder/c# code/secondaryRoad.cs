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
    private void Update()
    {
       othersteps = GetComponent<MainRoadFunk>().mainroadstep;
    }




    public void OtherWay()
    {// ��������� ����� � ������� ������ 

        player.clip = Videos[othersteps];

        StartCoroutine(carutine());
      //  GetComponent<MainRoadFunk>().GoBack(othersteps);


    }
    IEnumerator carutine()
    {
        //�������� ����� ������� 
        yield return new WaitForSeconds(2);



        GetComponent<MainRoadFunk>().GoBack();


    }

}
