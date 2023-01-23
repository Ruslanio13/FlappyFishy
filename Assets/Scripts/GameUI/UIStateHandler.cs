using TMPro;
using UnityEngine;

public class UIStateHandler : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private GameObject _pauseWindow;
    [SerializeField] private GameObject _gameOverWindow;
    [SerializeField] private GameObject[] _gameplayElements;
    [SerializeField] private TMP_Text balanceText;
    private void Start()
    {
        eventHandler.PlayerDeath += () =>
        {
            SetGameplayElementsActive(false);
            
            SetGameOverWindowActive(true);
        };
        
        eventHandler.GameRestart += () =>
        {
            SetGameOverWindowActive(false);
            SetPauseWindowActive(false);
            
            SetGameplayElementsActive(true);
            
            UpdateBalance();
        };
        
        eventHandler.GamePaused += () =>
        {
            SetGameplayElementsActive(false);
            
            SetPauseWindowActive(true);
        };
        
        eventHandler.GameResumed += () =>
        {
            SetPauseWindowActive(false);
            
            SetGameplayElementsActive(true);
        };

        Wallet.Instance.BalanceChanged += UpdateBalance;

    }

    private void SetGameplayElementsActive(bool isActive)
    {
        foreach (var element in _gameplayElements)
        {
            element.SetActive(isActive);
        }
    }
    
    private void SetPauseWindowActive(bool isActive)
    {
        _pauseWindow.SetActive(isActive);
    }

    private void SetGameOverWindowActive(bool isActive)
    {
        _gameOverWindow.SetActive(isActive);
    }

    private void UpdateBalance()
    {
        balanceText.text = Wallet.Instance.Balance.ToString();
    }
}
