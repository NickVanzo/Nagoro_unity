using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    InventoryItemData item;
    public void AddItem(InventoryItemData newItem)
    {
        item = newItem;
        icon.sprite = item.GetIcon();
        icon.enabled = true;
    }

    public InventoryItemData GetItem()
    {
        return item;
    }
}
