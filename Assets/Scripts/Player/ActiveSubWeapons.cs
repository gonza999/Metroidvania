using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSubWeapons : MonoBehaviour
{
    public float subWeaponCost;
    public GameObject weapon;

    private void Update()
    {
        UseSubWeapon();
    }
    public void UseSubWeapon()
    {
        if (Input.GetButtonDown("Fire2") && subWeaponCost<=SubWeapons.instancie.subWeaponsCount)
        {
            SubWeapons.instancie.SubWeapon(-subWeaponCost);
            GameObject subWeapon = Instantiate(weapon,transform.position,Quaternion.Euler(0,0,45));
            subWeapon.GetComponent<Weapon>().playerPosX = transform.localScale.x;
            AudioManager.instance.PlayAudio(AudioManager.instance.arrow);

        }
    }
}
