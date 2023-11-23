using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private objecttarget mt;

    private void Start()
    {
        //Envia una señal por cada coleccionable para saber cuantos hay en el nivel
        mt.setmax();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Envia una señal por cada coleccionable recogido y se destruye
        if(other.CompareTag("Player"))
        {
            mt.addactual();
            Destroy(gameObject);
        }
    }
}
