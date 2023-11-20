using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoScript : MonoBehaviour{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public void PickupItem(int id){
        inventoryManager.addItem(itemsToPickup[id]);
    }
    public void addRandomCommumFish(){
        inventoryManager.addItem(inventoryManager.getCommumFish());
    }
    public void addRandomRareFish(){
        inventoryManager.addItem(inventoryManager.getRareFish());
    }
    public void addRandomLegendaryFish(){
        inventoryManager.addItem(inventoryManager.getLegendaryFish());
    }
}
