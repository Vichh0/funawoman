using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    [SerializeField] private objecttarget mt;

    private float top;
    private float bot;

    private float updown;

    private void Start()
    {
        //Envia una señal por cada coleccionable para saber cuantos hay en el nivel
        mt.setmax();

        bot = transform.position.y;
        top = bot + 1;

        updown = 1.5f;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime * updown, transform.position.z);

        if(transform.position.y > top)
        {
            updown = -1.5f;
        }

        if(transform.position.y < bot)
        {
            updown = 1.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //Envia una señal por cada coleccionable recogido y se destruye
        if(other.CompareTag("Player"))
        {
            mt.addactual();
            Destroy(this.gameObject);
        }
    }
}
