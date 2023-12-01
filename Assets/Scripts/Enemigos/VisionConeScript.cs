using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class VisionConeScript : MonoBehaviour
{
    [SerializeField] private TimerScript ts;
    
    private SpriteRenderer sr;

    private AudioSource aS;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {     
        //Si el timer de deteccion es 0, volver al color base
        if(ts.getTimer() <= 0)
        {
            sr.color = Color.white;
        }      
    }

    private void OnTriggerStay2D(Collider2D other)
    {  
        //Si ve al jugador, cambiar color a rojo y aumentar el timer de detección
        if (other.CompareTag("Player"))
        {
            if(ts.getTimer() == 0)
            {
                other.gameObject.GetComponent<AudioSource>().Play();
            }

            ts.addTimer(Time.deltaTime);        
            sr.color = Color.red;
        }
    }
}