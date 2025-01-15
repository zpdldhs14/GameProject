using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class SkillFactory
{
    public static async UniTask<List<SkillInstance>> CreateSkill(Transform parent, List<string> skillNames)
    {
        List<SkillData> skillDatas = new List<SkillData>();
        
        foreach (var skillName in skillNames)
        {
            var handle = Addressables.LoadAssetAsync<SkillData>($"Assets/SkillData/{skillName}.asset");
            await handle.Task;

            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                skillDatas.Add(handle.Result);
                
                Debug.Log($"Loaded {skillName}");
            }
            else
            {
                Debug.LogError($"Failed to load skill data: {skillName}");
            }
        }
        
        List<SkillInstance> skills = new List<SkillInstance>();
        
        foreach (var skillDataJ in skillDatas)
        {
            var go = new GameObject(skillDataJ.name);
            SkillInstance instanceJ = go.AddComponent<SkillInstance>();
            instanceJ.SkillData = skillDataJ;
            go.transform.SetParent(parent);
            skills.Add(instanceJ);
        }
        
        return skills;
    }
    
    public static async UniTask<List<SkillInstanceJ_V2>> CreateSkill_V2(Transform parent, List<string> skillNames)
    {
        List<SkillData> skillDatas = new List<SkillData>();
        
        foreach (var skillName in skillNames)
        {
            var handle = Addressables.LoadAssetAsync<SkillData>($"Assets/SkillData/{skillName}.asset");
            await handle.Task;
    
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                skillDatas.Add(handle.Result);
                
                Debug.Log($"Loaded {skillName}");
            }
            else
            {
                Debug.LogError($"Failed to load skill data: {skillName}");
            }
        }
        
        List<SkillInstanceJ_V2> skills = new List<SkillInstanceJ_V2>();
        
        foreach (var skillDataJ in skillDatas)
        {
            var go = new GameObject(skillDataJ.name);
            SkillInstanceJ_V2 instanceJ = go.AddComponent<SkillInstanceJ_V2>();
            instanceJ.SkillData = skillDataJ;
            instanceJ.Owner = parent.gameObject;
            go.transform.SetParent(parent);
            skills.Add(instanceJ);
        }
        
        return skills;
    }
}