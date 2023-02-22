using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInputs _inputs;
    private Rigidbody2D _rb;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;

    [SerializeField] private float _speed = 2f;
    private float _maxSpeed = 10f;
    private Vector2 _movementVelocity;
    private float _movement;

    private Vector3 _centerPos;
    private bool _canSpeedUp = true;
    [SerializeField] private float _speedCooldown = 1f;
    private static readonly int IsDamaged = Animator.StringToHash("IsDamaged");

    // Start is called before the first frame update
    void Start()
    {
        _inputs = GetComponent<PlayerInputs>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();

        _centerPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0f, _speed * Time.deltaTime, 0f);
    }

    private void FixedUpdate()
    {
        //_rb.MovePosition(new Vector2(transform.position.x + _movement, 0f));
    }

    public void HandleMove(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            _movement = ctx.ReadValue<float>();

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


        Debug.Log(_inputs.Move);
    }

    public void HandleSpeedUp(InputAction.CallbackContext ctx)
    {
        if (ctx.started && _speed < _maxSpeed && _canSpeedUp)
        {
            _speed += 2f;
            StartCoroutine(nameof(SpeedCooldown));
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
            _speed = 2f;

            StartCoroutine(nameof(DamageCooldown));
        }
    }

    private IEnumerator DamageCooldown()
    {
        _animator.SetBool(IsDamaged, true);
        _boxCollider2D.enabled = false;

        yield return new WaitForSeconds(1f);
        
        _animator.SetBool(IsDamaged, false);
        _boxCollider2D.enabled = true;
    }
}
