using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubWeapons : MonoBehaviour
{
    public Text subWeaponText;
    public float subWeaponsCount;
    public float subweaponsMax;

    public static SubWeapons instancie=null;

    private void Awake()
    {
        if (instancie == null)
        {
            instancie = this;
        }
    }
    private void Start()
    {
        subWeaponsCount = PlayerPrefs.GetFloat("SubWeaponsCount",0);
        subweaponsMax = PlayerPrefs.GetFloat("SubweaponsMax", 10);
        subWeaponText.text = subWeaponsCount.ToString();
    }
    private void Update()
    {
        subWeaponText.text = subWeaponsCount.ToString();
    }

    public void SubWeapon(float subWeapon)
    {
        subWeaponsCount += subWeapon;
        if (subWeaponsCount>=subweaponsMax)
        {
            subWeaponsCount = subweaponsMax;
        }
        DataManager.instance.SubWeaponsCountData(subWeaponsCount);
        subWeaponsCount = PlayerPrefs.GetFloat("SubWeaponsCount");

    }
}
