using System.Collections;
using UnityEngine;

[RequireComponent(typeof(FSMSystem))]
public class MonsterController : MonoBehaviour
{
    public string fsmType = "";
    private FSMSystem fsmSystem;

    [SerializeField]private float detectionRange = 10f;
    [SerializeField]private float attackRange = 2f;
    [SerializeField]private float maxHp = 100f;
    [SerializeField]private float chaseSpeed = 5f;
    
    public Transform target;
    
    private float currentHp;
    private bool bAttackFinisied = false;
    
    void Start()
    {
        currentHp = maxHp;
        fsmSystem = GetComponent<FSMSystem>();
        fsmSystem.Initialize(fsmType, this);
    }

    public bool IsDetectedTarget()
    {
        return target != null && (transform.position - target.position).sqrMagnitude <= detectionRange * detectionRange;
    }

    public bool CanAttack()
    {
        return target != null && (transform.position - target.position).sqrMagnitude <= attackRange * attackRange;
    }
    
    public bool IsAttacking()
    {
        return bAttackFinisied;
    }
    
    public void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);   
    }
    
    public void AttackToTarget()
    {
        Debug.Log("AttackToTarget");

        StartCoroutine(FinishAttack());
    }

    IEnumerator FinishAttack()
    {
        bAttackFinisied = false;

        yield return new WaitForSeconds(1f);

        bAttackFinisied = true;
    }
}