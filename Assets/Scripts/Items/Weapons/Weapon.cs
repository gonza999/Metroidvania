using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidbody2D;
    public float playerPosX;

    private void Start()
    {
        Destroy(gameObject,1f);
    }
    void Update()
    {
        if (playerPosX > 0)
        {
            transform.localScale = new Vector2(-1, -1);
            rigidbody2D.velocity = new Vector2(speed, rigidbody2D.velocity.y);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
            rigidbody2D.velocity = new Vector2(-speed, rigidbody2D.velocity.y);
        }

    }
}
