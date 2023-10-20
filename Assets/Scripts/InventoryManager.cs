using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour{
    public InventorySlot[] inventorySlot;
    public InventorySlot[] baitInventory;
    public InventorySlot selectedFishingRod;
    public InventorySlot selectedBait;
    public int money;
    public Text moneyText;
    public GameObject inventoryItemPrefab;
    public void addItem(Item item){
        if( item.type.Equals(Item.ItemType.Bait)) addToSelectedInventory(item,baitInventory);
        else addToSelectedInventory(item,inventorySlot);
    }
    public void addToSelectedInventory(Item item, InventorySlot[] inventory){

         for (int i = 0; i < inventory.Length; i++){
            InventorySlot slot= inventory[i];
            InventoryItem itemInSlot =slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot != null && itemInSlot.item==item && itemInSlot.count< 64){
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return;
            }
        }

        for (int i = 0; i < inventory.Length; i++){
            InventorySlot slot= inventory[i];
            InventoryItem itemInSlot =slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null){
                spawnNewItem(item,slot);
                return;
            }
        }
    }
    void spawnNewItem(Item item, InventorySlot slot){
        GameObject newItemGo =Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem =newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }
    public void updateMoney(int newMoney){
        if(money+newMoney<0) return;
        money+=newMoney;
        moneyText.text= newMoney.ToString();

    }
}
