using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FishingTrigger : MonoBehaviour{
    public GameObject playerInventory;
    public GameObject traderInventory;
    public GameObject activeSlots;
    private int numberOfTries=0;
    private double mediaOfBiome=0.8;
    private double varianceOfBiome=0.2;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) GameManager.instance.ShowText("Press E to Start Fishing",15,Color.yellow,transform.position,Vector3.up,0,true); 
    }
    private void OnTriggerStay2D(Collider2D other){
        FishingRod fisihingRoad=GameManager.instance.inventoryManager.selectedFishingRod;
        Bait bait=GameManager.instance.inventoryManager.selectedBait;
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E)){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            if(fisihingRoad==null){
                GameManager.instance.ShowText("You dont have a selected FishingRod",15,Color.yellow,transform.position,Vector3.up,5,false);
            }else{
                if(fisihingRoad.startFishing(numberOfTries)){
                    bait.useBait(RandomVariables.probabilityOfBiome(mediaOfBiome, varianceOfBiome));
                    numberOfTries=0;
                }else numberOfTries++;
            }
        }else if(other.CompareTag("Player") && !traderInventory.activeSelf) GameManager.instance.ShowText("Press E to Start Fishing",15,Color.yellow,transform.position,Vector3.up,0,true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            if(playerInventory!=null){
            }
        }
    }
}
