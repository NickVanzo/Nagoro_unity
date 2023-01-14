using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Inventory Item Data")]
public class InventoryItemData : ScriptableObject
{
    [SerializeField] string id;
    [SerializeField] string displayName;
    [SerializeField] Sprite icon;
    [SerializeField] GameObject prefab;

    public Sprite GetIcon()
    {
        return icon;
    }
}
