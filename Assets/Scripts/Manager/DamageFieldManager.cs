using System.Collections;
using UnityEngine;

public class DamageFieldManager : MonoBehaviour
{
    private DamageFieldPool damageFieldPool;

    private void Start()
    {
        damageFieldPool = GetComponent<DamageFieldPool>();
    }

    public void CreateRandomDamageField(Vector3 position)
    {
        // 랜덤 옵션 적용
        DamageHandler handler = null;
        int randomOption = UnityEngine.Random.Range(0, 2);
        if (randomOption == 0)
        {
            handler = new DamageCalculation_Ver1(); // Burning 효과
        }
        else
        {
            handler = new DamageCalculation_Ver2(); // Freezing 효과
        }

        // DamageField 생성 및 설정
        DamageField damageField = new DamageFieldBuilder(damageFieldPool)
            .SetDamage(UnityEngine.Random.Range(10f, 20f)) // 랜덤 데미지
            .SetRadius(5f)
            .SetDuration(3f)
            .SetTickInterval(1f)
            .SetPosition(position)
            .SetDamageHandler(handler)
            .Build();

        StartCoroutine(HandleDamageField(damageField));
    }

    private IEnumerator HandleDamageField(DamageField damageField)
    {
        float duration = damageField.duration;
        while (duration > 0)
        {
            yield return new WaitForSeconds(damageField.tickInterval);
            var damage = damageField.GetCalculatedDamage();

            // 데미지 계산 (몬스터와 상호작용 구현)
            ApplyDamageToMonsters(damageField, damage);

            duration -= damageField.tickInterval;
        }

        // DamageField 반환
        damageFieldPool.ReturnDamageField(damageField);
    }

    private void ApplyDamageToMonsters(DamageField damageField, float damage)
    {
        Collider[] hitColliders = Physics.OverlapSphere(damageField.transform.position, damageField.radius);
        foreach (var collider in hitColliders)
        {
            var monster = collider.GetComponent<MonsterStatus>();
            if (monster != null)
            {
                monster.Hp -= (int)damage;

                if (monster.Hp <= 0)
                {
                    // 몬스터 "죽음" 처리
                    Destroy(monster.gameObject);
                }
            }
        }
    }
}