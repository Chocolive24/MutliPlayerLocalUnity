using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Road _road;
    private Rigidbody2D _rb;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerMovement.HasFinishedRace && _playerMovement.IsReady)
        {
            _rb.velocity = Vector2.up * _playerMovement.Speed;
        }
        else if (_playerMovement.HasFinishedRace)
        {
            _rb.velocity = Vector2.zero;

            transform.position = new Vector3(transform.position.x, _road.RoadDimensions.y + 3,
                transform.position.z);
        }
    }
}
