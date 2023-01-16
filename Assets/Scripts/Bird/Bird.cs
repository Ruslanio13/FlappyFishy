using UnityEngine;

[RequireComponent(typeof(BirdMover))]
public class Bird : MonoBehaviour
{
    private BirdMover _mover;
    private int _score; 
    void Start()
    {
        _mover = GetComponent<BirdMover>();
    }

    public void ResetPlayer()
    {
        _mover.ResetBird();
        _score = 0;
    }

    public void Die()
    {
        Time.timeScale = 0;
    }
}
