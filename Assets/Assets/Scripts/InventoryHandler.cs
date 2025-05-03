using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject currentInventory;
    public SO_Inventory inventoryData;
    public string inventoryName;
    public List<Item> itemsInInventory = new List<Item>();
    public int maxInventorySize;

    void OnEnable() {
        //Subscribe to the Item.onItemPickup event and trigger the AddItemToInventory method when fired
        Item.onItemPickup += AddItemToInventory;
    }

    void OnDisable() {
        //Unsubscribe to the Item.onItemPickup event
        Item.onItemPickup -= AddItemToInventory;
    }

    void Awake() {
        //Assign ScriptableObject data to this GameObject
        currentInventory = gameObject;
        inventoryName = inventoryData.inventoryName;
        itemsInInventory = inventoryData.itemsInInventory;
        maxInventorySize = inventoryData.maxInventorySize;
    }

    public void AddItemToInventory(Item item) {
        if (itemsInInventory.Count < maxInventorySize) {
            itemsInInventory.Add(item);
            Debug.Log(itemsInInventory.Count);
        }
        else {
            Debug.Log("Inventory full!");
        }
    }
}
