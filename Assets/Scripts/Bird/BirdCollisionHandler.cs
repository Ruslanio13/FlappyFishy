using UnityEngine;

[RequireComponent(typeof(BirdEventHandler))]
public class BirdCollisionHandler : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    private BirdEventHandler _birdEventHandler;
    void Start()
    {
        _birdEventHandler = GetComponent<BirdEventHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
            _birdEventHandler.PlayerDeath?.Invoke();
        if (collision.gameObject.CompareTag("ScoreZone"))
            _bird.IncreaseScore();
    }
}
