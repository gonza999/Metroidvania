using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRespawn : MonoBehaviour
{
    public float timeToRespawn;
    public GameObject enemyToRespawn;
    public bool isRespawn;
    public IEnumerator RespawnEnemy()
    {
        enemyToRespawn.SetActive(false);
     
        yield return new WaitForSeconds(timeToRespawn);
        enemyToRespawn.GetComponent<Enemy>().healt =
         enemyToRespawn.GetComponent<EnemyHealth>().originalHealth;
        enemyToRespawn.GetComponent<SpriteRenderer>().material=
            enemyToRespawn.GetComponent<Blink>().original;
        enemyToRespawn.GetComponent<EnemyHealth>().isDamage = false ;

        enemyToRespawn.SetActive(true);

        yield return RespawnAnim();
    }

    IEnumerator RespawnAnim()
    {
        isRespawn = true;
        enemyToRespawn.GetComponent<Animator>().SetBool("Respawn",true);
        yield return new WaitForSeconds(0.4f);
        isRespawn = false;
        enemyToRespawn.GetComponent<Animator>().SetBool("Respawn", false);
    }
}
