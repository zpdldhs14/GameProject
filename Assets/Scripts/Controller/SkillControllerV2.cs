using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class SkillController_V2 : MonoBehaviour
{
    private List<SkillInstanceJ_V2> skillInstances = new List<SkillInstanceJ_V2>();
    public List<string>         skillDataNames = new List<string>();
    private HashSet<SkillInstanceJ_V2>  availableSkills = new HashSet<SkillInstanceJ_V2>();
    
    public void AddAvailableSkill(SkillInstanceJ_V2 skill)
    {
        availableSkills.Add(skill);
    }

    public void RemoveAvailableSkill(SkillInstanceJ_V2 skill)
    {
        availableSkills.Remove(skill);
    }
    
    async void Start()
    {
        skillInstances = await SkillFactory.CreateSkill_V2(transform, skillDataNames);
        foreach (var skillInstanceJV2 in skillInstances)
        {
            AddAvailableSkill(skillInstanceJV2);
        }
    }

    public (float, SkillInstanceJ_V2) GetNearSkillDistanceAndSkill()
    {
        float distance = float.MaxValue;
        SkillInstanceJ_V2 skill = null;

        foreach (var skillInstanceJv2 in availableSkills)
        {
            if (distance >= skillInstanceJv2.CanSkillEnableDistance())
            {
                distance = skillInstanceJv2.CanSkillEnableDistance();
                skill = skillInstanceJv2;
            }
        }

        return (distance, skill);
    }

    public SkillData FireSkill(SkillInstanceJ_V2 skill)
    {
        skill.FireSkill();
        return skill.SkillData;
    }
}