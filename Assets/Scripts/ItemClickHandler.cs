using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    [SerializeField] Inventory inventory;
   public void OnItemClicked()
    {
        ItemDragHandler dragHandler =
            gameObject.transform.Find("item").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.Item;
       // Debug.Log(item.Name);
        inventory.UseItem(item);
        item.OnUse();
    }
}