using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="Scriptable object/bait")]
public class Bait : Item{
    public Level useBait(){
        GameManager.instance.inventoryManager.removeToSelectedInventory(this,GameManager.instance.inventoryManager.baitInventory);
        GameManager.instance.inventoryManager.inventorySelectedBaitSlot.uptadeCount();
        return RandomVariables.catchAFishByRarity(rarityDictionary[rarity]);
    }
}
