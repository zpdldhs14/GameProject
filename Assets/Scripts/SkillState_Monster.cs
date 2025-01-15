using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[State("SkillState")]
public class SkillState_Monster : Common_Monster
{
    public override void Enter()
    {
        Debug.Log("SkillState_MonsterJ.Enter");
        FireSkill();
    }

    public override void UpdateState(float deltaTime)
    {
    }

    public override void Exit()
    {
        Debug.Log("SkillState_MonsterJ.Exit");
    }

    async void FireSkill()
    {
        var (distance, skillIndex) = Blackboard.SkillController.GetNearSkillDistanceAndIndex();

        var skillData = Blackboard.SkillController.FireSkillByIndex(skillIndex);
        Blackboard.animator.Play(skillData.skillAnimation);
        
        await UniTask.Delay((int)(skillData.skillDuration * 1000));
        Debug.Log("OnFireSkill 2");

        Fsm.ChangeState(StateTypesClasses.StateTypes.IdleState);
    }
}