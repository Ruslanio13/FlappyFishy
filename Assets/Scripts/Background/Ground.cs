using UnityEngine;

public class Ground : AnimatedObject
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private float speedKoef;
    private void Start()
    {
        animationSpeed = _birdMover.GetSpeed() * speedKoef;
        animator.speed = animationSpeed;
    }   
}