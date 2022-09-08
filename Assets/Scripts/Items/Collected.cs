using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collected : MonoBehaviour
{
    public float lances;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SubWeapons.instancie.SubWeapon(lances);
            Destroy(gameObject);
        }   
    }
}
