using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySelectedBaitSlot : InventoryBaitSlot{
    public override void OnDrop(PointerEventData eventData){
        InventoryItem inventoryItem= eventData.pointerDrag.GetComponent<InventoryItem>();
        InventoryItem actualInventoryItem=GetComponentInChildren<InventoryItem>();
        if(inventoryItem.item.type.Equals(Item.ItemType.Bait)){
            if(actualInventoryItem!=null) Destroy(actualInventoryItem.gameObject);
            GameObject newItemGo =Instantiate(GameManager.instance.inventoryManager.inventoryItemPrefab, transform);
            InventoryItem newInventoryItem =newItemGo.GetComponent<InventoryItem>();
            newInventoryItem.InitialiseItem(inventoryItem.item);
            newInventoryItem.canBeDestroyed=true;
            newInventoryItem.count=inventoryItem.count;
        }
    }
}
