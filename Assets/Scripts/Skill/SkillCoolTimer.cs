using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillCooltimer : MonoBehaviour
{
    //시간만 갱신하는 코드 skillInstance에 합쳐도 무방하지만 나누는것을 권장.
    public SkillData skillData;
    private float remainDuration;

    public bool IsReady => 0 >= remainDuration;

    public float RemainDuration => remainDuration;

    public void StartCoolTimer()
    {
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
    }
}