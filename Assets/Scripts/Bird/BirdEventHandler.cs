using UnityEngine;
using UnityEngine.Events;

public class BirdEventHandler : MonoBehaviour
{
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Bird _bird;
    public UnityAction PlayerDeath;
    public UnityAction GameRestart;
    public UnityAction<int> ScoreChanged;
    public States state { get; private set; }
    
    private void Start()
    {
        PlayerDeath += () =>
        {
            _bird.Die();
            _pipeGenerator.SetAllObjectsColliders(false);
            state = States.GAMEOVER;
        };
        GameRestart += () =>
        {
            _pipeGenerator.ResetPool();
            _pipeGenerator.SetAllObjectsColliders(true);
            state = States.GAMEPLAY;
        };
    }

    public enum States
    {
        GAMEPLAY,
        GAMEOVER,
        PAUSE
    }
}
