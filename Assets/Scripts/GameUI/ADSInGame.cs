using UnityEngine;

public class ADSInGame : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;
    private void Start()
    {
        eventHandler.PlayerDeath += YandexSDK.YaSDK.instance.ShowInterstitial;
    }
}
