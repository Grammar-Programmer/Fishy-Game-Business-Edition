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
    private double mediaOfBiome = 5;
    private double varianceOfBiome = 0.2;
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
                    // passar o level pro jogo
                    int level = RandomVariables.catchAFishByRarity(0.5);

                    // de alguma forma passar essa raidade como level desse mini game 
                    selectMiniGame.StartSelectMinigame();
                    if (selectMiniGame.getHasWon())
                    {
                        //Ganhou
                        if (level == 5)
                        {
                            //ir na lista dos peixes muito raros e ir buscar um peixe raro
                         }
                        if (level == 3)
                        {
                            //ir na lista dos peixes de raridade mediuns e ir buscar um peixe mediuns
                       }
                        if (level == 1)
                        {
                            //ir na lista dos peixes de raridade baixa e ir buscar um peixe baixa
                       }
                    }
                    else
                    {
                        //Nao ganhou
                    }

                }
                else numberOfTries++;
            }
        }
        else if (other.CompareTag("Player") && !traderInventory.activeSelf) GameManager.instance.ShowText("Press E to Start Fishing", 15, Color.yellow, transform.position, Vector3.up, 0, true);
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
