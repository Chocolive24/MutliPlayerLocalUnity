using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;

    private float _speed;
    [SerializeField] private float _initalSpeed = 2f;
    [SerializeField] private float _maxSpeed = 10f;
    private Vector2 _movementVelocity;
    private float _movement;

    private bool _hasFinishedRace = false;
    
    private Vector3 _centerPos;
    private bool _canSpeedUp = true;
    [SerializeField] private float _speedCooldown = 1f;
    private static readonly int IsDamaged = Animator.StringToHash("IsDamaged");

    private bool _isDamagedCollide = false;
    private bool _isReady = false;
    
    [SerializeField] private AudioSource _finishRace;
    [SerializeField] private AudioSource _damage;

    [SerializeField] private Road _road;
    private bool _hasPlayedFinishSound = false;

    public bool IsDamagedCollide => _isDamagedCollide;

    public float Speed => _speed;

    public bool HasFinishedRace => _hasFinishedRace;

    public bool IsReady
    {
        get => _isReady;
        set => _isReady = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _speed = _initalSpeed;
        
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _centerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        _hasFinishedRace = transform.position.y >= _road.RoadDimensions.y;

        if (_hasFinishedRace && !_hasPlayedFinishSound)
        {
            _finishRace.Play();
            _hasPlayedFinishSound = true;
        }
    }

    private void FixedUpdate()
    {
        //_rb.MovePosition(new Vector2(transform.position.x + _movement, 0f));
        if (_isReady)
        {
            _rb.velocity = Vector2.up * _speed;
        }
        // else
        // {
        //     _rb.velocity = Vector2.zero;
        // }
        
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        if (_isReady)
        {
            if (ctx.started)
            {
                _movement = ctx.ReadValue<float>();

                if (_movement > 0)
                {
                    _movement = 1;
                }
                else if (_movement < 0)
                {
                    _movement = -1;
                }
                else
                {
                    _movement = 0;
                }

                if (transform.position.x > _centerPos.x && _movement > 0f ||
                    transform.position.x < _centerPos.x && _movement < 0f)
                {
                    _movement = 0f;
                }
                else
                {
                    var transformPosition = transform.position;
                    transformPosition.x += _movement;
                    transform.position = transformPosition;
                }
            }
        }
    }

    public void HandleSpeedUp(InputAction.CallbackContext ctx)
    {
        if (_isReady)
        {
            if (ctx.started && _speed < _maxSpeed && _canSpeedUp && !_isDamagedCollide)
            {
                _speed += 2;
                StartCoroutine(nameof(SpeedCooldown));
            }
        }
    }

    private IEnumerator SpeedCooldown()
    {
        _canSpeedUp = false;
        yield return new WaitForSeconds(_speedCooldown);
        _canSpeedUp = true;
        
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Asteroid"))
        {
            _speed = _initalSpeed;

            StartCoroutine(nameof(DamageCooldown));
            _damage.Play();
        }
    }

    private IEnumerator DamageCooldown()
    {
        _isDamagedCollide = true;
        _animator.SetBool(IsDamaged, true);
        _boxCollider2D.enabled = false;

        yield return new WaitForSeconds(1f);

        _isDamagedCollide = false;
        _animator.SetBool(IsDamaged, false);
        _boxCollider2D.enabled = true;
    }
}
