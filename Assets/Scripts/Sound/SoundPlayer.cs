using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip pipeHitClip;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip jumpClip;
    [SerializeField] private AudioClip coinClip;

    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private BirdMover mover;

    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        mover.PlayerJumped += () => { _source.PlayOneShot(jumpClip); };
        eventHandler.ScoreChanged += (int x) => { if (x != 0) { _source.PlayOneShot(pointClip); } };
        eventHandler.ObstacleHit += PlayHitShot;
        eventHandler.PickedUpCoin += () => { _source.PlayOneShot(coinClip); };
    }

    private void PlayHitShot(bool isPipe)
    {
        _source.PlayOneShot(isPipe ? pipeHitClip : deathClip);
    }
}
