using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIShip : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement1;
    [SerializeField] private Animator _playerAnimator1;
    [SerializeField] private PlayerMovement _playerMovement2;
    [SerializeField] private Animator _playerAnimator2;
    
    [SerializeField] private Image _ship1;
    [SerializeField] private Image _ship2;

    [SerializeField] private Road _road;
    
    private static readonly int IsDamaged = Animator.StringToHash("IsDamaged");

    // Start is called before the first frame update
    void Start()
    {
        _ship1.transform.position = new Vector3(910, 37.5f, 0);
        _ship2.transform.position = new Vector3(1010, 37.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerMovement1.HasFinishedRace)
        {
            float player1MeterRatio = _playerMovement1.transform.position.y * 100 / _road.RoadDimensions.y;
            float uiShip1Meter = 1015 * (player1MeterRatio / 100);
            
            Vector3 ship1NewPos = new Vector3(_ship1.transform.position.x, uiShip1Meter + 37.5f, 
                _ship1.transform.position.z);
            
            _ship1.transform.position = ship1NewPos;
            
            if (_playerMovement1.IsDamagedCollide)
            {
                _playerAnimator1.SetBool(IsDamaged, true);   
            }
            else
            {
                _playerAnimator1.SetBool(IsDamaged, false);
            }
        }

        if (!_playerMovement2.HasFinishedRace)
        {
            float player2MeterRatio = _playerMovement2.transform.position.y * 100 / _road.RoadDimensions.y;
            float uiShip2Meter = 1015 * (player2MeterRatio / 100);
        
        
            Vector3 ship2NewPos = new Vector3(_ship2.transform.position.x, uiShip2Meter + 37.5f, _ship2.transform.position.z);
            
            _ship2.transform.position = ship2NewPos;
            
            if (_playerMovement2.IsDamagedCollide)
            {
                _playerAnimator2.SetBool(IsDamaged, true);   
            }
            else
            {
                _playerAnimator2.SetBool(IsDamaged, false);
            }
        }
    }
}
