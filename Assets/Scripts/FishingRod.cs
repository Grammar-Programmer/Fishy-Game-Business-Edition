using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="Scriptable object/FishingRod")]
public class FishingRod : Item{
     public bool startFishing(int numberOfTries){
        return randomVariables.catchAFish(numberOfTries,rarityDictionary[rarity]);
    }
    public void getFish(double mediaOfBiome, double varianceOfBiome){
        int n = 5;
        double p = RandomVariables.probabilityOfBiome(mediaOfBiome, varianceOfBiome);
        double algo=RandomVariables.ObterProbRaridade(0.5,p);
        int binomialRandomVariable = RandomVariables.binomial(n, algo);
        InventoryManager inventoryManager= GameManager.instance.inventoryManager;
        if (binomialRandomVariable >= 3){
            inventoryManager.getLegendaryFish();
        }
        else if (binomialRandomVariable == 2){
            inventoryManager.getRareFish();
        }
        else if (binomialRandomVariable < 2){
            inventoryManager.getCommumFish();
        }
    }
}
