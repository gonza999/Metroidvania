using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    public Transform waypointA;
    public Transform waypointB;
    public float speed;
    public bool shouldMove;
    public bool shouldWait;
    public bool canContinue;
    public bool willDestroy;
    public float timeToDestroy;
    public float destroyCd;
    public float timeToWait;
    bool moveToA = true;
    bool moveToB = false;

    private void Start()
    {
        moveToA = true;
        moveToB = false;
        canContinue = true;
    }
    private void Update()
    {
        if (shouldMove)
        {
            MoveObject();
        }
    }
    private void MoveObject()
    {
        float distanceToA = Vector2.Distance(transform.position, waypointA.position);
        float distanceToB = Vector2.Distance(transform.position, waypointB.position);

        if (distanceToA > 0.1f && moveToA)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointA.position, speed * Time.deltaTime);
            if (distanceToA < 0.3f && canContinue)
            {
                if (shouldWait)
                {
                    StartCoroutine("Waiter");
                    moveToA = false;
                    moveToB = true;
                }
                else
                {
                    moveToA = false;
                    moveToB = true;
                }
              
            }
        }
        if (distanceToB > 0.1f && moveToB)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypointB.position, speed * Time.deltaTime);
            if (distanceToB < 0.3f && canContinue)
            {
                if (shouldWait)
                {
                    StartCoroutine("Waiter");
                    moveToA = true;
                    moveToB = false;
                }
                else
                {
                    moveToA = true;
                    moveToB = false;
                }

            }
        }
    }

    IEnumerator Waiter()
    {
        shouldWait = false;
        canContinue = false;
        yield return new WaitForSeconds(timeToWait);
        canContinue = true;
        shouldWait = true;
    }
}
