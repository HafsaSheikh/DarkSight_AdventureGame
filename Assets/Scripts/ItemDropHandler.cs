using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDropHandler : MonoBehaviour, IDropHandler
{
    public Inventory inventory;
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invertoryPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invertoryPanel,Input.mousePosition))
        {
            Debug.Log("Item Dropped");
            IInventoryItem item = eventData.pointerDrag.gameObject.GetComponent<ItemDragHandler>().Item;
            if (item != null)
            {
                inventory.RemoveItem(item);
                item.OnDrop();
            }
        }
    }

   
}
