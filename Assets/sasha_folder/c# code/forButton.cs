using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forButton : MonoBehaviour
{
    public bool ItActiv;

    public bool bottunMainRoad;




    public void Random()
    {

    }
    private void FixedUpdate()
    {
        if (ItActiv)
        {
           this.gameObject.SetActive(true);
        }
        else { this.gameObject.SetActive(false); }
    }
    
   
}
