using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform floorController;
    [SerializeField] private float distance;

    [SerializeField] private bool movingRight;

    private Rigidbody2D rb;
    private Collider2D col;

    private void Start()
    {
        floorController = gameObject.GetComponentInChildren<Transform>();
        col = GetComponent<Collider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        bool floorInfo;

        if (Physics2D.Raycast(floorController.position + Vector3.down * distance, Vector2.down, 0.1f))
        {
            floorInfo = true;
        }
        else
        {
            floorInfo = false;
        }

        Debug.DrawLine(floorController.position, floorController.position + Vector3.down * distance, Color.white);

        rb.velocity = new Vector2(speed, rb.velocity.y);

        if (!floorInfo)
        {
            movingRight = !movingRight;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
            speed *= -1;
            floorInfo = true;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawLine(floorController.transform.position, floorController.transform.position + Vector3.down * distance);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene(4);
        }
        else
        {
            if (collision.transform.position.y > transform.position.y)
            {
                movingRight = !movingRight;
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
                speed *= -1;
            }
        }

    }
}
