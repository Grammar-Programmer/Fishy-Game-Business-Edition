using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour{
    public InventorySlot[] inventorySlot;
    public InventorySlot[] baitInventory;
    public InventorySlot[] traderInventory;
    public InventorySlot selectedFishingRod;
    public InventorySlot selectedBait;
    public Item[] initialItems;
    public int money;
    public Text moneyText;
    public GameObject inventoryItemPrefab;
    public Boolean normalMode=true;
    public void Start(){
        for (int i = 0; i < initialItems.Length; i++)
            addToSelectedInventory(initialItems[i],traderInventory,"Buy by "+initialItems[i].price);
    }
    public void uptadeTrader(){
        LinkedList<Item> items=new LinkedList<Item>();
        InventoryItem inventoryItem;
        foreach(InventorySlot inventorySlot in traderInventory){
            inventoryItem=inventorySlot.GetComponentInChildren<InventoryItem>();
            if(inventoryItem!=null){
                print("ola");
                items.AddLast(inventoryItem.item);
                Destroy(inventoryItem.gameObject);
            }
        }
        int i=0;
        foreach(Item item in items){
            spawnNewItem(item,traderInventory[i],"Buy by "+item.price);
            i++;
        }


        // for (int i = 0; i < traderInventory.Length; i++){
        //     if(traderInventory[i].GetComponentInChildren<InventoryItem>()!=null) continue;
        //     for (int j = i+1; j < traderInventory.Length; j++){
        //         if(traderInventory[j].GetComponentInChildren<InventoryItem>()!=null){
        //         traderInventory[i]=traderInventory[j];
        //         break;
        //         }
        //     }
        //  }

    }
    public void addItem(Item item){
        if( item.type.Equals(Item.ItemType.Bait)) addToSelectedInventory(item,baitInventory,"Sell by "+item.price);
        else addToSelectedInventory(item,inventorySlot,"Sell by "+item.price);
    }
    public void addToSelectedInventory(Item item, InventorySlot[] inventory,String tag){

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
                spawnNewItem(item,slot,tag);
                return;
            }
        }
    }
    public void removeToSelectedInventory(Item item, InventorySlot[] inventory){
         for (int i = 0; i < inventory.Length; i++){
            InventorySlot slot= inventory[i];
            InventoryItem itemInSlot =slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot != null && itemInSlot.item==item){
                if(--itemInSlot.count==0)Destroy(itemInSlot.gameObject);
                else itemInSlot.RefreshCount();
                return;
            }
        }
    }
    public void sell(Item item, InventorySlot[] inventory){
        GameManager.instance.setMoney(item.price);
        removeToSelectedInventory(item,inventory);    
    }
    public void buy(Item item, InventorySlot[] inventory){
        if( GameManager.instance.money-item.price<0) return;
        GameManager.instance.setMoney(-item.price);
        addItem(item);
        if(item.type.Equals(Item.ItemType.FishRod))removeToSelectedInventory(item,inventory);    
    }
    void spawnNewItem(Item item, InventorySlot slot,String tag){
        GameObject newItemGo =Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem =newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
        inventoryItem.button.name=tag;
        inventoryItem.button.GetComponentInChildren<Text>().text=tag;
    }
    public void setFishingRod(InventorySlot inventorySlot){
        selectedFishingRod=inventorySlot;
    }
}