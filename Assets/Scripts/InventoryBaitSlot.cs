using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryBaitSlot : InventorySlot{
    public override void OnDrop(PointerEventData eventData){
        InventoryItem inventoryItem= eventData.pointerDrag.GetComponent<InventoryItem>();
        if( transform.childCount == 0 && inventoryItem.item.type.Equals(Item.ItemType.Bait)){
            inventoryItem.parentAfterDrag = transform;
        }
    }
}
