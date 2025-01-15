using UnityEngine;

public class MonsterHpbar : MonoBehaviour
{
    public Camera mainCamera; // 게임에서 사용하는 메인 카메라
    public Transform monster; // HP바를 따라갈 몬스터의 Transform
    public RectTransform hpBarUI; // 화면에 표시할 UI HP바 (RectTransform)

    private Vector3 offset = new Vector3(0, 2f, 0); // 몬스터 위에 HP바를 표시하기 위한 오프셋 값

    void Update()
    {
        if (monster == null || hpBarUI == null) return;

        // 몬스터 월드 위치에서 오프셋 위치 계산
        Vector3 worldPosition = monster.position + offset;

        // 월드 좌표를 화면 좌표로 변환
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(worldPosition);

        // 화면 내에 보이는 경우에만 HP바를 업데이트
        if (screenPosition.z > 0) // Z값이 0보다 커야 화면에 렌더링됨
        {
            hpBarUI.gameObject.SetActive(true); // HP바 활성화
            hpBarUI.position = screenPosition; // HP바를 스크린 좌표에 맞춤
        }
        else
        {
            hpBarUI.gameObject.SetActive(false); // 화면 밖이면 비활성화
        }
    }
}