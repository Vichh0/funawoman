using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class VisionConeScript : MonoBehaviour
{
    public SceneManagement SceneManagement;

    public Collider2D VisionConeCollider;

    private SpriteRenderer sr;

    public TimerScript ts;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        
        if(ts.getTimer() <= 0)
        {
            sr.color = Color.white;
        }
          
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("HidingWall"))
        {
            Physics2D.IgnoreCollision(VisionConeCollider , other);
        }

        if (other.CompareTag("Player"))
        {
            ts.addTimer(Time.deltaTime);        
            sr.color = Color.red;
        }
      

    }

}
