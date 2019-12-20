using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    public Text walletValue;

    private void Awake()
    {
        walletValue.text = "" + PlayerPrefs.GetInt("Wallet", 0).ToString();
    }

    public void AddCurrency()
    {
        walletValue.text = "" + PlayerPrefs.GetInt("Wallet").ToString();
    }
}