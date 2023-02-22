using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputs : MonoBehaviour
{
    [NonSerialized] public float Move;

    [NonSerialized] public bool SpeedUp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // public void OnMove(InputAction.CallbackContext ctx)
    // {
    //     if (ctx.started)
    //     {
    //         Move = ctx.ReadValue<float>();
    //     }
    //
    // }
    //
    // void OnSpeed(InputValue value)
    // {
    //     SpeedUp = value.isPressed;
    // }
}
