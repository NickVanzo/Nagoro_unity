using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : MonoBehaviour
{
    public InventoryItemData referenceItem;
    [SerializeField] InventorySystem inventorySystem;
    public void OnHandlePickupItem()
    {
        inventorySystem.Add(referenceItem);
        Destroy(gameObject);
    }
}
