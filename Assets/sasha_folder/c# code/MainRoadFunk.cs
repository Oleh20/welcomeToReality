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

        mainroadstep++;
    }
    public void GoBack()
    {//���� �� ������� �����
        mainroadstep--;
        if (mainroadstep == -1) { mainroadstep++; }
        player.clip = Videos[mainroadstep];
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
