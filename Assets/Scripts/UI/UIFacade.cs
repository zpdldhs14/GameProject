using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 퍼사드 패턴
//리팩토링하기 쉬운 패턴이다.
public interface IUIPanel
{
    void Show();
    void Hide();
    void Update(float deltaTime);
}

public class InventoryFacadePattern
{
    public void SortInventory()
    {
        
    }

    public void Show()
    {
        
    }

    public void Add()
    {
        
    }
}

public class StatusFacadePattern
{
    public int GetShareHp()
    {
        return 1;
    }
}

public class ShopFacadePattern
{
    public void Buy()
    {
        
    }
}
public class UIFacade : MonoBehaviour
{
    IUIPanel currentPanel;
    
    InventoryFacadePattern inventory;
    StatusFacadePattern status;
    ShopFacadePattern shop;
    
    // Start is called before the first frame update
    void Start()
    {
        inventory = new InventoryFacadePattern();
        status = new StatusFacadePattern();
        shop = new ShopFacadePattern();
    }

    public void Show()
    {
       shop.Buy();
       inventory.Add();
       status.GetShareHp();
       inventory.Show();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentPanel != null)
        {
            currentPanel.Update(Time.deltaTime);
        }
    }
}
