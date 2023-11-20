using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
[CreateAssetMenu(menuName ="Scriptable object/bait")]
public class Bait : Item{
    public bool useBait(){
        return true;
    }
}
