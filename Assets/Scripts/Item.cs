using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject{
    [Header("Only gameplay")]
    public ItemType type;
    protected IDictionary<String,Double> rarityDictionary=new Dictionary<String,Double>(){
        {"Commum",0.1},{"Rare",0.3},{"Expert",0.5},{"Legendary",0.6}
        }; 
    public String rarity;
    [Header("Only UI")]
    public bool stacktable= true;
    [Header("Both")]
    public Sprite image;
    public int price;
    
    public enum ItemType{
        Bait,
        FishRod,
        Fish
    }
}
