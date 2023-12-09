using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private long waitingTime;
    private long timeToWait;
    private bool isWaiting;
    private bool hasAppeared;
    private bool timeWaited;
    public void Start()
    {
        powerGame = powerMinigame.GetComponent<PowerMinigame>();
        selectMiniGame = catchMinigame.GetComponent<SelectMiniGame>();
        isWaiting = false;
        hasAppeared = false;
        timeWaited = false;
    }
    public void Update()
    {
        waitingTime = DateTime.Now.Ticks;
        if (isWaiting && waitingTime < timeToWait)
            return;
        if (canFish && timeWaited)
        {
            GameManager.instance.player.started = true;
            string txt = GameManager.instance.inventoryManager.selectedFishingRod == null ? "You don't have a selected FishingRod. Select it and press E again!" : "Press E to Start Fishing";
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            GameManager.instance.ShowText(txt, 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Vector3.down, 0, true);
            timeWaited = false;
            return;
        }
        if (canFish && Input.GetKeyDown(KeyCode.E))
        {
            GameManager.instance.player.started = false;
            canFish = false;
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
            if (fishingRod == null)
            {
                GameManager.instance.ShowText("You don't have a selected FishingRod. Select it and press E again!", 20, Color.yellow, transform.position, Vector3.up, 5, false);
                return;
            }
            powerGame.fishingTrigger = this;
            powerMinigame.SetActive(true);
            powerGame.StartPowerUp();
        }
        if (powerMiniGameOver)
        {
            powerMiniGameOver = false;
            powerMinigame.SetActive(false);
            Debug.Log(powerGame.result);
            FishingRod fishingRod = GameManager.instance.inventoryManager.selectedFishingRod;
            Bait bait = (Bait)GameManager.instance.inventoryManager.inventorySelectedBaitSlot.GetComponentInChildren<InventoryItem>()?.item;
            if (!hasAppeared)
            {
                hasAppeared = fishingRod.startFishing(numberOfTries, powerGame.result, transform);
                timeToWait = DateTime.Now.Ticks + fishingRod.getExtimatedWaitingTime() * 10000;
                isWaiting = true;
                timeWaited = true;
                if (!hasAppeared)
                {
                    numberOfTries++;
                    canFish = true;
                }
                else
                {
                    GameManager.instance.floatingTextManager.GetFloatingText().Hide();
                    if (fishingRod.getExtimatedWaitingTime() > 5)
                        GameManager.instance.ShowText("This fish is heavy, I should buy a better fishing rod!", 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Vector3.down, 3, false);
                    numberOfTries = 0;
                    level = bait != null ? bait.useBait() : RandomVariables.catchAFishByRarity(0.1);
                    selectMiniGame.SetDifficulty((int)level);
                    selectMiniGame.fishingTrigger = this;
                    selectMiniGame.StartSelectMinigame();
                    hasAppeared = false;
                }
                return;
            }
        }
        if (selectMiniGameOver)
        {
            selectMiniGameOver = false;
            canFish = true;
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            isWaiting = true;
            timeToWait = DateTime.Now.Ticks + 1500 * 10000;
            if (selectMiniGame.getHasWon())
            {
                GameManager.instance.ShowText("You catched a Fish! Press E to catch more!", 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Vector3.down, 3, false);
                GameManager.instance.inventoryManager.addItem(LevelMethods.GetFishRarity(level));
            }
            else GameManager.instance.ShowText("You lost a Fish! Try again by pressing E!", 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Vector3.down, 3, false);
            GameManager.instance.player.started = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string txt = GameManager.instance.inventoryManager.selectedFishingRod == null ? "You don't have a selected FishingRod. Select it and press E!" : "Press E to Start Fishing";
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            GameManager.instance.ShowText(txt, 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), Vector3.down, 0, true);
            canFish = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        powerMinigame.GetComponent<PowerMinigame>().EndPowerUp();
        if (other.CompareTag("Player"))
        {
            canFish = false;
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
        }
    }
}