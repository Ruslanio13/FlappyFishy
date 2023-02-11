using UnityEngine;

public class AnimatedObject : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float animationSpeed;
    [SerializeField] private BirdEventHandler _eventHandler;

    private void OnEnable()
    {
        animator.speed = animationSpeed;
        _eventHandler.PlayerDeath += StopAnimation;
        _eventHandler.GameRestart += ResumeAnimation;
        _eventHandler.GamePaused += StopAnimation;
        _eventHandler.GameResumed += ResumeAnimation;
    }
    private void OnDisable()
    {
        _eventHandler.PlayerDeath -= StopAnimation;
        _eventHandler.GameRestart -= ResumeAnimation;
        _eventHandler.GamePaused -= StopAnimation;
        _eventHandler.GameResumed -= ResumeAnimation;
    }
    protected void StopAnimation()
    {
        animator.speed = 0;
    }

    protected void ResumeAnimation()
    {
        animator.speed = animationSpeed;
    }
}
