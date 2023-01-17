using UnityEngine;

public class UIStateHandler : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private GameObject _restartButton;

    private void Start()
    {
        eventHandler.OnPlayerDeath += () => _restartButton.SetActive(true);
        eventHandler.OnRestart += () => _restartButton.SetActive(false);
    }
}
