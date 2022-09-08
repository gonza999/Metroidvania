using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class WeaponStats : MonoBehaviour
{
    float attack;
    float totalAttack;
    public float weaponAttack;
    public GameObject damageText;

    private void Start()
    {
        attack = PlayerStats.instancie.attack;
    }
    public float DamageInput(float defense,Transform hit)
    {
        GameObject textGO = Instantiate(damageText,hit.transform.position,Quaternion.identity);
        totalAttack = (attack + weaponAttack) * (100 / (100 + defense));
        float finalAttackPower = Mathf.Round(Random.Range(totalAttack-10,totalAttack+5));
        if (finalAttackPower>totalAttack+3)
        {
            finalAttackPower *= 1.5f;
            textGO.GetComponent<TextMeshPro>().SetText("CRITICAL!");
        }
        if (finalAttackPower<=0)
        {
            finalAttackPower = 0;
            textGO.GetComponent<TextMeshPro>().SetText("Missed!");
        }
        textGO.GetComponent<TextMeshPro>().SetText(textGO.GetComponent<TextMeshPro>().text+"\n"+ Mathf.Round(finalAttackPower).ToString());
        StartCoroutine(MoveText(textGO));
        return finalAttackPower;
    }

    IEnumerator MoveText(GameObject textGO)
    {
        Vector2 initial = textGO.transform.position;
        Vector2 final = new Vector2(textGO.transform.position.x,textGO.transform.position.y+10);
        int upTimes = 0;
        while (upTimes<6)
        {
            upTimes++;
            textGO.transform.position = Vector2.MoveTowards(initial,final,15f*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
