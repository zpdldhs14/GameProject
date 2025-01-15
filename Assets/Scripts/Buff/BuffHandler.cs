using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BuffPool))]
public class BuffHandler : MonoBehaviour
{
    private BuffPool buffPool;
    private ParticlePool particlePool;
    private List<IBuff> buffs = new List<IBuff>();

    private void Start()
    {
        buffPool = GetComponent<BuffPool>();
        particlePool = GetComponent<ParticlePool>();
    }

    public IBuff AddBuff<T>() where T : IBuff
    {
        var buff = buffPool.GetBuff<T>();
        if (typeof(T) == typeof(Buff_Burning))
        {
            var particle = particlePool.GetParticle();
            particle.transform.position = transform.position;
            particle.transform.parent = transform;
            (buff as Buff_Burning).SetParticle(particle);
        }
        StartCoroutine(HandleBuff(buff));
        buffs.Add(buff);
        return buff;
    }
    
    public void RemoveBuff(IBuff buff)
    {
        if (buff is Buff_Burning burningEffect)
        {
            particlePool.ReturnParticle(burningEffect.GetParticle());
        }
        buff.RemoveBuff(GetComponent<MonsterStatus>());
        buffPool.ReturnBuff(buff);
        buffs.Remove(buff);
    }
    
    private IEnumerator HandleBuff(IBuff buff)
    {
        var monsterStatus = GetComponent<MonsterStatus>();
        buff.ApplyBuff(monsterStatus); // 버프 적용 (초기에 실행)

        float duration = 3f; // 버프 지속 시간
        while (duration > 0)
        {
            yield return new WaitForSeconds(1f); // 1초마다 실행
            buff.UpdateApplyBuff(monsterStatus); // 매 초 버프 적용 처리
            duration -= 1f;
        }

        // 지속 시간이 끝난 후 버프 삭제
        RemoveBuff(buff);
    }

    private IBuff buffBurning;
    private IBuff buffFreezing;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            buffBurning = GetComponent<BuffHandler>().AddBuff<Buff_Burning>();
        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            buffFreezing = GetComponent<BuffHandler>().AddBuff<Buff_Freezing>();
        }
        
        if (Input.GetKeyDown(KeyCode.N))
        {
            GetComponent<BuffHandler>().RemoveBuff(buffBurning);
        }
        
        if (Input.GetKeyDown(KeyCode.M))
        {
            GetComponent<BuffHandler>().RemoveBuff(buffFreezing);
        }

        
        foreach (var buff in buffs)
        {
            buff.UpdateApplyBuff(GetComponent<MonsterStatus>());
        }
    }
}