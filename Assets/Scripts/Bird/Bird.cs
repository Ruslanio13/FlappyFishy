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
        _eventHandler.OnRestart += ResetPlayer;
    }

    private void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;
    }
    
}
