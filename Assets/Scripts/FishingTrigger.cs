using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishingTrigger : MonoBehaviour
{
    public GameObject powerMinigame;
    public GameObject catchMinigame;

    public GameObject playerInventory;
    public GameObject activeSlots;
    private int numberOfTries = 1;
    private bool canFish; 
    public bool powerMiniGameOver;
    public bool selectMiniGameOver;
    private PowerMinigame powerGame;
    private SelectMiniGame selectMiniGame;
    Level level;
    public void Start(){
        powerGame = powerMinigame.GetComponent<PowerMinigame>();
        selectMiniGame = catchMinigame.GetComponent<SelectMiniGame>();
    }
    public void Update(){
        if(canFish && Input.GetKeyDown(KeyCode.E)){
            canFish=false;
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
            if (fishingRod == null){
                GameManager.instance.ShowText("You dont have a selected FishingRod", 20, Color.yellow, transform.position, Vector3.up, 5, false);
                return;
            }
            powerGame.fishingTrigger=this;
            powerMinigame.SetActive(true);
            powerGame.StartPowerUp();
        }
        if(powerMiniGameOver){
            powerMiniGameOver=false;
            powerMinigame.SetActive(false);
            Debug.Log(powerGame.result);
            FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
            Bait bait=(Bait)GameManager.instance.inventoryManager.inventorySelectedBaitSlot.GetComponentInChildren<InventoryItem>()?.item;
            if (!fishingRod.startFishing(numberOfTries, powerGame.result)){
                numberOfTries++;
                canFish=true;
                return;
            }
            numberOfTries = 0;
            level = bait != null ? bait.useBait() : RandomVariables.catchAFishByRarity(0.1);
            selectMiniGame.SetDifficulty((int)level);
            selectMiniGame.fishingTrigger=this;
            selectMiniGame.StartSelectMinigame();
        }
        if (selectMiniGameOver) {
            selectMiniGameOver=false;
            canFish=true;
            if(selectMiniGame.getHasWon()){
                GameManager.instance.ShowText("You catched a Fish!", 30, Color.yellow, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Vector3.down, 3, false);
                GameManager.instance.inventoryManager.addItem(LevelMethods.GetFishRarity(level));
            }else GameManager.instance.ShowText("You lost a Fish!", 30, Color.yellow, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Vector3.down, 3, false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.ShowText("Press E to Start Fishing", 20, Color.yellow, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Vector3.down, 0, true);
            canFish=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        powerMinigame.GetComponent<PowerMinigame>().EndPowerUp();
        if (other.CompareTag("Player")){
            canFish=false;
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
        }
    }
}