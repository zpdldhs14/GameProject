using System.Collections;
using UnityEngine;

public class ComboAction : MonoBehaviour, IAction
{
    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    public void Doing()
    {
        StartCoroutine(Delay());
    }

    private IEnumerator Delay()
    {
        if (animator != null)
        {
            animator.Play("Jump");
        }
        yield return new WaitForSeconds(3.0f);
        
        if (animator != null)
        {
            animator.Play("Idles");
            animator.SetFloat("Speed", 1.0f);
            Debug.Log("3번 객체 Run");
        }
        
    }
}