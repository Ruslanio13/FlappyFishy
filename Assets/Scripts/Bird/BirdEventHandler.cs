using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BirdEventHandler : GameStateMachine
{
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Bird _bird;
    public UnityAction PlayerDeath;
    public UnityAction GameRestart;
    public UnityAction GamePaused;
    public UnityAction GameResumed;
    public UnityAction SwitchedToMenu;
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
        
        GamePaused += () =>
        {
            state = States.PAUSE;
        };
        
        GameResumed += () =>
        {
            state = States.GAMEPLAY;
        };

        SwitchedToMenu += () =>
        {
            SceneManager.LoadScene("Menu");
        };
    }
    
}
