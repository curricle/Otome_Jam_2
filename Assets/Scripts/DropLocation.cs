using UnityEngine;
using UnityEngine.EventSystems;

public class DropLocation : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Dropped!");
    }

}
