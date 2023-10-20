using UnityEngine.EventSystems;

public class InventoryFishRodSlot : InventorySlot{
     public override void OnDrop(PointerEventData eventData){
        if( eventData.pointerDrag.GetComponent<InventoryItem>().item.type.Equals(Item.ItemType.FishRod))
        base.OnDrop(eventData);
    }
}
