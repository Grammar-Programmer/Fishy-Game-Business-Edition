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
    public GameObject traderInventory;
    public GameObject activeSlots;
    private int numberOfTries = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) GameManager.instance.ShowText("Press E to Start Fishing", 15, Color.yellow, transform.position, Vector3.up, 0, true);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        //FishingRod fishingRod = null; 
        FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();

            if (fishingRod == null)
            {
                GameManager.instance.ShowText("You dont have a selected FishingRod", 15, Color.yellow, transform.position, Vector3.up, 5, false);
            }
            else
            {
                powerMinigame.GetComponent<PowerMinigame>().StartPowerUp();
                if (fishingRod.startFishing(numberOfTries))
                {
                    SelectMiniGame selectMiniGame = catchMinigame.GetComponent<SelectMiniGame>();
                    selectMiniGame.StartSelectMinigame();
                    if(selectMiniGame.getHasWon()){
                        //Ganhou 
                        // GameManager.instance.inventoryManager.addItem(GameManager.instance.inventoryManager.getCommumFish())
                    }else{
                        //Nao ganhou
                    }

                }
                else numberOfTries++;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        powerMinigame.GetComponent<PowerMinigame>().EndPowerUp();
        if (other.CompareTag("Player"))
        {
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            if (playerInventory != null)
            {
            }
        }
    }
}
