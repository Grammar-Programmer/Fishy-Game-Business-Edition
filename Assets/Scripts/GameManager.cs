
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour{
    public static GameManager instance;
    private void Awake(){
        if(GameManager.instance !=null){
            Destroy(gameObject);
            return;
        }
        instance=this;
        SceneManager.sceneLoaded +=LoadState;
        DontDestroyOnLoad(gameObject);
    }
    //Resources
    public List<Sprite>  playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;
    //References
    public PlayerController player;
    //public weapon
    public FloatingTextManager floatingTextManager;
    public InventoryManager inventoryManager;
    public int money=0;
    public Text textMoney;
    public void setMoney(int value){
        money+=value;
        textMoney.text=money.ToString();
    }

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration,Boolean forever=false){
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration,forever);
    }
    //Save state
    public void SaveState(){
        string s= "";
        s +="0"+"|";
        s +="0";
        PlayerPrefs.SetString("SaveState",s);
    }
    public void LoadState(Scene s, LoadSceneMode mode){
        SceneManager.sceneLoaded -=LoadState;
        if(!PlayerPrefs.HasKey("SaveState")) return;
        string[] data =PlayerPrefs.GetString("SaveState").Split('|');
    }

}
