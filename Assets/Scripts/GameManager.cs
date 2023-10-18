
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    //Logic
    public int pesos;
    public int experience;

    public void ShowText(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration){
        floatingTextManager.Show(msg,fontSize,color,position,motion,duration);
    }
    //Save state
    public void SaveState(){
        print("SaveState");
        string s= "";
        s +="0"+"|";
        s += pesos.ToString() + "|";
        s += experience.ToString() + "|";
        s +="0";
        PlayerPrefs.SetString("SaveState",s);
    }
    public void LoadState(Scene s, LoadSceneMode mode){
        print("LoadState");
        SceneManager.sceneLoaded -=LoadState;
        if(!PlayerPrefs.HasKey("SaveState")) return;
        string[] data =PlayerPrefs.GetString("SaveState").Split('|');
        pesos =int.Parse(data[1]);
        experience =int.Parse(data[2]);
    }

}
