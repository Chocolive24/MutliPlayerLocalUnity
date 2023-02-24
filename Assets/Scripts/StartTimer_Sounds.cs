using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTimer_Sounds : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement1;
    [SerializeField] private PlayerMovement _playerMovement2;

    [SerializeField] private Timer _timer1;
    [SerializeField] private Timer _timer2;
    
    [SerializeField] private AudioSource _startTimer;
    [SerializeField] private AudioSource _raceTheme;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        StartCoroutine(StartRaceCo());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator StartRaceCo()
    {
        _startTimer.Play();
        
        yield return new WaitForSeconds(4f);

        _raceTheme.Play();
        
        _playerMovement1.IsReady = true;
        _playerMovement2.IsReady = true;

        _timer1.IsActive = true;
        _timer2.IsActive = true;
    }
}
