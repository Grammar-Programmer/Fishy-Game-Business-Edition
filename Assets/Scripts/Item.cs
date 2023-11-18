using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName ="Scriptable object/Item")]
public class Item : ScriptableObject{
    [Header("Only gameplay")]
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5,4);
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
    public enum ActionType{
        Fishing,
        Trading
    }

}