using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //A refrence to the Player Input Script
    private PlayerInput playerinput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;
    
    void Awake()
    {
        playerinput = new PlayerInput();
        onFoot = playerinput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        // ctx = call back context
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    void FixedUpdate()
    {
        //Asking the Player motor to move using the value from our movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>()); 
    }
    
    void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    //To enable our Action map
    private void OnEnable()
    {
        onFoot.Enable();
    }
    //To disable our Action map
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
