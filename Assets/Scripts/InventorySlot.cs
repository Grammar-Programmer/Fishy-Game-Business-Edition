using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler{
    public virtual void OnDrop(PointerEventData eventData){
        InventoryItem inventoryItem = eventData.pointerDrag.GetComponent<InventoryItem>();
        if(inventoryItem.canBeDestroyed){
            Destroy(inventoryItem.gameObject);
        }  
        if(transform.childCount == 0 && !inventoryItem.item.type.Equals(Item.ItemType.Bait)){
            inventoryItem.parentAfterDrag = transform;
        }
    }
    void OnMouseDown() {
        print("OnMouseDown");
    }
}
