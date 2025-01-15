// #define SKILL_V2

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[State("ChaseState")]
public class ChaseState_Monster : Common_Monster
{
    public override void Enter()
    {
        Blackboard.animator.Play("Idles");
        Blackboard.animator.SetFloat("Speed", 1.0f);
    }

    public override void UpdateState(float deltaTime)
    {
        if (Blackboard.target == null)
        {
            Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
            return;
        }
        
        #if SKILL_V2
            var (skillDistance, skill) = Blackboard.SkillController_V2.GetNearSkillDistanceAndSkill();
            if (skill == null)
            {
                Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
                return;
            }
                
            float attackRnageSqr = skillDistance * skillDistance;
            if (Vector3.SqrMagnitude(Blackboard.target.transform.position - Fsm.transform.position) > attackRnageSqr)
            {
                Vector3 newPos = Vector3.MoveTowards(
                    Fsm.transform.position, 
                    Blackboard.target.transform.position, 
                    Blackboard.moveSpeed * deltaTime
                );
                    
                Blackboard.rigidbody.MovePosition(newPos);
                return;
            }

            Fsm.ChangeState(StateTypesClasses.StateTypes.SkillState);
        #else
            var (skillDistance, skillIndex) = Blackboard.SkillController.GetNearSkillDistanceAndIndex();
            if (0 > skillIndex)
            {
                Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
                return;
            }
            
            float attackRnageSqr = skillDistance * skillDistance;
            if (Vector3.SqrMagnitude(Blackboard.target.transform.position - Fsm.transform.position) > attackRnageSqr)
            {
                Vector3 newPos = Vector3.MoveTowards(
                    Fsm.transform.position, 
                    Blackboard.target.transform.position, 
                    Blackboard.moveSpeed * deltaTime
                    );
                
                Blackboard.rigidbody.MovePosition(newPos);
                return;
            }

            Fsm.ChangeState(StateTypesClasses.StateTypes.SkillState);
        #endif
        
        Debug.Log("ChaseState_MonsterJ.Enter"); 

        // 숙제
        // 타겟이 있다면 어택레인지까지 쫓아가서 스킬스테이트로 바꾸고 스킬을 쓰고 아이들스테이트로 돌아가기
    }

    public override void Exit()
    {
        
    }
}
