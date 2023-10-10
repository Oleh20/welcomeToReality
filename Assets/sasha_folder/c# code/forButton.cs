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
        // установил кнопку на определенный путь а значит это а хуй его знает что это значит блять 
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
    {// просто переменная чтобы отображать или не отображать кнопку
        if (ItActiv)
        {
           this.gameObject.SetActive(true);
        }
        else { this.gameObject.SetActive(false); }
    }

    private void Update()
    {
        // установка текста на кнопке но нужно переделать закинуть на какую то функцию с обновлением кнопок 
        nummeroftext = rendervideocontroller.GetComponent<MainRoadFunk>().mainroadstep;
        gameObject.GetComponentInChildren<Text>().text = mainroadtext[nummeroftext];
    }
}
