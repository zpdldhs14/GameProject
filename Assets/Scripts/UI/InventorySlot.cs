using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon; // 아이템 아이콘 UI
    public Button removeButton; // 제거 버튼

    private Item item;

    public void SetItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.itemIcon;
        icon.enabled = true;
        removeButton.gameObject.SetActive(true);
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.gameObject.SetActive(false);
    }

    public void OnRemoveButton()
    {
        InventoryManager.instance.RemoveItem(item);
    }

    public void UseItem()
    {
        if (item != null)
        {
            Debug.Log($"아이템 사용: {item.itemName}"); // 커맨드 패턴 확장 가능
        }
    }
}