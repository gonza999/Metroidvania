using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICamera : MonoBehaviour
{
    public Transform player;
    public float xPos;
    public float yPos;
    public float zPos;

    private void Start()
    {
        transform.position = new Vector3(player.position.x+xPos,player.position.y+yPos,zPos);
    }
    private void Update()
    {
        transform.position = new Vector3(player.position.x + xPos, player.position.y + yPos, zPos);
    }
}
