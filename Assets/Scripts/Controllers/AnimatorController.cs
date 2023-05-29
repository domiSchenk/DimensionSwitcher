using UnityEngine;
using Shinjingi;

public class AnimatorController : MonoBehaviour
{


    private Rigidbody2D _body;
    private CollisionDataRetriever _collisionDataRetriever;
    private Controller _controller;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Vector2 _direction, _desiredVelocity, _velocity;


    private int speedHash;
    private int verticalSpeedHash;
    private int groundedHash;
    private bool _onGround, _isJumping;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _collisionDataRetriever = GetComponent<CollisionDataRetriever>();
        _controller = GetComponent<Controller>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        AssignAnimationIDs();
    }

    private void FixedUpdate()
    {
        _direction.x = _body.velocity.x;
        _direction.y = _body.velocity.y;
        _onGround = _collisionDataRetriever.OnGround;

        if (_direction.x != 0)
        {
            _spriteRenderer.flipX = _direction.x > 0;
        }
        _animator.SetFloat(speedHash, Mathf.Abs(_direction.x));
        _animator.SetFloat(verticalSpeedHash, Mathf.Abs(_direction.y));
        _animator.SetBool(groundedHash, _onGround);
    }

    private void AssignAnimationIDs()
    {
        speedHash = Animator.StringToHash("Speed");
        groundedHash = Animator.StringToHash("IsGrounded");
        verticalSpeedHash = Animator.StringToHash("VerticalSpeed");
    }
}
