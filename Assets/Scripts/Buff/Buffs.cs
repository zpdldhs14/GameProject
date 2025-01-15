using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IBuff
{
    void ApplyBuff(MonsterStatus status);
    
    void UpdateApplyBuff(MonsterStatus status);
    
    void RemoveBuff(MonsterStatus status);
}

public class Buff_Burning : IBuff
{
    private GameObject burningEffect;

    public void SetParticle(GameObject particle)
    {
        this.burningEffect = particle;
    }
    
    public GameObject GetParticle()
    {
        return burningEffect;
    }
    public void ApplyBuff(MonsterStatus status)
    {
    }

    public void UpdateApplyBuff(MonsterStatus status)
    {
        status.Hp -= 1;
    }

    public void RemoveBuff(MonsterStatus status)
    {
       
    }
}


public class Buff_Freezing : IBuff
{
    public void ApplyBuff(MonsterStatus status)
    {
        var animator = status.gameObject.GetComponent<Blackboard_Monster>().animator;
        animator.SetFloat("Speed", 0.0f);
        float speedvalue = animator.GetFloat("Speed");
        Debug.Log($"Speed : {speedvalue}");
        status.Speed = 0;
    }

    public void UpdateApplyBuff(MonsterStatus status)
    {
    }

    public void RemoveBuff(MonsterStatus status)
    {
        var animator = status.gameObject.GetComponent<Blackboard_Monster>().animator;
        animator.SetFloat("Speed", 1.0f);
        float speedvalue = animator.GetFloat("Speed");
        Debug.Log($"Speed : {speedvalue}");
        status.Speed = 1;
    }
}