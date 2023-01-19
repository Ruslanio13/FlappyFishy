using UnityEngine;

public class AnimationedScenery : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] protected float animationSpeed;
    [SerializeField] private BirdEventHandler _eventHandler;

    private void OnEnable()
    {
        _eventHandler.PlayerDeath += StopAnimation;
        _eventHandler.GameRestart += ResumeAnimation;
    }
    private void OnDisable()
    {
        _eventHandler.PlayerDeath -= StopAnimation;
        _eventHandler.GameRestart -= ResumeAnimation;
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
