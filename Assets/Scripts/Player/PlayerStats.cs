using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instancie;
    private void Awake()
    {
        if (instancie==null)
        {
            instancie = this;
        }
    }
    public float attack;
}
