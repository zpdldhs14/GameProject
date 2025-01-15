using UnityEngine;

public class Client : MonoBehaviour
{
    private PacadePattern facade;

    private void Start()
    {
        facade = FindObjectOfType<PacadePattern>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            facade.DoActionA();
            facade.DoActionB();
            facade.DoActionC();
        }
        
        
    }
}