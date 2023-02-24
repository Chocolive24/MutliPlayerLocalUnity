using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timerTxt;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private Road _road;

    public float ChronoTime;

    private bool _isActive = false;
    private bool _hasTheRaceStarted = false;

    public bool IsActive
    {
        get => _isActive;
        set => _isActive = value;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_playerMovement.HasFinishedRace)
        {
            _isActive = false;
        }
        
        if (_isActive)
        {
            ChronoTime += Time.deltaTime;
        
            _timerTxt.text = FormatTime(ChronoTime); // "Time : " + 
        }
        
        if (_isActive)
        {
            _hasTheRaceStarted = true;
        }
        
        if (!_hasTheRaceStarted)
        {
            _timerTxt.text = "00:00:000";
        }
    }
    
    private String FormatTime(float time)
    {
        int roundTime = (int)(time * 100.0f);
        int minutes = roundTime / (60 * 100);
        int seconds = (roundTime % (60 * 100)) / 100;
        int hundredths = roundTime % 100;
        
        return String.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, hundredths);
    }
}
