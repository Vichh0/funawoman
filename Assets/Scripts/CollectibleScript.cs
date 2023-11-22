using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public objecttarget mt;

    private void Start()
    {
        mt.setmax();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            mt.addactual();
            Destroy(gameObject);
        }
    }
}
