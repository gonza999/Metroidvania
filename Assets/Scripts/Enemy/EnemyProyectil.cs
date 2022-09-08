using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float timetToShoot;
    public float shootCoolDown;

    public bool isShooter;
    public bool isWatcher;

    private void Start()
    {
        shootCoolDown = timetToShoot;
    }
    private void Update()
    {
        if (isShooter)
        {
            shootCoolDown -= Time.deltaTime;
            if (shootCoolDown < 0)
            {
                Shoot();
            }
        }

        if (isWatcher)
        {

        }
    }
    public void Shoot()
    {
        
            GameObject cross = Instantiate(proyectil, transform.position, Quaternion.identity);
            if (transform.localScale.x < 0)
            {
                cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(300f, 0f), ForceMode2D.Force);
            }
            else
            {
                cross.GetComponent<Rigidbody2D>().AddForce(new Vector2(-300f, 0f), ForceMode2D.Force);
            }
            shootCoolDown = timetToShoot;
            Destroy(cross,1f);
        
    }
}
