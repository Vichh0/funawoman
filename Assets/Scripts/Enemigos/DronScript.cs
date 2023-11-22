using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DronScript : MonoBehaviour
{
    public float leftBorder;
    public float rightBorder;

    public float speed;

    private Rigidbody2D rb;
    public Collider2D col;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();

        speed *= -1;

        leftBorder = transform.position.x - leftBorder;
        rightBorder = transform.position.x + rightBorder;
    }

    // Update is called once per frame
    void Update()
    {
        if (speed > 0)
        {
            if (transform.position.x < rightBorder)
            {
                rb.velocity = new Vector2 (speed, rb.velocity.y);
            }
            else
            {
                speed*= -1;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }
        else
        {
            if (transform.position.x > leftBorder)
            {
                rb.velocity = new Vector2(speed, rb.velocity.y);
            }
            else
            {
                speed*= -1;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            }
        }

    }
}
