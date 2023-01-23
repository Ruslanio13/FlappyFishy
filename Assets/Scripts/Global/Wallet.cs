using UnityEngine;
using UnityEngine.Events;


public class Wallet : MonoBehaviour
{
    public static Wallet Instance;
    public UnityAction BalanceChanged;

    private void Awake()
    {
        
        if (Instance == null || Instance == this)
            Instance = this;
        else
            Destroy(gameObject);
        
        DontDestroyOnLoad(this);
    }

    public int Balance { get; private set; }

    private void Start()
    {
        DontDestroyOnLoad(this);
        Balance = PlayerPrefs.GetInt("balance");
    }

    public void IncreaseBalance()
    {
        PlayerPrefs.SetInt("balance", ++Balance);
        BalanceChanged.Invoke();
    }

    public void DecreaseBalance(int amount)
    {
        Balance -= amount;
        PlayerPrefs.SetInt("balance", Balance);
        BalanceChanged.Invoke();
    }
}
