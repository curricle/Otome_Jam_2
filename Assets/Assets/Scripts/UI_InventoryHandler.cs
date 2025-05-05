using UnityEngine;

public class UI_InventoryHandler : MonoBehaviour
{
    public Item currentSelectedItem;
    public GameObject ui_currentSelectedItemPrefab;
    public UI_CurrentSelectedItem ui_currentSelectedItem;
    public GameObject inventorySlot;

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
        Debug.Log(inventory.GetComponent<InventoryHandler>().itemsInInventory[0]);
    }

    public void UpdateInventoryUI(GameObject inventory) {
        //**do something
        //**for items in inventory, add slots...
        UpdateCurrentSelectedItemUI(inventory.GetComponent<InventoryHandler>().itemsInInventory[0]);
    }

    //**for now, use the first item in the inventory to display...
    public void UpdateCurrentSelectedItemUI(Item selectedItem) {

        //**FOR SOME REASON THE ITEM VALUES ARE NOT COMING THROUGH

        currentSelectedItem = selectedItem;

        Debug.Log(selectedItem.itemName);
        
        ui_currentSelectedItem = ui_currentSelectedItemPrefab.GetComponent<UI_CurrentSelectedItem>();   
        ui_currentSelectedItem.ui_currentSelectedItemName.text = selectedItem.itemName;
        ui_currentSelectedItem.ui_currentSelectedItemDescription.text = selectedItem.itemDescription;
        ui_currentSelectedItem.ui_currentSelectedItemSprite.sprite = selectedItem.itemSprite; 
    }
}
