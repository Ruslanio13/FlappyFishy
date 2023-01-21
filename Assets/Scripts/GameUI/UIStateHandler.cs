using UnityEngine;

public class UIStateHandler : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private GameObject _restartButton;

    /*private void Start()
    {
        eventHandler.PlayerDeath += () => _restartButton.SetActive(true);
        eventHandler.GameRestart += () => _restartButton.SetActive(false);
    }*/
}
