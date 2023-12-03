using UnityEngine;
[System.Serializable]
public class GameData{
    public bool firstTime=true;
    public Vector3 playerPosition;
    // public InventoryManager inventoryManager;
    public int money;
    public InventoryItem[] inventoryitem;
    public GameData(){
        this.money=0;
        this.playerPosition=new Vector3(22,1,0);
    }
}