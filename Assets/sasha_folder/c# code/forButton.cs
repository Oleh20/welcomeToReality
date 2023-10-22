using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

public class forButton : MonoBehaviour
{
    public GameObject rendervideocontroller;

    [SerializeField]
    private GameObject canvas;

    private string[] mainroadtext;
    private string[] secondtext;
    private string[] Deathtext;


    private string[] ShouText;

    int nummeroftext;


    public bool a = false;
    public bool b = false;
    public bool c = false;

 

   

    private Button button;

    public string mainRoadTextLocalizationKey ;

    public bool[] roadChoice = new bool[3];

    static string[] whichroad;
  


    private void Start()
    {

           



        mainroadtext = new string[10];
        Deathtext = new string[10];
        secondtext = new string[10];

        
       button = GetComponent<Button>();


        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[1];
       
        MadeCurenttRoad();

        texttransleter();
        SetTextForRoad();



        // button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);
        // button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad)  ;
        // button.onClick.AddListener(rendervideocontroller.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath);

    }
    
    public void MadeCurenttRoad()
    {
        

        deleteLastRoad();

      



        if (a) //0
        {


            button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad);

        }
       if (b)// 1
        {
            button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);

        }
       if  (c) 
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

    void texttransleter()
    {

        for (int i = 0; i < 10; i++)
        {
            string deathway;
            string secondway;

            mainRoadTextLocalizationKey = i+ " Textmain" ;
            deathway= i + " Textdeath";
            secondway = i + " Textsecond";

            mainroadtext[i] = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKey);
            Deathtext[i] = LocalizationSettings.StringDatabase.GetLocalizedString(deathway);
            secondtext[i]= LocalizationSettings.StringDatabase.GetLocalizedString(secondway);

     
        }


    }


    private void Update()
    {
        
      
       // SetTextForRoad();
     
        
    }
     public void SetTextForRoad()
    {
        MadeCurenttRoad();
        nummeroftext = rendervideocontroller.GetComponent<MainRoadFunk>().mainroadstep;
        ShouText = whatfortextyouneed();


        gameObject.GetComponentInChildren<Text>().text = ShouText[nummeroftext];

     
       MakeButtonOff();


    }
     string[] whatfortextyouneed()
    {
        if (a) { ShouText = mainroadtext; }
        if (b) { ShouText = secondtext; }
        if (c) { ShouText = Deathtext; }

     

        return ShouText;
    }
    public void MakeButtonOff()
    {
        if (gameObject.GetComponentInChildren<Text>().text == "No translation found for '' in UI Text" || gameObject.GetComponentInChildren<Text>().text == null) { button.gameObject.SetActive(false);  }
       


    }
    public void buttonIsActiv() { button.gameObject.SetActive(true); }
}

