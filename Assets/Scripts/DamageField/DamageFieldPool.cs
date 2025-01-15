using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageFieldPool : MonoBehaviour
{
    public GameObject DamageFieldPrefab;
    public int initalPoolSize = 10;
    
    private Queue<DamageField> pool = new Queue<DamageField>();

    private void Awake()
    {
        for (int i = 0; i < initalPoolSize; i++)
        {
            CreateNewDamageField();
        }
    }

    private void CreateNewDamageField()
    {
        GameObject obj = Instantiate(DamageFieldPrefab);
        obj.SetActive(false);
        pool.Enqueue(obj.GetComponent<DamageField>());
    }

    public DamageField GetDamageField()
    {
        if (pool.Count == 0)
        {
            CreateNewDamageField();
        }
        DamageField damageField = pool.Dequeue();
        damageField.gameObject.SetActive(true);
        return damageField;
    }
    
    public void ReturnDamageField(DamageField damageField)
    {
        damageField.gameObject.SetActive(false);
        pool.Enqueue(damageField);
    }
}
