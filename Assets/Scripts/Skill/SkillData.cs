using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//플라이 웨이트 패턴 -> 디자인 패턴 방식 (참조의 형태로 메모리는 하나지만 오브젝트가 많이 늘어나도 참조의 형태이기 때문에 데이터가 무거워지지 않음)
//스킬 데이터를 하나만 참조하고 인스턴스를 캐릭터마다 만든다.
[CreateAssetMenu(fileName = "SkillData", menuName = "Game/Skill Data")]
public class SkillData : ScriptableObject
{
    public string skillName;
    public string skillIcon;
    public string skillAnimation;
    
    public float skillDuration;
    public float skillCooltime;
    public float skillEnableDistance;
}