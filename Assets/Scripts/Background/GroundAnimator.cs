using UnityEngine;

public class GroundAnimator : MonoBehaviour
{
    [SerializeField] private Animator _moveGroundAnim;
    [SerializeField] private BirdMover _birdMover;
    private void Start()
    {
        _moveGroundAnim.speed = _birdMover.GetSpeed() * 0.175f;
    }
    
}
