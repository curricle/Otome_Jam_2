using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Inventory", menuName = "Items/Default Inventory")]
public class SO_Inventory : ScriptableObject
{
    public int maxInventorySize;
    public string inventoryName;
    public List<SO_Item> itemsInInventory = new List<SO_Item>();

}
