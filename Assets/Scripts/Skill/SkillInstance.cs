using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkillCooltimer))]
public class SkillInstance : MonoBehaviour
{
    //스킬 데이터 하나당 스킬 인스턴스 하나라고 생각하자.
    //스킬 데이터를 하나 가지고 인스턴스화 되는 것.
    public GameObject Owner;
    public SkillData SkillData;
    private SkillCooltimer skillCooltimer;

    private void Start()
    {
        skillCooltimer = GetComponent<SkillCooltimer>();
        skillCooltimer.skillData = SkillData;
    }

    public void FireSkill()
    {   
        Debug.Log($"FireSkill {SkillData.name}");
        skillCooltimer.StartCoolTimer();
    }

    public bool CanFireSkill()
    {
        return skillCooltimer.IsReady;
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