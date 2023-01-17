using UnityEngine;

[RequireComponent(typeof(BirdEventHandler))]
public class BirdCollisionHandler : MonoBehaviour
{
    private BirdEventHandler _birdEventHandler;
    void Start()
    {
        _birdEventHandler = GetComponent<BirdEventHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _birdEventHandler.PerformDie();
    }
}
