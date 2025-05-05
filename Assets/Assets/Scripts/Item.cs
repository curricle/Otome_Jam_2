using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public SO_Item itemData;
    public Item currentItem;

    public string itemName;
    public GameObject itemGameObject;
    public Sprite itemSprite;
    public bool isItemUnique;
    [TextArea(5, 5)] public string itemDescription;
    public int itemAmount;  

    void Awake()
    {
        //Assign ScriptableObject data to this GameObject
        currentItem = GetComponent<Item>();
        itemName = itemData.name;
        itemGameObject = itemData.itemGameObject;
        itemSprite = itemData.itemSprite;
        isItemUnique = itemData.isItemUnique;
        itemDescription = itemData.itemDescription;
        itemAmount = itemData.amount;
    }

    public static event Action<Item> onItemPickup;
    public void OnItemPickup() {
        //checks if anything is subscribed to this event (is not null) before firing
        onItemPickup?.Invoke(currentItem);
    }

    public void ListItemProperties() {
        Debug.Log($"currentItem: {currentItem}\nitemName: {itemName}\nitemGameObject: {itemGameObject}\nitemSprite: {itemSprite}\nisItemUnique: {isItemUnique}\nitemDescription: {itemDescription}\nitemAmount: {itemAmount}");
    }

}
