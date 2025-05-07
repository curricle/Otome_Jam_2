using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public GameObject currentInventory;
    public SO_Inventory inventoryData;
    public string inventoryName;
    public List<SO_Item> itemsInInventory;
    public int maxInventorySize;

    // **might have to break up inventory handler and inventory into two separate scripts
    public static Action<GameObject> onUpdateInventory;

    void Awake() {
        //Assign ScriptableObject data to this GameObject
        currentInventory = gameObject;
        inventoryName = inventoryData.inventoryName;
        itemsInInventory = inventoryData.itemsInInventory;
        maxInventorySize = inventoryData.maxInventorySize;
    }
    void OnEnable() {
        //Subscribe to the Item.onItemPickup event and trigger the AddItemToInventory method when fired
        Item.onItemPickup += AddItemToInventory;
    }

    void OnDisable() {
        //Unsubscribe to the Item.onItemPickup event
        Item.onItemPickup -= AddItemToInventory;
    }

    void Start()
    {
        onUpdateInventory?.Invoke(currentInventory);
        Debug.Log("InventoryHandler started, onUpdateInventory invoked");
    }

    public void AddItemToInventory(SO_Item item) {
        if (itemsInInventory.Count < maxInventorySize) {
            itemsInInventory.Add(item);
            Debug.Log(itemsInInventory.Count);

            //Let everybody know an item has been added to the inventory
            onUpdateInventory?.Invoke(currentInventory);
        }
        else {
            Debug.Log("Inventory full!");
        }
    }
}
