using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookScript : MonoBehaviour
{
    private CapsuleCollider2D capu;
    private Rigidbody2D rb;
    private RaycastHit2D rh;

    public bool hooked = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capu = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Physics2D.Raycast(transform.position + Vector3.up * 6f, Vector2.up, 3f))
        {
            rh = Physics2D.Raycast(transform.position + Vector3.up * 6f, Vector2.up, 3f);
        }

        Debug.DrawLine(transform.position + Vector3.up * 6f, transform.position + Vector3.up * 9f, Color.red);
        
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if (!hooked)
            {
                if(Physics2D.Raycast(transform.position + Vector3.up * 6f, Vector2.up, 3f))
                {

                    Debug.Log("hooking");

                    hooked = true;
                    rb.velocity = Vector3.zero;

                    rb.constraints = RigidbodyConstraints2D.FreezePositionY|RigidbodyConstraints2D.FreezeRotation;
                }
            }
            else
            {
                hooked = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        if (hooked)
        {
            if(rh.collider.tag == "Hookable")
            {
                float posY = rh.transform.position.y - Mathf.Abs(rh.collider.bounds.extents.y) - capu.size.y;

                this.transform.position = new Vector3(rh.transform.position.x, posY, transform.position.z);
            }
        }

    }
}
