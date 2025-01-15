using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[
    RequireComponent(typeof(Rigidbody)),
    RequireComponent(typeof(CapsuleCollider)),
    RequireComponent(typeof(Animator)),
    RequireComponent(typeof(StateMachine)),
    RequireComponent(typeof(CustomTag)),
    RequireComponent(typeof(SkillController))
]

    
public abstract class Entity : MonoBehaviour
{
    protected StateMachine stateMachine;
    protected Rigidbody rigidbody;

    protected virtual StaterType EntityStaterType => StaterType.None;

    private void Awake()
    {
        stateMachine = GetComponent<StateMachine>();
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        stateMachine.Run(EntityStaterType);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine?.UpdateState();
    }
}
