using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Si no hay piso, gira
        if (!Physics2D.Raycast(transform.position + Vector3.down * 2.5f, Vector2.down, 0.1f))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            speed *= -1;
        }

        //Avanza
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si toca jugador, acabar juego
        if (collision.collider.tag == "Player")
        {
            SceneManager.LoadScene("DefeatScene");
        }
        else
        {
            //Si toca algo que no es jugador, gira
            if (collision.collider.tag == "Wall" || (collision.collider.tag == "Plat" && Physics2D.Raycast(transform.position + Vector3.down * 2.5f, Vector2.down, 0.1f).collider.tag != "Plat") || collision.gameObject.layer == 6)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                speed *= -1;
            }
        }
    }
}