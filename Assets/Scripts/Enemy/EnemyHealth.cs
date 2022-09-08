using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public Enemy enemy;
    public bool isDamage;
    public GameObject deathEffect;
    public SpriteRenderer spriteRenderer;
    public Blink blink;
    public Rigidbody2D rigidbody2D;
    public float originalHealth;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon") && !isDamage)
        {
            //enemy.healt -= 2f;
            enemy.healt -= collision.GetComponent<WeaponStats>().DamageInput(enemy.defense,enemy.transform);
            AudioManager.instance.PlayAudio(AudioManager.instance.hit);
            if (collision.transform.position.x<transform.position.x)
            {
                rigidbody2D.AddForce(new Vector2(enemy.knokcbackForceX,enemy.knokcbackForceY),ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(-enemy.knokcbackForceX, enemy.knokcbackForceY), ForceMode2D.Force);
            }
            StartCoroutine(Damager());
            if (enemy.healt <= 0)
            {
                Instantiate(deathEffect,transform.position,Quaternion.identity);
                Experience.instancie.ExpModifier(GetComponent<Enemy>().experience);
                AudioManager.instance.PlayAudio(AudioManager.instance.enemyDead);
                if (enemy.shouldRespawn)
                {
                    transform.GetComponentInParent<EnemyRespawn>().StartCoroutine(transform.
                        GetComponentInParent<EnemyRespawn>().RespawnEnemy());
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    IEnumerator Damager()
    {
        isDamage = true;
        spriteRenderer.material = blink.blink;
        yield return new WaitForSeconds(0.5f);
        isDamage = false;
        spriteRenderer.material = blink.original;
    }
}
