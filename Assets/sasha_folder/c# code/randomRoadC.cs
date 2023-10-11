using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class randomRoadC : MonoBehaviour
{
    public bool[] randomroad = new bool[3];



    public Button[] allBT;

    private int it;
    void rrr()
    {
      it =  Random.Range(0, 3);





    }

}
