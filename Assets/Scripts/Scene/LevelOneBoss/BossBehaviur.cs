using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossBehaviur : MonoBehaviour
{
    public Transform[] transforms;
    public GameObject flame;
    public float timeToShoot;
    public float timeCountDown;
    public float timeToTeleport;
    public float timeCountDownTeleport;

    public float currentHealth;
    public float maxHealth;
    public Image lifes;

    public void DamageBoss()
    {
        currentHealth = GetComponent<Enemy>().healt;
        lifes.fillAmount = currentHealth / maxHealth;
    }

    public void BossScale()
    {
        if (transform.position.x>PlayerController.instance.transform.position.x)
        {
            transform.localScale = new Vector3(-2,2,2);
        }
        else
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
    }
    private void Start()
    {
        Teleport();
        timeCountDown = timeToShoot;
        timeCountDownTeleport = timeToTeleport;
    }
    private void Update()
    {
        Countdown();
        DamageBoss();
        BossScale();
    }
    public void Countdown()
    {
        timeCountDown -= Time.deltaTime;
        timeCountDownTeleport -= Time.deltaTime;
        if (timeCountDown <= 0)
        {
            ShootPlayer();
            timeCountDown = timeToShoot;
        }
        if (timeCountDownTeleport <= 0)
        {
            Teleport();
            timeCountDownTeleport = timeToTeleport;
        }
    }
    public void ShootPlayer()
    {
        GameObject spell = Instantiate(flame, transform.position, Quaternion.identity);
    }

    public void Teleport()
    {
        var initialPos = Random.Range(0, transforms.Length);
        transform.position = transforms[initialPos].position;
    }

    private void OnDestroy()
    {
        BossUI.instancie.BossDesactivation();
    }
}
