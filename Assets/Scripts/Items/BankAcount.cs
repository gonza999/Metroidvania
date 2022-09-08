using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankAcount : MonoBehaviour
{
    public float bank;

    public static BankAcount instancie;
    public Text cashText;

    private void Awake()
    {
        if (instancie==null)
        {
            instancie = this;
        }
    }

    private void Start()
    {
        bank = PlayerPrefs.GetFloat("Bank",0);
    }
    private void Update()
    {
        cashText.text =$"x{bank.ToString()}";
    }
    public void Money(float cash)
    {
        bank += cash;
        DataManager.instance.BankData(bank);
        bank = PlayerPrefs.GetFloat("Bank");
    }
}
