using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject slotPrefab;
    
    private List<GameObject> slots = new();

    private void Start()
    {
        GenerateSlots(InventoryManager.instance.maxSlots);
        InventoryManager.instance.onItemChanged += UpdateUI;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryPanel.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            inventoryPanel.SetActive(false);
        }
    }

    private void GenerateSlots(int slotCount)
    {
        for (int i = 0; i < slotCount; i++)
        {
            // slotPrefab을 inventoryPanel의 자식으로 생성
            var slot = Instantiate(slotPrefab, inventoryPanel.transform);

            // 슬롯 UI 위치 초기화
            slot.transform.localPosition = Vector3.zero;

            // 슬롯을 리스트에 추가
            slots.Add(slot);
        }
    }

    private void UpdateUI()
    {
        var inventory = InventoryManager.instance.inventoryItems;
        for (int i = 0; i < slots.Count; i++)
        {
            if (i < inventory.Count)
            {
                var slot = slots[i].GetComponent<InventorySlot>();
                slot.SetItem(inventory[i]);
            }
            else
            {
                slots[i].GetComponent<InventorySlot>().ClearSlot();
            }
        }
    }
}
