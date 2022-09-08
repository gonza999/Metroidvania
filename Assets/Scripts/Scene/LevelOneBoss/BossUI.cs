using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    public GameObject bossPanel;
    public GameObject wallsBoss;

    public static BossUI instancie;
    private void Awake()
    {
        if (instancie==null)
        {
            instancie = this;
        }
    }
    private void Start()
    {
        bossPanel.SetActive(false);
        wallsBoss.SetActive(false);
    }

    public void BossActivation()
    {
        bossPanel.SetActive(true);
        wallsBoss.SetActive(true);
    }

    public void BossDesactivation()
    {
        bossPanel.SetActive(false);
        wallsBoss.SetActive(false);
        StartCoroutine(BossDefeat());
    }

    IEnumerator BossDefeat()
    {
        var velocity = PlayerController.instance.GetComponent<Rigidbody2D>().velocity;
        Vector2 originalSpeed = velocity;
        velocity = new Vector2(0, velocity.y);
        PlayerController.instance.enabled = false;
        yield return new WaitForSeconds(2f);
        PlayerController.instance.enabled = true;
        velocity = originalSpeed;
    }
}
