using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronScript : MonoBehaviour
{
    [SerializeField] private float leftBorder;
    [SerializeField] private float rightBorder;

    private float speed;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        speed = -4f * transform.localScale.x;

        leftBorder = transform.position.x - leftBorder;
        rightBorder = transform.position.x + rightBorder;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
            //Avanza
        if (transform.position.x <= rightBorder && transform.position.x >= leftBorder)
        {
            rb.velocity = new Vector2 (speed, rb.velocity.y);
        }
        else
        {
            //Si llega al limite, gira
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            speed *= -1;
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
    }
}
