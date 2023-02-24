using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Color = System.Drawing.Color;

public class UISpeedBoost : MonoBehaviour
{
    [SerializeField] private PlayerMovement _playerMovement;
    
    [SerializeField] private Image _boost1;
    [SerializeField] private Image _boost2;
    [SerializeField] private Image _boost3;
    [SerializeField] private Image _boost4;
    [SerializeField] private Image _boost5;

    private UnityEngine.Color _color2;
    private UnityEngine.Color _color3;
    private UnityEngine.Color _color4;
    private UnityEngine.Color _color5;
    
    // Color.Lerp très utile avec une couleur de début, de fin et un ratio.
    
    // Start is called before the first frame update
    void Start()
    {
        _color2 = _boost2.color;
        _color2.a = 0.2f;
        _boost2.color = _color2;
        
        // _boost2.color = new UnityEngine.Color(_boost2.color.r, _boost2.color.g, _boost2.color.b, 
        //     50f);
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerMovement.Speed >= 4f)
        {
            _color2 = _boost2.color;
            _color2.a = 1f;
            _boost2.color = _color2;
        }
        else
        {
            _color2 = _boost2.color;
            _color2.a = 0.2f;
            _boost2.color = _color2;
        }
        
        // Boost 3 --------------------------------------------------------
        if (_playerMovement.Speed >= 6f)
        {
            _color3 = _boost3.color;
            _color3.a = 1f;
            _boost3.color = _color3;
        }
        else
        {
            _color3 = _boost3.color;
            _color3.a = 0.2f;
            _boost3.color = _color3;
        }
        
        // Boost 4 --------------------------------------------------------
        if (_playerMovement.Speed >= 8f)
        {
            _color4 = _boost4.color;
            _color4.a = 1f;
            _boost4.color = _color4;
        }
        else
        {
            _color4 = _boost4.color;
            _color4.a = 0.2f;
            _boost4.color = _color4;
        }
        
        // Boost 5 --------------------------------------------------------
        if (_playerMovement.Speed >= 10f)
        {
            _color5 = _boost5.color;
            _color5.a = 1f;
            _boost5.color = _color5;
        }
        else
        {
            _color5 = _boost5.color;
            _color5.a = 0.2f;
            _boost5.color = _color5;
        }
    }
}
