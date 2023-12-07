using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TreasureTrigger : MonoBehaviour
{

    private bool isFirstTime = true;
    public FishingRod fishingRod;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            string text = "Esta foi de borla! Check your Iventory by clicking the chest and equip your brand new Fishing Rod!";
            if (isFirstTime)
            {
                text = "You just found your dad's Fishing Rod!";
                GameManager.instance.inventoryManager.addItem(fishingRod);
                isFirstTime = false;
            }

            GameManager.instance.ShowText(text, 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 2.5f, transform.position.z), Vector3.down, 0, true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.floatingTextManager.GetFloatingText().Hide();
        }
    }

}