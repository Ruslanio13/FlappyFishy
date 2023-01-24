using UnityEngine;
public class ADS : MonoBehaviour
{
    [SerializeField] private BirdEventHandler eventHandler;
    private void Start()
    {
        eventHandler.PlayerDeath += ShowAds;
    }
    private void ShowAds() => Application.ExternalCall("ShowAds");
}