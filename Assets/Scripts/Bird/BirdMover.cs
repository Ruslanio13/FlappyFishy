using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _defaultRotationSpeed;
    [SerializeField] private Animator _animator;
    private float _rotationSpeed;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;

    private Rigidbody2D _rigidbody;
    private BirdEventHandler _eventHandler;
    private void Start()
    {
        MakeRotationSpeedAndAngleDefault();

        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);

        _eventHandler = GetComponent<BirdEventHandler>();
        _eventHandler.PlayerDeath += IncreaseRotationSpeedAndAngle;
    }

    private void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && _eventHandler.state == GameStateMachine.States.GAMEPLAY)
            Jump();
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
        MakeRotationSpeedAndAngleDefault();
        transform.position = _startPosition;
        ResetVerticalVelocity();
        SetRigidbody(false);
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
    public float GetSpeed() => _speed;

    public void SetRigidbody(bool isStatic)
    {
        if (isStatic)
            _rigidbody.bodyType = RigidbodyType2D.Static;
        else
            _rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }

    private void IncreaseRotationSpeedAndAngle()
    {
        _minRotation = Quaternion.Euler(0, 0, -90);
        _rotationSpeed *= 5;
    }

    private void MakeRotationSpeedAndAngleDefault()
    {
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _rotationSpeed = _defaultRotationSpeed;
    }
}
