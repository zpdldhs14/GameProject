using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStatus : MonoBehaviour
{
    //프로퍼티 바인딩
    private int hp = 100;
    public int Hp
    {
        get => hp;
        set
        {
            hp = value;
            mediator.notifyHealthChanged(hp);
            if (hp <= 0)
            {
                GetComponent<Animator>().Play("Die");
                Destroy(gameObject,2.0f);
            }
        }
    }
    public int Atk;
    public int Def;
    public float Speed;
    
    private IMediator mediator;
    
    public void SetMediator(IMediator mediator)
    {
        this.mediator = mediator;
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        Debug.Log(Hp);
        mediator?.notifyHealthChanged(Hp);
    }
}