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

    private string[] mainroadtext;
    private string[] secondtext;
    private string[] Deathtext;


    private string[] ShouText;

    int nummeroftext;




    public bool bottunMainRoad ;

    public bool secondaryRoad ;

    public bool DeathRoad ;

   

    private Button button;

    public string mainRoadTextLocalizationKey = "MainRoadText";
   private int mainroadcount;

    /*  public string[] mainRoadTextLocalizationKeys  ;

      public string mainRoadTextLocalizationKey = "MainRoadText";

      [SerializeField] private LocalizedStringDatabase StringDatabase = LocalizationSettings.StringDatabase ;
   */
    private void Start()
    {

        /* StringDatabase = LocalizationSettings.StringDatabase;

            mainroadtext[0] = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKey);


            for (int i = 0; i >= 10; i++)
            {
                mainroadtext[i] = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKeys[i]);


            }    
           */
        /*
        mainroadcount = rendervideocontroller.GetComponent<MainRoadFunk>().mainroadstep;

        for (int i = 0; i < mainroadcount; i++) 
        {
            mainRoadTextLocalizationKey = "" + mainroadcount;

            mainroadtext[i] = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKey);


        }
        */
           



                    mainroadtext = new string[10];
        Deathtext = new string[10];
        secondtext = new string[10];

        //

       //  mainroadtext[0] = LocalizationSettings.StringDatabase.GetLocalizedString(mainRoadTextLocalizationKey);

        mainroadtext[0] = "asda";
        mainroadtext[1] = "��� �� ������ ";

        mainroadtext[2] = "��� ���� �� ���";
        mainroadtext[3] = "�����";
        mainroadtext[4] = "��� ��� ����� � ����� ��� �������";
        mainroadtext[5] = "1";
        // 
        secondtext[0] = " ��� ���� �������";
        secondtext[1] = "��� �� �� ���������";

        secondtext[2] = "��� �� �� ��������";
        secondtext[3] = "�����";
        secondtext[4] = "� �������� �����";
        secondtext[5] = "2";
        //
        Deathtext[0] = "17:15";
       // Deathtext[1] = "�����";

        Deathtext[2] = "�� ���� ��������";
        Deathtext[3] = "������ � �����";
        Deathtext[4] = "��� ����� �� ����� �����";
        Deathtext[5] = "3";

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

