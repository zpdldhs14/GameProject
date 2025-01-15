using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//일련의 사이즈를 가지고 범위를 표현하는 것.
//빌더패턴 데미지 필드를 생성하는 역할을 한다.
public class DamageField : MonoBehaviour
{
    public float damage;
    public float radius;
    public float duration;
    public float tickInterval;
    
    public DamageHandler Handler;

    public float GetCalculatedDamage()
    {
        if (Handler != null)
        {
            return Handler.HandleDamage(damage);
        }

        return damage;
    }
}
//빌더의 특징 : 자기자신을 반환한다.
public class DamageFieldBuilder
{
    private DamageField damageField;

    public DamageFieldBuilder(DamageFieldPool pool)
    {
        damageField = pool.GetDamageField();
        var collider = damageField.GetComponent<SphereCollider>();
        if (collider == null)
        {
            damageField.gameObject.AddComponent<SphereCollider>();    
        }
        
    }
    
    public DamageFieldBuilder SetDamage(float damage)
    {
        damageField.damage = damage;
        return this;
    }
    
    public DamageFieldBuilder SetRadius(float radius)
    {
        damageField.GetComponent<SphereCollider>().radius = radius;
        damageField.GetComponent<SphereCollider>().isTrigger = true;
        damageField.radius = radius;
        return this;
    }
    
    public DamageFieldBuilder SetDuration(float duration)
    {
        damageField.duration = duration;
        return this;
    }
    
    public DamageFieldBuilder SetTickInterval(float tickInterval)
    {
        damageField.tickInterval = tickInterval;
        return this;
    }
    
    public DamageFieldBuilder SetPosition(Vector3 pos)
    {
        damageField.transform.position = pos;
        return this;
    }
//책임 연쇄 패턴
    public DamageFieldBuilder SetDamageHandler(DamageHandler handler)
    {
        if (damageField.Handler == null)
        {
            damageField.Handler = handler;
        }
        else
        {
            damageField.Handler.setNextHandler(handler);
        }

        return this;
    }
    //여기 위의 함수만
    public DamageField Build()
    {
        return damageField;
    }
}
