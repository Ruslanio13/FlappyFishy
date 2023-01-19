using UnityEngine;
using UnityEngine.Events;

public class BirdEventHandler : MonoBehaviour
{
    [SerializeField] private PipeGenerator _pipeGenerator;
    [SerializeField] private Bird _bird;
    public UnityAction PlayerDeath;
    public UnityAction GameRestart;
    public UnityAction<int> ScoreChanged;
    
    private void Start()
    {
        PlayerDeath += () =>
        {
            _bird.Die();
        };
        GameRestart += () =>
        {
            _pipeGenerator.ResetPool();
        };
    }
}
