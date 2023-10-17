using System;
using UnityEngine;

public class timer10 : MonoBehaviour
{
    private float countdown = 10f;
    public bool timerActive = true;

    private void Update()
    {
        if (timerActive)
        {
            countdown -= Time.deltaTime;
            Debug.Log("Countdown: " + Mathf.Ceil(countdown));

            if (countdown <= 0)
            {
                timerActive = false;
               // Debug.Log("Countdown completed!");
                OnCountdownCompleted();
            }
        }
    }

    public event Action CountdownCompleted;

    protected virtual void OnCountdownCompleted()
    {
        CountdownCompleted?.Invoke();
    }

}
