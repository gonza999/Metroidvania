using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    public GameObject boss;
    float speedPlayer;
    private void Start()
    {
        boss.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            BossUI.instancie.BossActivation();

            StartCoroutine(WaitForBoss());
        }
    }

    IEnumerator WaitForBoss()
    {
        var velocity = PlayerController.instance.speed;
        //PlayerController.instance.speed=0;
        boss.SetActive(true);
        yield return new WaitForSeconds(3f);
        PlayerController.instance.speed = velocity;
        Destroy(gameObject);
    }
}
