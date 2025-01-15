using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class StatsPanel : MonoBehaviour , IUIComponent
{
    public int Hp;
    public int Atk;
    public TextMeshProUGUI HpText;
    public TextMeshProUGUI AtkText;
    
    private GameObject Stats;
    
    public void Initialize()
    {
        var hpTransform = transform.Find("HpText");
        if (hpTransform != null && hpTransform.TryGetComponent<TextMeshProUGUI>(out HpText))
        {
            Debug.Log("HpText 성공적으로 초기화");
        }
        else
        {
            Debug.LogError("HpText 찾을 수 없음!");
        }

        // AtkText UI 가져오기
        var atkTransform = transform.Find("AtkText");
        if (atkTransform != null && atkTransform.TryGetComponent<TextMeshProUGUI>(out AtkText))
        {
            Debug.Log("AtkText 성공적으로 초기화");
        }
        else
        {
            Debug.LogError("AtkText 찾을 수 없음!");
        }
    }

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

    public void UpdateUi()
    {
        //스탯이 바뀌면 스탯을 바꾸는 역할을 해주면 됨.
        if (HpText != null && AtkText != null)
        {
            HpText.text = $"HP : {Hp.ToString()}";
            AtkText.text = $"Atk : {Atk.ToString()}";
        }
    }

    public void ResetState()
    {
        
    }

    public void CleanUp()
    {
        //ui release
    }
}