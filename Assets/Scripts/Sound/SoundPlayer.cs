using System;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(AudioSource))]
public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip deathClip;
    [SerializeField] private AudioClip pipeHitClip;
    [SerializeField] private AudioClip pointClip;
    [SerializeField] private AudioClip jumpClip;

    [SerializeField] private BirdEventHandler eventHandler;
    [SerializeField] private BirdMover mover;

    private AudioSource _source;
    private void Start()
    {
        _source = GetComponent<AudioSource>();
        mover.PlayerJumped += () => { _source.PlayOneShot(jumpClip); };
        eventHandler.ScoreChanged += (int x) => { _source.PlayOneShot(pointClip); };
        eventHandler.ObstacleHit += PlayHitShot;
    }

    private void PlayHitShot(bool isPipe)
    {
        _source.PlayOneShot(isPipe ? pipeHitClip : deathClip);
    }
}
