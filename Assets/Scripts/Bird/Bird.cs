using UnityEngine;

[RequireComponent(typeof(BirdMover))]
[RequireComponent(typeof(BirdEventHandler))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private BirdEventHandler _eventHandler;
    private int _score;
    void Start()
    {
        
        _eventHandler = GetComponent<BirdEventHandler>();
        _mover = GetComponent<BirdMover>();
        _eventHandler.GameRestart += ResetPlayer;

        _eventHandler.GamePaused += () =>
        {
            _mover.SaveSpeedAndStop();
        };
        _eventHandler.GameResumed += () =>
        {
            _mover.RestoreSpeed();
        };
    }

    private void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;
        _eventHandler.ScoreChanged?.Invoke(_score);
    }

    public void PickUpMoney()
    {
        _eventHandler.PickedUpCoin?.Invoke();
        Wallet.Instance.IncreaseBalance();
    }
    public void IncreaseScore()
    {
        _score++;
        _eventHandler.ScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        _mover.ResetVelocity();
    }
}
