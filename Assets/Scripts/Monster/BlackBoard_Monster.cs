using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard_Monster : MonoBehaviour, IBlackboardBase
{
    public float moveSpeed = 3.0f;
    public float attackRange = 6.0f;
   
    [NonSerialized] public Animator animator;
    [NonSerialized] public Rigidbody rigidbody;
    [NonSerialized] public SkillController SkillController;
    [NonSerialized] public SkillController_V2 SkillController_V2;

    [NonSerialized] public Entity target;
        
    public new void InitBlackboard()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        SkillController = GetComponent<SkillController>();
        SkillController_V2 = GetComponent<SkillController_V2>();
    }   
}