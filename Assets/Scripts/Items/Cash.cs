using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cash : MonoBehaviour
{
    public float cash;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            AudioManager.instance.PlayAudio(AudioManager.instance.money);
            BankAcount.instancie.Money(cash);
            Destroy(gameObject);
        }
    }
}
