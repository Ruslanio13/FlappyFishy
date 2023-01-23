using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIBalanceHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text balanceText;

    public void Start()
    {
        UpdateBalance();
        Wallet.Instance.BalanceChanged += UpdateBalance;
    }

    public void UpdateBalance()
    {
        balanceText.text = Wallet.Instance.Balance.ToString();
    }
}

