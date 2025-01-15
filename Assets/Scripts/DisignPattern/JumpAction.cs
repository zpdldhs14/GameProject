using UnityEngine;

public class JumpAction : MonoBehaviour, IAction
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Doing()
    {
        if (animator != null)
        {
            animator.Play("Jump");
        }
    }
}