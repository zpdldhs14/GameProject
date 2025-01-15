using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffPool : MonoBehaviour
{
    private Dictionary<System.Type, Queue<IBuff>> pool = new();

    private Dictionary<System.Type, int> initPoolSizes = new()
    {
        { typeof(Buff_Burning), 5 },
        { typeof(Buff_Freezing), 5 },
    };

    void Awake()
    {
        foreach (var keyValuePair in initPoolSizes)
        {
            pool[keyValuePair.Key] = new Queue<IBuff>(keyValuePair.Value);
            for (int i = 0; i < keyValuePair.Value; ++i)
            {
                CreateBuff(keyValuePair.Key);
            }
        }
    }

    void CreateBuff(System.Type buffType)
    {
        IBuff buff = Activator.CreateInstance(buffType) as IBuff;
        pool[buffType].Enqueue(buff);
    }

    public T GetBuff<T>() where T : IBuff
    {
        var Type = typeof(T);

        if (!pool.ContainsKey(Type) || pool[Type].Count == 0)
        {
            CreateBuff(Type);
        }
        
        return (T)pool[typeof(T)].Dequeue();
    }

    public void ReturnBuff(IBuff buff)
    {
        var type = buff.GetType();
        pool[type].Enqueue(buff);
    }
}