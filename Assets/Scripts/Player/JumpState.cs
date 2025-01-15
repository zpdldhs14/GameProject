using UnityEngine;
[State("JumpState")]
public class JumpState : MonoBehaviour, IState
{
    public StateMachine Fsm { get; set; }
    
    public Blackboard_Player Blackboard { get; set; }
    
    public void InitState(IBlackboardBase blackboard)
    {
        Blackboard = blackboard as Blackboard_Player;
    }

    public void Enter()
    {
        Blackboard.Animator.CrossFade("Jump", 0.1f);
        Blackboard.Rigidbody.velocity = new Vector3(Blackboard.Rigidbody.velocity.x, Blackboard.JumpForce, Blackboard.Rigidbody.velocity.z);
    }

    public void UpdateState(float deltaTime)
    {
        if (Blackboard.Rigidbody.velocity.y == 0.0f)
        {
            Fsm.ChangeState<IdleState>();
        }
    }

    public void Exit()
    {
    }
}