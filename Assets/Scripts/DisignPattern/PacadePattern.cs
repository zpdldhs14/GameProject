using System;
using System.Collections.Generic;
using UnityEngine;

public interface IAction
{
    void Doing();
}

public class PacadePattern : MonoBehaviour
{
    private IAction aAction;
    private IAction bAction;
    private IAction cAction;

    [SerializeField] private GameObject aObject; 
    [SerializeField] private GameObject bObject; 
    [SerializeField] private GameObject cObject; 
    
    // Start is called before the first frame update
    private void Start()
    {
        aAction = aObject.GetComponent<JumpAction>();
        bAction = bObject.GetComponent<RunAction>();
        cAction = cObject.GetComponent<ComboAction>();
    }

    public void DoActionA()
    {
        aAction.Doing();
    }

    public void DoActionB()
    {
        bAction.Doing();
    }

    public void DoActionC()
    {
        cAction.Doing();
    }
}
