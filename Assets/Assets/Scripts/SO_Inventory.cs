using System.Collections.Generic;
using UnityEngine;

public class SO_Inventory : ScriptableObject
{
    public int maxInventorySize = 8;
    public List<Item> itemsInInventory = new List<Item>();

}
