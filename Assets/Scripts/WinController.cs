using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinController : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement1;
    [SerializeField] private PlayerMovement _playerMovement2;

    [SerializeField] private Timer _timer1;
    [SerializeField] private Timer _timer2;

    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _distancePanel;
    [SerializeField] private GameObject _speedBoostPanel;

    [SerializeField] private GameObject _player1winTxt;
    [SerializeField] private GameObject _player2winTxt;
    [SerializeField] private GameObject _tieTxt;

    // Start is called before the first frame update
    void Start()
    {
        _winPanel.SetActive(false);
        _player1winTxt.SetActive(false);
        _player2winTxt.SetActive(false);
        _tieTxt.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement1.HasFinishedRace && _playerMovement2.HasFinishedRace)
        {
            _winPanel.SetActive(true);
            _distancePanel.SetActive(false);
            _speedBoostPanel.SetActive(false);

            if (_timer1.ChronoTime < _timer2.ChronoTime)
            {
                _player1winTxt.SetActive(true);
            }
            else if (_timer1.ChronoTime > _timer2.ChronoTime)
            {
                _player2winTxt.SetActive(true);
            }
            else
            {
                _tieTxt.SetActive(true);
            }
        }
    }
}
