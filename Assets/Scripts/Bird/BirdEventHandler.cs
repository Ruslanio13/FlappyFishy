using System;
using UnityEngine;

public class BirdEventHandler : MonoBehaviour
{
    public delegate void DeathHandler();
    public delegate void RestartHandler();
    public event DeathHandler OnPlayerDeath;
    public event RestartHandler OnRestart;
    
    public void PerformDie() => OnPlayerDeath?.Invoke();

    public void PerformRestart() => OnRestart?.Invoke();

    private void Start()
    {
        OnPlayerDeath += () =>
        {
            Time.timeScale = 0;
        };
        OnRestart += () =>
        {
            Time.timeScale = 1;
        };
    }
}
