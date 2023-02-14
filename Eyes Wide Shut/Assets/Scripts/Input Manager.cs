using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    //A refrence to the Player Input Script
    private PlayerInput playerinput;
    private PlayerInput.OnFootActions onFoot;
    
    void Awake()
    {
        playerinput = new PlayerInput();
        onFoot = playerinput.OnFoot;
    }

    void Update()
    {
        
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
