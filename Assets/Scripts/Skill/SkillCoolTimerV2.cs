using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillCooltimer_V2 : MonoBehaviour
{
    public SkillData skillData;
    private float remainDuration;

    public bool IsReady => 0 >= remainDuration;
    public float RemainDuration => remainDuration;

    private Action cooltimeFinished;

    public void StartCoolTimer(Action callback)
    {
        cooltimeFinished = callback;
        CoolTimeProcess();
    }

    async void CoolTimeProcess()
    {
        remainDuration = skillData.skillCooltime;
        
        while (remainDuration > 0.0f)
        {
            remainDuration -= Time.deltaTime;
            await UniTask.Yield();
        }
        
        cooltimeFinished?.Invoke();
    }
}