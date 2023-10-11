using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class forButton : MonoBehaviour
{
    public GameObject rendervideocontroller;

     public string[] mainroadtext;
    public string[] secondtext;
    public string[] Deathtext;
    private string[] ShouText;

    int nummeroftext;

    private bool ItActiv = true;

    
    public bool bottunMainRoad;

    public bool secondaryRoad;

    public bool DeathRoad;

    static private bool[] RandomRoad;

    private Button button;
    private void Start()
    {

        button = GetComponent<Button>();

        MadeCurenttRoad();





        // button.onClick.AddListener(rendervideocontroller.GetComponent<secondaryRoad>().OtherWay);
        // button.onClick.AddListener(rendervideocontroller.GetComponent<MainRoadFunk>().MainRoad)  ;
        // button.onClick.AddListener(rendervideocontroller.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath);

    }
    
    void MadeCurenttRoad()
    {
        // установил кнопку на определенный путь а значит это а хуй его знает что это значит блять 
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
        SetTextForRoad();
        
    }
    public void SetTextForRoad()
    {//установка текста на кнопку в зависимости от выбора 

        ShouText = whatfortextyouneed();


        gameObject.GetComponentInChildren<Text>().text = ShouText[nummeroftext];



    }
     string[] whatfortextyouneed()
    {// выбор текста который будет отображаться в зависимости от функции на кнопке
        if (bottunMainRoad) { ShouText = mainroadtext; }
        if (secondaryRoad) { ShouText = secondtext; }
        if (DeathRoad) { ShouText = Deathtext; }

        if(ShouText == null) { Debug.Log("you lost text in c# forButton");  }

        return ShouText;
    }
}
