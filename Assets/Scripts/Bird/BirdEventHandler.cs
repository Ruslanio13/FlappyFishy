using System;
using UnityEngine;
using UnityEngine.Events;

public class BirdEventHandler : MonoBehaviour
{
    [SerializeField] private PipeGenerator _pipeGenerator;
    public UnityAction PlayerDeath;
    public UnityAction GameRestart;
    
    private void Start()
    {
        PlayerDeath += () =>
        {
            Time.timeScale = 0;
        };
        GameRestart += () =>
        {
            Time.timeScale = 1;
            _pipeGenerator.ResetPool();
        };
    }
}
