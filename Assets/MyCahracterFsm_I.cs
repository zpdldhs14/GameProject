using System.Collections;
using UnityEngine;

public class EnityFsmI : MonoBehaviour
{
    private StateMachine stateMachine;
    [SerializeField]private StaterType stateType;
    
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        stateMachine.Run(stateType);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.UpdateState();
    }
}
