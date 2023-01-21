using UnityEngine;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private GameObject[] gameplayElements;
    [SerializeField] private BirdEventHandler eventHandler;

    public UnityAction OnPause;
    public UnityAction OffPause;

    private void Start()
    {
        ResumeTime();

        OnPause += () =>
        {
            StopTime();
            ShowPauseWindow();
        };

        OffPause += () =>
        {
            ResumeTime();
            HidePauseWindow();
        };
    }
    private void StopTime() => Time.timeScale = 0;
    private void ResumeTime() => Time.timeScale = 1;
    private void ShowPauseWindow()
    {
        if (eventHandler.state == GameStateMachine.States.GAMEOVER)
            return;
        pauseWindow.SetActive(true);
        foreach (var item in gameplayElements)
            item.SetActive(false);
    }
    private void HidePauseWindow()
    {
        pauseWindow.SetActive(false);
        foreach (var item in gameplayElements)
            item.SetActive(true);
    }
}
