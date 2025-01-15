using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blackboard_Player : MonoBehaviour, IBlackboardBase
{
    public float JumpForce = 3f;
    public float moveSpeed = 3.0f;
   
    [NonSerialized] public Animator Animator;
    [NonSerialized] public Rigidbody Rigidbody;

    public new void InitBlackboard()
    {
        Animator = GetComponent<Animator>();
        Rigidbody = GetComponent<Rigidbody>();
    }   
}