using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Trading : MonoBehaviour{
    // [Header("UI")]
    // public Image image;
    // public Text countText;
    // [HideInInspector] public Item item;
    // [HideInInspector] public int count=1;
    //public InventoryManager inventoryManager;
    // public InventoryItem inventoryItem;
    public Button button;
    // private void Start(){
    //     InitialiseItem(item);
    // }
    // public void InitialiseItem(Item newItem){
    //     item = newItem;
    //     image.sprite= newItem.image;
    // }
    public void trading(){
        InventoryItem inventoryItem=GetComponentInParent<InventoryItem>();
        InventoryManager inventoryManager=GameManager.instance.inventoryManager;
        String action=button.name;
        Item item=inventoryItem.item;
        if(action.Equals("Buy"))inventoryManager.buy(item,inventoryManager.traderInventory);
        else inventoryManager.sell(item,inventoryManager.inventorySlot);
    }
}
