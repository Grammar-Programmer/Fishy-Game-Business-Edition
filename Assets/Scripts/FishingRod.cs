using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="Scriptable object/FishingRod")]
public class FishingRod : Item{
     public bool startFishing(int numberOfTries){
        return RandomVariables.catchAFish(numberOfTries,rarityDictionary[rarity]);
    }
   
}
