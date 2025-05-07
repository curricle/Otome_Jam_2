using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Naninovel.UI;

public class UI_InventoryHandler : MonoBehaviour
{
    public SO_Item currentSelectedItem;
    public GameObject ui_currentSelectedItemPrefab;
    public UI_CurrentSelectedItem ui_currentSelectedItem;
    public GameObject inventorySlot;
    public GameObject inventorySlotGrid;

    private List<SO_Item> currentInventoryContents;

    void OnEnable()
    {
        InventoryHandler.onUpdateInventory += UpdateInventoryUI;
        InventoryHandler.onUpdateInventory += TestInventoryInvocation;
    }

    void OnDisable()
    {
        InventoryHandler.onUpdateInventory -= UpdateInventoryUI;
        InventoryHandler.onUpdateInventory -= TestInventoryInvocation;
    }

    public void TestInventoryInvocation(GameObject inventory) {
        Debug.Log("TestInventoryInvocation invoked");

        Debug.Log(inventory.GetComponent<InventoryHandler>().itemsInInventory[0]); 
    }

    public void UpdateInventoryUI(GameObject inventory) {
        //**do something
        //**for items in inventory, add slots...

        Debug.Log("UpdateInventoryUI called");
        currentInventoryContents = inventory.GetComponent<InventoryHandler>().itemsInInventory;
        for (int i = 0; i > currentInventoryContents.Count; i++) {
            inventorySlotGrid.transform.GetChild(i).GetChild(0).GetComponent<GameObject>().GetComponent<Image>().sprite = currentInventoryContents[i].itemSprite;
        }
        UpdateCurrentSelectedItemUI(inventory.GetComponent<InventoryHandler>().itemsInInventory[0]);
    }

    //**for now, use the first item in the inventory to display...
    public void UpdateCurrentSelectedItemUI(SO_Item selectedItem) {

        currentSelectedItem = selectedItem;
        
        ui_currentSelectedItem = ui_currentSelectedItemPrefab.GetComponent<UI_CurrentSelectedItem>();   
        ui_currentSelectedItem.ui_currentSelectedItemName.text = selectedItem.itemName;
        ui_currentSelectedItem.ui_currentSelectedItemDescription.text = selectedItem.itemDescription;
        ui_currentSelectedItem.ui_currentSelectedItemSprite.sprite = selectedItem.itemSprite; 
    }
}
