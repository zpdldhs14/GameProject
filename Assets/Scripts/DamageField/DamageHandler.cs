using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//데미지를 입힐 때, 서로 추가 데미지를 주는 것들을 연쇄적으로 일어나게 하는 패턴 -> 책임 연쇄 패턴
//빌더패턴이랑 섞임
public abstract class DamageHandler
{
   //노드랑 비슷하다고 보면 됨.
   protected DamageHandler nextHandler;

   public DamageHandler setNextHandler(DamageHandler nextHandler)
   {
       this.nextHandler = nextHandler;
       return this.nextHandler;
   }

   public abstract float HandleDamage(float damage);
}
public class DamageCalculation_Ver1 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage += 100.0f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}

public class DamageCalculation_Ver2 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage *= 2.0f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}

public class DamageCalculation_Ver3 : DamageHandler
{
    public override float HandleDamage(float damage)
    {
        damage *= 0.3f;
        return nextHandler?.HandleDamage(damage) ?? damage;
    }
}