using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHookScript : MonoBehaviour
{
    private CapsuleCollider2D capsuleCollider;
    private Rigidbody2D rb;
    private RaycastHit2D rh;
    private Animator animator;

    public bool hooked = false;
    private float baseCollide;
    private float baseCollPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();

        baseCollide = capsuleCollider.size.y;
        baseCollPos = capsuleCollider.offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawLine(transform.position + Vector3.up * 4.3f, transform.position + Vector3.up * 5f, Color.red);
        
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            if (!hooked)
            {
                if(rh = Physics2D.Raycast(transform.position + Vector3.up * 6f, Vector2.up, 3f))
                {

                    if(rh.collider.tag == "Hookable")
                    {
                        hooked = true;
                        rb.velocity = Vector3.zero;

                        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                    }   
                }
            }
            else
            {
                capsuleCollider.size = new Vector2(capsuleCollider.size.x, baseCollide);
                capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, baseCollPos);
                hooked = false;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }

        if (hooked)
        {
            rh = Physics2D.Raycast(transform.position + Vector3.up * 6f, Vector2.up, 3f);

            animator.SetBool("IsHooked", true);

            if (rh.collider.tag == "Hookable")
            {
                float posY = rh.transform.position.y - Mathf.Abs(rh.collider.bounds.extents.y) - baseCollide;

                this.transform.position = new Vector3(rh.transform.position.x, posY, transform.position.z);
                capsuleCollider.size = new Vector2(capsuleCollider.size.x, baseCollide / 2);
                capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, baseCollPos - baseCollide / 8);
            }
        }
        else
        {
            animator.SetBool("IsHooked", false);
            
        }
    }
}
