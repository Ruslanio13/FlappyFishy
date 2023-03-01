using UnityEngine;
using YG;

public class ADSInGame : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;

    private void OnEnable()
    {
        eventHandler.PlayerDeath += YandexGame.FullscreenShow;
    }
    private void OnDisable()
    {
        eventHandler.PlayerDeath -= YandexGame.FullscreenShow;
    }
}
