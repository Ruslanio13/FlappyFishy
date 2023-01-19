using UnityEngine;

public class GroundAnimator : AnimationedScenery
{
    [SerializeField] private BirdMover _birdMover;
    private void Start()
    {
        animationSpeed = _birdMover.GetSpeed() * 0.175f;
        animator.speed = animationSpeed;
    }   
}