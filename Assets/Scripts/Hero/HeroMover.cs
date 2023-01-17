using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private bool _isGrounded = false;
    private Animator _animation;
    [SerializeField] private Joystick _joystick;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _animation = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    private void Update()
    {
        if (_isGrounded)
            State = States.idle;

        if (_joystick.Horizontal != 0)
            Run();
    }

    private States State
    {
        get { return (States)_animation.GetInteger("state"); }
        set { _animation.SetInteger("state", (int)value); }
    }

    private void Run()
    {
        Vector3 direction = transform.right * _joystick.Horizontal;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, _speed * Time.deltaTime);
        _spriteRenderer.flipX = direction.x < 0.0f;
        if (_isGrounded)
            State = States.run;
    }

    public void Jump()
    {
        if(_isGrounded)
        _rigidbody2D.velocity = Vector2.up * _jumpForce;
    }

    private void CheckGround()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.5f);
        _isGrounded = colliders.Length > 1;
        if (!_isGrounded)
            State = States.jump;
    }

    public enum States
    {
        idle,
        run,
        jump
    }
}
