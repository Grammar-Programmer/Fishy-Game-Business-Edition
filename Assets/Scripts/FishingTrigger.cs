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
        if(canFish && Input.GetKeyDown(KeyCode.E) && !powerMiniGameOver && !selectMiniGameOver ){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
            if (fishingRod == null){
                GameManager.instance.ShowText("You dont have a selected FishingRod", 15, Color.yellow, transform.position, Vector3.up, 5, false);
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
            GameManager.instance.inventoryManager.addItem(LevelMethods.GetFishRarity(level));
            GameManager.instance.ShowText("You got a Fish!", 15, Color.yellow, transform.position, Vector3.up, 3, false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.ShowText("Press E to Start Fishing", 15, Color.yellow, transform.position, Vector3.up, 0, true);
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