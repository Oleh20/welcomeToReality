using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class forButton : MonoBehaviour
{
    public GameObject rendervideocontroller;

    private string[] mainroadtext;
    private string[] secondtext;
    private string[] Deathtext;


    private string[] ShouText;

    int nummeroftext;




    public bool bottunMainRoad ;

    public bool secondaryRoad ;

    public bool DeathRoad ;

   

    private Button button;
    private void Start()
    {
        mainroadtext = new string[5];
        Deathtext = new string[5];
        secondtext = new string[5];

        //
        mainroadtext[0] = "Важка, велів би бути вдома";
        mainroadtext[1] = "Так ми повинні ";
        mainroadtext[2] = "так само як вас";
        mainroadtext[3] = "файно";
        mainroadtext[4] = "так для цього я приніс цей диплома";
        // 
        secondtext[0] = " Час тебе знищити";
        secondtext[1] = "вас це не стосується";
        secondtext[2] = "гамно";
        secondtext[3] = "";
        secondtext[4] = "";
        //
        Deathtext[0] = "17:15";
       // Deathtext[1] = "не ебу что тут нужно";
        Deathtext[2] = "бувало й краще";
        Deathtext[3] = "";
        Deathtext[4] = "";


        button = GetComponent<Button>();

       MadeCurenttRoad();





        // button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);
        // button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad)  ;
        // button.onClick.AddListener(rendervideocontroller.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath);

    }
    
    public void MadeCurenttRoad()
    {
        deleteLastRoad();
      
        if (bottunMainRoad)
        {


            button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad);

        }
        if (secondaryRoad)
        {
            button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);

        }
        if (DeathRoad)
        {
            button.onClick.AddListener(rendervideocontroller.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath);

        }
    }
    void deleteLastRoad()
    {

    button.onClick.RemoveAllListeners();
    
    }
   /// <summary>
   /// //////////////////////////////////////////////////////////////////////////
   /// </summary> text cod ruslan you can make it all delit
   /// 


    private void Update()
    {
       

        
        SetTextForRoad();
        
    }
    public void SetTextForRoad()
    {
        nummeroftext = rendervideocontroller.GetComponent<MainRoadFunk>().mainroadstep;
        ShouText = whatfortextyouneed();


        gameObject.GetComponentInChildren<Text>().text = ShouText[nummeroftext];

        MakeButtonOff();


    }
     string[] whatfortextyouneed()
    {
        if (bottunMainRoad) { ShouText = mainroadtext; }
        if (secondaryRoad) { ShouText = secondtext; }
        if (DeathRoad) { ShouText = Deathtext; }

        if (ShouText == null) { Debug.Log("you lost text in c# forButton"); }

        return ShouText;
    }
    public void MakeButtonOff()
    {
        if (gameObject.GetComponentInChildren<Text>().text == "") { button.gameObject.SetActive(false); Debug.Log("button is off"); }

        
    }
    public void buttonIsActiv() { button.gameObject.SetActive(true); }
}

