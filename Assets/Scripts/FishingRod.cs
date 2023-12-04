using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName = "Scriptable object/FishingRod")]
public class FishingRod : Item
{
    public bool startFishing(int numberOfTries, double minigameScore)
    {
        int c = GetCRarity(rarity);
        if (c != 1)
            Thread.Sleep(RandomVariables.waitingTime(c));
        else
            Thread.Sleep(500);
        return RandomVariables.catchAFish(numberOfTries, minigameScore);
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



