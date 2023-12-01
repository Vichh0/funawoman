using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [Header("Horizontal Movement")]

    private float horizontalMovement = 0f;

    [SerializeField] private float movementSpeed;    
    [SerializeField] private float movementSmoothing;

    private Vector3 Speed = Vector3.zero;

    [Header("Vertical Movement")]

    [SerializeField] private float JumpForce;
    [SerializeField] private LayerMask WhatIsFloor;
    [SerializeField] private Transform FloorControler;

    [SerializeField] private Vector3 BoxDimensions;
    [SerializeField] private bool IsGrounded;
    [SerializeField] private bool canJump;

    [SerializeField] private float CoyoteTime;

    private float AirTime;

    private bool jump = false;

    [Header("Animation")]


    [Header("SceneStuff")]

    [SerializeField] private SceneManagement SceneManagement;
    [SerializeField] private string TargetScene;
    public int TargetName;

    private Rigidbody2D rb2D;
    private CapsuleCollider2D capsuleCollider;
    private Animator animator;
    private PlayerHookScript ph;

    private float baseCollide;
    private float baseCollPos;



    // Start is called before the first frame update
    private void Start()
    {     
        rb2D = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
        ph = GetComponent<PlayerHookScript>();

        baseCollide = capsuleCollider.size.y;
        baseCollPos = capsuleCollider.offset.y;
    }

    // Update is called once per frame
    private void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {    


        //Movement section

        IsGrounded = Physics2D.Raycast(transform.position, Vector3.down, .1f, WhatIsFloor);

        if (IsGrounded)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("IsFalling", false);
        }

        Debug.DrawRay(transform.position, Vector3.left * .1f, Color.magenta);

        if (!ph.hooked)
        {
            Move(horizontalMovement * Time.fixedDeltaTime, jump);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("IsCrouching", true);

            capsuleCollider.size = new Vector2(capsuleCollider.size.x, baseCollide / 2);
            capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, baseCollPos - baseCollide / 4);
            Debug.DrawRay(transform.position + Vector3.up * 3, Vector2.up * 3f, Color.magenta);
        }
        else
        {
            if (Physics2D.Raycast(transform.position + Vector3.up * 3, Vector2.up, 3f, WhatIsFloor))
            {

            }
            else
            { 
                capsuleCollider.size = new Vector2(capsuleCollider.size.x, baseCollide);
                capsuleCollider.offset = new Vector2(capsuleCollider.offset.x, baseCollPos);
                animator.SetBool("IsCrouching", false);
            }
        }


        jump = false;

        if (IsGrounded == true)
        {
            AirTime = 0f;
        }
        else
        {
            AirTime += Time.deltaTime;

            if(AirTime > CoyoteTime)
            {
                canJump = false;
            }
            else
            {
                canJump = true;
            }
        }

        //Animation section

        if (rb2D.velocity.y < 0 && IsGrounded == false)
        {
            animator.SetBool("IsFalling", true);
        }
        if (rb2D.velocity.y > 0 && IsGrounded == false)
        {
            animator.SetBool("IsJumping", true);
        }

        if (horizontalMovement == 0 && IsGrounded == true)
        {
            animator.SetBool("IsRunning", false);
        }

        if (horizontalMovement != 0 && IsGrounded == true)
        {
            animator.SetBool("IsRunning", true);
        }
    }

    private void Move(float move, bool Jump)
    {
        Vector3 TargetVelocity = new Vector2(move, rb2D.velocity.y);

        rb2D.velocity = Vector3.SmoothDamp(rb2D.velocity, TargetVelocity, ref Speed, movementSmoothing);

        if (Mathf.Sign(move) < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(move == 0)
        {

        }
        else if (Mathf.Sign(move) > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (Jump)
        {
            if (IsGrounded)
            {
                IsGrounded = false;
                canJump = false;
                rb2D.AddForce(new Vector2(0f, JumpForce));
            }
            else if(AirTime < CoyoteTime && canJump)
            {
                canJump = false;
                rb2D.AddForce(new Vector2(0f, JumpForce));
            }           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "HidingWall")
        {
            this.tag = "HidingPlayer";
            this.gameObject.layer = 9;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "HidingWall")
        {
            this.tag = "Player";
            this.gameObject.layer = 7;
        }
    }

}
