using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
   public string itemName; // 아이템 이름
   public Sprite itemIcon; // 아이템 아이콘
   public string description; // 설명
   public int quantity; // 개수

   public bool isStackable; // 스택 가능한지 여부

   public Item(string name, Sprite icon, string desc, int qty, bool stackable)
   {
      itemName = name;
      itemIcon = icon;
      description = desc;
      quantity = qty;
      isStackable = stackable;
   }
}

public class InventoryManager : MonoBehaviour
{
   public static InventoryManager instance;

   private void Awake()
   {
      if(instance != null && instance != this)
      {
         Destroy(gameObject);
         return;
      }
      instance = this;
      DontDestroyOnLoad(gameObject);
   }
   
   public List<Item> inventoryItems = new List<Item>();
   public int maxSlots = 20;
   public delegate void OnItemChanged();
   public OnItemChanged onItemChanged;

   public bool AddItem(Item item)
   {
      if (inventoryItems.Count >= maxSlots)
      {
         Debug.Log("inventory is full");
         return false;
      }
      inventoryItems.Add(item);
      
      onItemChanged?.Invoke();
      return true;
   }

   public void RemoveItem(Item item)
   {
      if (inventoryItems.Contains(item))
      {
         inventoryItems.Remove(item);
         onItemChanged?.Invoke();
      }
   }
}
