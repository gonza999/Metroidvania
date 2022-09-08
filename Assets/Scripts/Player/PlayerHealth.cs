using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public Image healthImage;
    public bool isInmune;
    public float inmunityTime;
    public Blink blink;
    public SpriteRenderer spriteRenderer;
    public float knockbackForceX;
    public float knockbackForceY;
    public Rigidbody2D rigidbody2D;
    public static PlayerHealth instancie;

    public GameObject GameOverImage;
    private void Awake()
    {
        if (instancie==null)
        {
            instancie = this;
        }
    }
    private void Start()
    {
        health = maxHealth;
        GameOverImage.SetActive(false);
        maxHealth = PlayerPrefs.GetFloat("MaxHealth", 100f);
    }

    private void Update()
    {
        healthImage.fillAmount = health / maxHealth;
        if (health>maxHealth)
        {
            health = maxHealth;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemy") && !isInmune)
        {
            StartCoroutine(Inmunity());
            health -= collision.transform.GetComponent<Enemy>().damage;
            AudioManager.instance.PlayAudio(AudioManager.instance.playerDamage);
            if (collision.transform.position.x>transform.position.x)
            {
                rigidbody2D.AddForce(new Vector2(-knockbackForceX,knockbackForceY),ForceMode2D.Force);
            }
            else
            {
                rigidbody2D.AddForce(new Vector2(knockbackForceX, knockbackForceY), ForceMode2D.Force);
            }

            if (health<=0)
            {
                AudioManager.instance.musicBackground.Stop();
                AudioManager.instance.PlayAudio(AudioManager.instance.playerDead);
                AudioManager.instance.PlayAudio(AudioManager.instance.playerDead);
                Destroy(gameObject,0.1f);
                //Time.timeScale = 0;
                GameOverImage.SetActive(true);
            }
        }
        
    }

    IEnumerator Inmunity()
    {
        isInmune = true;
        spriteRenderer.material = blink.blink;
        yield return new WaitForSeconds(inmunityTime);
        isInmune = false;
        spriteRenderer.material = blink.original;
    }
}
