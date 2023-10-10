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
    {//проигрывает следующее видео 
        player.clip = Videos[mainroadstep];

        mainroadstep++;
    }
    public void GoBack()
    {//скип на уровень назад
        mainroadstep--;
        if (mainroadstep == -1) { mainroadstep++; }
        player.clip = Videos[mainroadstep];
    }
    private void Update()
    {
        //проверка проигруется ли видео и отключаются кнопки 
        if (player.isPlaying)
        {
            canvasbt.enabled = false;
        }
        else { canvasbt.enabled = true; }
    }
   
}
