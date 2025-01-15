using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputManager : Singleton<MyInputManager>
{
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction number_1;
    private InputAction number_2;
    void Start()
    {
        PlayerInput playerInput = GetComponent<PlayerInput>();
        number_1 = playerInput.actions["Number_1"];
        number_2 = playerInput.actions["Number_2"];
        
        jumpAction = playerInput.actions["Jump"];
        moveAction = playerInput.actions["Move"];
    }
    
    void Update()
    {
        var playerController = PlayercController.Instance;
        playerController.OnReadValue("Move", moveAction.ReadValue<Vector2>());
        playerController.OnTriggered("Jump", jumpAction.triggered);
        playerController.OnTriggered("Number_1", number_1.triggered);
        playerController.OnTriggered("Number_2", number_2.triggered);
    }
}
