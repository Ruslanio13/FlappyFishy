using UnityEngine;
using UnityEngine.UI;

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
    }

    private void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;
        _eventHandler.ScoreChanged?.Invoke(_score);
    }

    public void IncreaseScore()
    {
        _score++;
        _eventHandler.ScoreChanged?.Invoke(_score);
    }
}
