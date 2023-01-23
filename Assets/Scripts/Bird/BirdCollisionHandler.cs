using UnityEngine;

[RequireComponent(typeof(BirdEventHandler))]
[RequireComponent(typeof(Bird))]
public class BirdCollisionHandler : GameStateMachine
{
    private Bird _bird;
    private BirdMover _birdMover;
    private BirdEventHandler _birdEventHandler;
    void Start()
    {
        _bird = GetComponent<Bird>();
        _birdEventHandler = GetComponent<BirdEventHandler>();
        _birdMover = GetComponent<BirdMover>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Ground":
                _birdMover.SetRigidbody(true);
                _birdEventHandler.PlayerDeath?.Invoke();
                break;
            case "Pipe":
                if (_birdEventHandler.state == States.GAMEPLAY)
                    _birdEventHandler.PlayerDeath?.Invoke();
                break;
            case "ScoreZone":
                _bird.IncreaseScore();
                break;
            case "Money":
                _bird.PickUpMoney();
                collision.gameObject.SetActive(false);
                break;
            default:
                break;
        }
    }
}
