using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class forButton : MonoBehaviour
{
    public GameObject rendervideocontroller;

   public string[] mainroadtext;

     int nummeroftext;

    public bool ItActiv;

    public bool bottunMainRoad;

    public bool secondaryRoad;

    public bool DeathRoad;

    private void Start()
    { 
     
        Button button = GetComponent<Button>();
        // ��������� ������ �� ������������ ���� � ������ ��� � ��� ��� ����� ��� ��� ������ ����� 
        if (bottunMainRoad)
        {


            button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad);

        }




      

        // button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);
        // button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad)  ;
       // button.onClick.AddListener(rendervideocontroller.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath)

    }
    public void Random()
    {

    }
    private void FixedUpdate()
    {// ������ ���������� ����� ���������� ��� �� ���������� ������
        if (ItActiv)
        {
           this.gameObject.SetActive(true);
        }
        else { this.gameObject.SetActive(false); }
    }

    private void Update()
    {
        // ��������� ������ �� ������ �� ����� ���������� �������� �� ����� �� ������� � ����������� ������ 
        nummeroftext = rendervideocontroller.GetComponent<MainRoadFunk>().mainroadstep;
        gameObject.GetComponentInChildren<Text>().text = mainroadtext[nummeroftext];
    }
}
