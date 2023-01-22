using UnityEngine;

public class Wallet : MonoBehaviour
{
    private int _balance;

    private void Start()
    {
        _balance = PlayerPrefs.GetInt("balance");
    }

    public void IncreaseBalance()
    {
        PlayerPrefs.SetInt("balance", ++_balance);
    }
}
