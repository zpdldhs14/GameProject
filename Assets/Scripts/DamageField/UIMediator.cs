using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IMediator
{
    void notifyHealthChanged(int health);
}
//체력을 관리하기 위함. 메디에이터 패턴 사용
public class UIMediator : MonoBehaviour ,IMediator
{
    private MonsterStatus monsterStatus;
    public Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        monsterStatus = GetComponent<MonsterStatus>();
        monsterStatus.SetMediator(this);
    }

    public void notifyHealthChanged(int health)
    {
        
        UpdateHealthBar(health);
    }

    private void UpdateHealthBar(int currenthealth)
    {
        float fillAmount = Mathf.Clamp01((float)currenthealth / 100f);
        healthBar.fillAmount = fillAmount;
        Debug.Log($"current health : {currenthealth}");
    }
}
