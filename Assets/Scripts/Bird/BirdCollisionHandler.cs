using UnityEngine;

[RequireComponent(typeof(BirdEventHandler))]
[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : GameStateMachine
{
    private Bird _bird;
    private BirdEventHandler _birdEventHandler;
    void Start()
    {
        _bird = GetComponent<Bird>();
        _birdEventHandler = GetComponent<BirdEventHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var colliderTag = collision.tag;
        switch (colliderTag)
        {
            case "Pipe":
                if (_birdEventHandler.state == BirdEventHandler.States.GAMEPLAY)
                    _birdEventHandler.PlayerDeath?.Invoke();
                break;
            case "Ground":
                //TODO: Make Interaction with Ground
                break;
            case "ScoreZone":
                _bird.IncreaseScore();
                break;
        }
    }
}
