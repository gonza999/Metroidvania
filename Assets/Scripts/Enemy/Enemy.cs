using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string name;
    public float healt = 2;
    public float speed;
    public float knokcbackForceX;
    public float knokcbackForceY;
    public float damage;
    public float experience;
    public bool shouldRespawn;
    public float defense;
}
