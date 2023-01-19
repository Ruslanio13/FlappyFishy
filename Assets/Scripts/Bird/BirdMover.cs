using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private Animator _animator;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private Rigidbody2D _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
        else
            transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        _animator.Play("JumpBegin");
        transform.rotation = _maxRotation;
        ResetVerticalVelocity();
        _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
    }
    private void ResetVerticalVelocity() => _rigidbody.velocity = new Vector2(_speed, 0);
    public void ResetVelocity() => _rigidbody.velocity = Vector2.zero;

    public void ResetBird()
    {
        transform.position = _startPosition;
        ResetVerticalVelocity();
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    public float GetSpeed() => _speed;
}
