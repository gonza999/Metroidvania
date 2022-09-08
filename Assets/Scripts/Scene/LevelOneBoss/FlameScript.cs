using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameScript : MonoBehaviour
{
    float moveSpeed;
    public Rigidbody2D rigidbody2D;
    Vector2 moveDirection;
    PlayerController target;

    private void Start()
    {
        AudioManager.instance.PlayAudio(AudioManager.instance.fire);
        moveSpeed = GetComponent<Enemy>().speed;
        target = PlayerController.instance;
        moveDirection = (target.transform.position - transform.position).normalized * moveSpeed;
        rigidbody2D.velocity = new Vector2(moveDirection.x,moveDirection.y);
    }
}
