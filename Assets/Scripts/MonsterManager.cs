using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : Singleton<MonsterManager>
{
    Dictionary<int, Monster> monsters = new Dictionary<int, Monster>();
    private Dictionary<InCountArea, List<Monster>> monsterInCountArea = new();

    void Start()
    {
        // 1번방식
        EventManager.Instance.Subscribe((MessageTypeNotifyInCountArea areaMsg) =>
        {
            Entity entity = areaMsg.other.GetComponent<Entity>();
            if (entity is Monster j1)
            {
                if (!monsterInCountArea.ContainsKey(areaMsg.InCountArea))
                {
                    monsterInCountArea[areaMsg.InCountArea] = new List<Monster>();
                }
                
                monsterInCountArea[areaMsg.InCountArea].Add(j1);
            }
            else if (entity is Player j)
            {
                if (monsterInCountArea.TryGetValue(areaMsg.InCountArea, value: out var value))
                {
                    foreach (var monster in value)
                    {
                        monster.OnDetectPlayer(j);
                    }
                }
            }
        });
    }

    public void AddMonster(Monster monster)
    {
        monsters.Add(monster.GetInstanceID(), monster);
    }

    public void RemoveMonster(Monster monster)
    {
        monsters.Remove(monster.GetInstanceID());
    }
}