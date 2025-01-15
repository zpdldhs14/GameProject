using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//컴포지트 패턴
public interface IUIComponent
{
    void Initialize();
    void SetActive(bool active);
    void UpdateUi();
    void ResetState();
    void CleanUp();
}

public class InventoryWindow : MonoBehaviour , IUIComponent
{
    //특징 : 자식들도 IUIComponent를 가진다.
    private List<IUIComponent> components = new List<IUIComponent>();

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        components.Add(GetComponent<StatsPanel>());
        components.Add(GetComponent<ItemListPanel>());
        
        foreach (var uiComponent in components)
        {
            uiComponent.Initialize();
        }
    }

    public void SetActive(bool active)
    {
        foreach (var uiComponent in components)
        {
            uiComponent.SetActive(active);
        }

        gameObject.SetActive(active);
    }

    private void Update()
    {
        UpdateUi();
    }

    public void UpdateUi()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.UpdateUi();
        }
    }
//Reset이나 clean은 disable에서 불러주면 된다.
    public void ResetState()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.ResetState();
        }
    }

    public void CleanUp()
    {
        foreach (var uiComponent in components)
        {
            uiComponent.CleanUp();
        }
    }
}