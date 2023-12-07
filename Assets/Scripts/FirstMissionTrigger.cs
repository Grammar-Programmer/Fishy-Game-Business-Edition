using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstMissionTrigger : MonoBehaviour{
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.ShowText("Find the treasure to get\n your first Fishing Rod!", 20, Color.yellow, new Vector3(transform.position.x,transform.position.y,transform.position.z) , Vector3.down, 0, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
        }
    }
}