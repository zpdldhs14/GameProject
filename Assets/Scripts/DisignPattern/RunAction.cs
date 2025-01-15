using UnityEngine;

public class RunAction : MonoBehaviour, IAction
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
            animator.Play("Idles");
            animator.SetFloat("Speed", 1.0f);
            Debug.Log("RunAction");
        }
        
    }
}