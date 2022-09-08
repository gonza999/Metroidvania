using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    public Rigidbody2D rigidbody2D;
    public bool isStatic;
    public bool isWalking;
    public bool isPatrol;
    public bool shouldWait;
    public float timeToWait;
    bool isWaiting;
    bool walksRight;
    public Animator animator;

    public Transform wallCheck;
    public Transform pillCheck;
    public Transform groundCheck;
    public bool wallDetected;
    public bool pillDetected;
    public bool isGround;
    public float detectionRadius;
    public LayerMask whatIsGround;

    public Transform waypoint1;
    public Transform waypoint2;
    bool goTo1;
    bool goTo2;

    private void Start()
    {
        goTo2 = true;
        speed = transform.GetComponent<Enemy>().speed;

    }
    private void Update()
    {
        pillDetected = !Physics2D.OverlapCircle(pillCheck.position, detectionRadius, whatIsGround);
        wallDetected = Physics2D.OverlapCircle(wallCheck.position, detectionRadius, whatIsGround);
        isGround = Physics2D.OverlapCircle(groundCheck.position, detectionRadius, whatIsGround);
        if ((pillDetected || wallDetected) && isGround)
        {
            Flip();
        }
    }

    private void Flip()
    {
        walksRight = !walksRight;
        transform.localScale *= new Vector2(-1, transform.localScale.y);
    }

    private void FixedUpdate()
    {
        if (isStatic)
        {
            animator.SetBool("Idle", true);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        if (isWalking)
        {
            animator.SetBool("Idle", false);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!walksRight)
            {
                rigidbody2D.velocity = new Vector2(-speed * Time.deltaTime, rigidbody2D.velocity.y);
            }
            else
            {
                rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, rigidbody2D.velocity.y);
            }
        }
        if (isPatrol)
        {
            if (goTo1)
            {
                if (!isWaiting)
                {
                    animator.SetBool("Idle", false);
                    rigidbody2D.velocity = new Vector2(speed * Time.deltaTime, rigidbody2D.velocity.y);
                }
                if (Vector2.Distance(transform.position, waypoint1.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    goTo1 = false;
                    goTo2 = true;
                    Flip();
                }
            }
            if (goTo2)
            {
                if (!isWaiting)
                {
                    animator.SetBool("Idle", false);
                    rigidbody2D.velocity = new Vector2(-speed * Time.deltaTime, rigidbody2D.velocity.y);
                }
                if (Vector2.Distance(transform.position, waypoint2.position) < 0.2f)
                {
                    if (shouldWait)
                    {
                        StartCoroutine(Waiting());
                    }
                    goTo2 = false;
                    goTo1 = true;
                    Flip();
                }
            }
        }
        IEnumerator Waiting()
        {
            animator.SetBool("Idle", true);
            isWaiting = true;
            Flip();
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeAll;
            yield return new WaitForSeconds(timeToWait);
            animator.SetBool("Idle", false);
            rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            Flip();
            isWaiting = false;
        }
    }
}
