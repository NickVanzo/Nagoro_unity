using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] Transform itemsParent;
    InventorySlot[] slots;
    [SerializeField] InventorySystem inventory = null;

    void Start()
    {
        InventorySystem.OnItemAddedCallback += UpdateUI;
        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
    }

    void UpdateUI(InventoryItem item)
    {
        Debug.Log("Updating UI");
        Dictionary<InventoryItemData, InventoryItem> itemsInInventory = inventory.GetItems();
        InventoryItemData[] itemData = new InventoryItemData[itemsInInventory.Count];
        int i = 0;
        Debug.Log("Size of inventory dictionary: " + itemsInInventory.Count);
        foreach (KeyValuePair<InventoryItemData, InventoryItem> keyValuePair in itemsInInventory)
        {
            itemData[i] = keyValuePair.Key;
        }
        for (int j = 0; j < slots.Length; j++)
        {
            if (j < itemData.Length)
            {
                slots[j].AddItem(itemData[j]);
            }
        }

    }
}
