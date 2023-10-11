using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MainRoadFunk: MonoBehaviour
{
   
    public Canvas canvasbt;

   public VideoPlayer player;

   VideoClip[] Videos;

   public int mainroadstep;

    private void Start()
    {
       
        Videos =  GetComponent<AllVideos>().VideoClipListMain;
    }

    public void MainRoad()
    {//����������� ��������� ����� 
        player.clip = Videos[mainroadstep];

        GetComponent<DeathAfterVideo>().deathstep++;
        GetComponent<secondaryRoad>().othersteps++;
        mainroadstep++;
    }
    public void GoBack(int road)
    {//���� �� ������� �����
        road--;
        if (road == -1) { road++; }
        player.clip = Videos[road];
    }
    private void Update()
    {
        //�������� ����������� �� ����� � ����������� ������ 
        if (player.isPlaying)
        {
            canvasbt.enabled = false;
        }
        else { canvasbt.enabled = true; }
    }
   
}
