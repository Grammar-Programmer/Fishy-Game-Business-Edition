using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SaveTriger : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.ShowText("Press E to Save", 20, Color.yellow, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Vector3.down, 0, true);
        }
    }
    private void OnTriggerStay2D(Collider2D other){
        if(other.CompareTag("Player") && Input.GetKey(KeyCode.E)){
            DataPeristenceManager.instance.saveGame();
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
            GameManager.instance.ShowText("Game Saved", 20, Color.yellow, new Vector3(transform.position.x,transform.position.y-1,transform.position.z) , Vector3.down, 0, true);
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
        }
    }
}