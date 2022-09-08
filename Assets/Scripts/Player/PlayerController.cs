using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;

    float speedX;
    float speedY;
    public Rigidbody2D rigidbody2D;
    public Transform groundCheck;
    public bool isGround;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public Animator animator;
    public static PlayerController instance;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,groundCheckRadius,whatIsGround);
        if (isGround)
        {
            animator.SetBool("Jump", false);
        }
        else
        {
            animator.SetBool("Jump", true);
        }
        FlipPlayer();
        Atack();

    }
    private void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Atack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("Attack", true);
        }
        else
        {
            animator.SetBool("Attack", false);
        }
    }
    void Jump()
    {
        if (Input.GetButton("Jump") && isGround)
        {
            Atack();
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x,jump);
        }
    }
    void FlipPlayer()
    {
        if (rigidbody2D.velocity.x > 0)
        {
            transform.localScale=new Vector3(1,transform.localScale.y,transform.localScale.z);
        }
        else if (rigidbody2D.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = transform.localScale;
        }

    }
    void Movement()
    {
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = rigidbody2D.velocity.y;

        rigidbody2D.velocity = new Vector2(speedX * speed, speedY);
        if (rigidbody2D.velocity.x != 0)
        {
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
    }
}
