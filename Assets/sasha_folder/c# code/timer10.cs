using System;
using UnityEngine;
using UnityEngine.UI;

public class timer10 : MonoBehaviour
{
    public float countdown = 10f;
    private bool timerActive = false;

   public  GameObject player;

    private void Start()
    {
      // player.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath();
    }

    private void Update()
    {
        if (!timerActive) { gameObject.SetActive(false); } else { gameObject.SetActive(true); }

        if (timerActive)
        {
            countdown -= Time.deltaTime;
            gameObject.GetComponentInChildren<Text>().text = Mathf.Ceil(countdown).ToString(); 

           // Debug.Log("Countdown: " + Mathf.Ceil(countdown));

            if (countdown <= 0)
            {
               
               // Debug.Log("Countdown completed!");
                OnCountdownCompleted();

                timerActive = false;
            }
        }
    }

   

     void OnCountdownCompleted()
    {



        player.GetComponent<DeathAfterVideo>().PlayONLYoneTimeandDeath();
      //  CountdownCompleted?.Invoke();
       
    }
    public void maketimeractiv()
    {
      
        countdown = 10f;
    
    timerActive = true;

    }
   
}
