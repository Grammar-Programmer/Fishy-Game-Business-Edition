using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Trigger : MonoBehaviour{
    public GameObject playerInventory;
    public GameObject traderInventory;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")) GameManager.instance.ShowText("Press E to trade",15,Color.yellow,transform.position,Vector3.up,0,true); 
    }
    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E)){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            GameManager.instance.inventoryManager.normalMode=false;
            playerInventory.SetActive(true);
            playerInventory.transform.Find("CharacterActiveSlots").gameObject.SetActive(false);
            traderInventory.SetActive(true);
            playerInventory.transform.Find("Container").localPosition=new Vector3(-12,-100,0);
        }else if(other.CompareTag("Player") && !traderInventory.activeSelf) GameManager.instance.ShowText("Press E to trade",15,Color.yellow,transform.position,Vector3.up,0,true);
    }
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            if(playerInventory!=null){
                playerInventory.SetActive(false);
                traderInventory.SetActive(false);
                playerInventory.transform.Find("CharacterActiveSlots").gameObject.SetActive(true);
                playerInventory.transform.Find("Container").localPosition=new Vector3(0,0,0);
                GameManager.instance.inventoryManager.normalMode=true;
            }
        }
    }
}
