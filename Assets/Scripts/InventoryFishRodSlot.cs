using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class InventoryFishRodSlot : InventorySlot{
     public override void OnDrop(PointerEventData eventData){
        InventoryItem inventoryItem=eventData.pointerDrag.GetComponent<InventoryItem>();
        InventoryItem actualInventoryItem=GetComponentInChildren<InventoryItem>();
        if(inventoryItem.item.type.Equals(Item.ItemType.FishRod)){
            if(actualInventoryItem!=null) Destroy(actualInventoryItem.gameObject);
            GameObject newItemGo =Instantiate(GameManager.instance.inventoryManager.inventoryItemPrefab, transform);
            InventoryItem newInventoryItem =newItemGo.GetComponent<InventoryItem>();
            newInventoryItem.InitialiseItem(inventoryItem.item );
            newInventoryItem.count=inventoryItem.count;
            newInventoryItem.canBeDestroyed=true;
            GameManager.instance.inventoryManager.setFishingRod((FishingRod)newInventoryItem.item);
            // inventoryItem.button.name=tag;
            // inventoryItem.button.GetComponentInChildren<Text>().text=tag;
        }
        // base.OnDrop(eventData);
    }
}
