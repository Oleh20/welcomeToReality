using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musikController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;


    private bool musikOf;
    AudioSource music;
    private void Start()
    {
        musikOf = player.GetComponent<MainRoadFunk>().MusikPlayLaut;

        music = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
      if (musikOf) { music.volume = 0; }else { music.volume = 0.1f; }



    }



}
