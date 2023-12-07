using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName = "Scriptable object/FishingRod")]
public class FishingRod : Item
{
    public bool startFishing(int numberOfTries, double minigameScore, Transform transform)
    {
        bool fishHasAppeared = RandomVariables.catchAFish(numberOfTries, minigameScore);
        string txt = "Looks like that fish got a free meal ticket. Rebaiting... This might take a few Seconds.";
        if (fishHasAppeared) txt = "A wild Fish has appeared!";
        GameManager.instance.ShowText(txt, 20, Color.yellow, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z), Vector3.down, 3, false);
        return fishHasAppeared;
    }

    public int getExtimatedWaitingTime()
    {
        int c = GetCRarity(rarity);
        if (c != 1)
            return RandomVariables.waitingTime(c);
        return c;
    }


    public int GetCRarity(string str)
    {
        switch (str)
        {
            case "Commum":
                return 3;
            case "Rare":
                return 2;
            default:
                return 1;
        }
    }
}



