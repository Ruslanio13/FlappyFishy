using UnityEngine;
using UnityEngine.EventSystems;

public class JumpButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private BirdMover birdMover;
    public void OnPointerDown(PointerEventData data)
    {
        birdMover.Jump();
    }
}