using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="Scriptable object/FishingRod")]
public class FishingRod : Item{
     public bool startFishing(int numberOfTries, double minigameScore){
        Thread.Sleep(RandomVariables.waitingTime(rarityDictionary[rarity]));
        return RandomVariables.catchAFish(numberOfTries, minigameScore);
    }
   
}
