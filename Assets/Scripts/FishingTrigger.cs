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
    private int numberOfTries = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) GameManager.instance.ShowText("Press E to Start Fishing", 15, Color.yellow, transform.position, Vector3.up, 0, true);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetKey(KeyCode.E)) minigame();
    }

    private void minigame()
    {
        FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
        Bait bait = GameManager.instance.inventoryManager.selectedBait;
        playerInventory.SetActive(false);
        GameManager.instance.floatingTextManager.GetFloatingText().Hide();

        if (fishingRod == null)
        {
            GameManager.instance.ShowText("You dont have a selected FishingRod", 15, Color.yellow, transform.position, Vector3.up, 5, false);
            return;
        }

        PowerMinigame powerGame = powerMinigame.GetComponent<PowerMinigame>();
        SelectMiniGame selectMiniGame = catchMinigame.GetComponent<SelectMiniGame>();
        Level level;
        while (true)
        {
            print("T");
            powerGame.StartPowerUp();
            if (!fishingRod.startFishing(numberOfTries, powerGame.result))
            {
                numberOfTries++;
                continue;
            }

            numberOfTries = 0;
            level = bait.useBait();

            selectMiniGame.StartSelectMinigame();
            selectMiniGame.SetDifficulty((int)level);
            
            if (selectMiniGame.getHasWon())
            {
                LevelMethods.GetFishRarity(level);
                return;
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
