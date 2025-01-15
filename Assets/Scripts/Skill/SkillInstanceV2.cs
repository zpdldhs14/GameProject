using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// public interface ICondition<T1, T2>
// {
//     bool IsTrue();
//     T1 GetValue1();
//     
//     T2 GetValue2();
// }
//
// public abstract class Condition<T1, T2> : ICondition<T1, T2>
// {
//     public Transform checker;
//     
//     public Func<T1> GetValueFunc1;
//     public Func<T2> GetValueFunc2;
//     
//     public bool IsTrue()
//     {
//         throw new NotImplementedException();
//     }
//
//     public T1 GetValue1()
//     {
//         return GetValueFunc1.Invoke();
//     }
//
//     public T2 GetValue2()
//     {
//         return GetValueFunc2.Invoke();
//     }
// }
//
// public class DistanceChcker : Condition<float, Vector3>
// {
//     public bool IsTrue()
//     {
//         float distance = GetValue1();
//         Vector3 targetPosition = GetValue2();
//         
//         return distance * distance >=
//                Vector3.SqrMagnitude(targetPosition - checker.position);
//     }
// }

[RequireComponent(typeof(SkillCooltimer_V2))]
public class SkillInstanceJ_V2 : MonoBehaviour
{
    public GameObject Owner;
    public SkillController_V2 skillControllerJV2;
    public SkillData SkillData;
    private SkillCooltimer_V2 skillCooltimer;
    private Blackboard_Monster blackboardMonster;

    private void Start()
    {
        skillCooltimer = GetComponent<SkillCooltimer_V2>();
        skillCooltimer.skillData = SkillData;
        blackboardMonster = Owner.GetComponent<Blackboard_Monster>();
        skillControllerJV2 = Owner.GetComponent<SkillController_V2>();
    }

    public void FireSkill()
    {   
        Debug.Log($"FireSkill {SkillData.name}");
        skillCooltimer.StartCoolTimer(OnFinishSkillCoolTimer);
        skillControllerJV2.RemoveAvailableSkill(this);
    }

    void OnFinishSkillCoolTimer()
    {
        skillControllerJV2.AddAvailableSkill(this);
    }    
    
    public float CanSkillEnableDistance()
    {
        return SkillData.skillEnableDistance;
    }
    
    public float GetSkillDuration()
    {
        return SkillData.skillDuration;
    }
}
